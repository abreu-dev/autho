using Autho.Infra.CrossCutting.Globalization.Resources;

namespace Autho.Principal
{
    public class ProfileAppService : IProfileAppService
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IPermissionRepository _permissionRepository;

        public ProfileAppService(IProfileRepository profileRepository, 
                                 IPermissionRepository permissionRepository)
        {
            _profileRepository = profileRepository;
            _permissionRepository = permissionRepository;
        }

        public IResult Add(ProfileCreationDto creationDto)
        {
            if (_profileRepository.ExistsName(Guid.Empty, creationDto.Name))
            {
                return new Result(ResultType.Failure, new ResultError("AlreadyUsed", "Already Used", AuthoResource.NameAlreadyInUse));
            }

            var resultPermission = ValidatePermissions(creationDto.Permissions);
            if (resultPermission.Type == ResultType.Failure)
            {
                return resultPermission;
            }

            var permissions = creationDto.Permissions.Select(x => new PermissionDomain(x.Id)).ToList();
            var profile = new ProfileDomain(creationDto.Name, permissions);

            _profileRepository.Add(profile);
            _profileRepository.UnitOfWork.Complete();

            return new Result(ResultType.Success);
        }

        public IResult Update(Guid id, ProfileCreationDto creationDto)
        {
            if (_profileRepository.ExistsName(id, creationDto.Name))
            {
                return new Result(ResultType.Failure, new ResultError("AlreadyUsed", "Already Used", AuthoResource.NameAlreadyInUse));
            }

            var resultPermission = ValidatePermissions(creationDto.Permissions);
            if (resultPermission.Type == ResultType.Failure)
            {
                return resultPermission;
            }

            var profile = _profileRepository.GetWithPermissions(id);

            if (profile == null)
            {
                return new Result(ResultType.Failure, new ResultError("NotFound", "Not Found", AuthoResource.ProfileNotFound));
            }

            profile.UpdateName(creationDto.Name);

            profile.ClearPermissions();
            profile.AddPermissions(creationDto.Permissions.Select(x => new PermissionDomain(x.Id)).ToList());

            _profileRepository.UpdateProfile(profile);
            _profileRepository.UnitOfWork.Complete();

            return new Result(ResultType.Success);
        }

        public IResult Remove(Guid id)
        {
            _profileRepository.Delete(id);
            _profileRepository.UnitOfWork.Complete();

            return new Result(ResultType.Success);
        }

        private IResult ValidatePermissions(IEnumerable<ProfilePermissionCreationDto> permissions)
        {
            if (permissions != null)
            {
                var duplicatedPermissions = permissions.GroupBy(x => x.Id).Where(x => x.Count() > 1).ToList();
                if (duplicatedPermissions.Any())
                {
                    var result = new Result(ResultType.Failure);
                    duplicatedPermissions.ForEach(duplicatedPermission =>
                    {
                        result.Errors.Add(new ResultError("Duplicated", "Duplicated", AuthoResource.DuplicatedPermission));
                    });
                    return result;
                }

                var failedPermissions = new List<Guid>();
                foreach (var _ in permissions.Where(permission => !_permissionRepository.Exists(permission.Id)))
                {
                    failedPermissions.Add(_.Id);
                }
                if (failedPermissions.Any())
                {
                    var result = new Result(ResultType.Failure);
                    failedPermissions.ForEach(failedPermission =>
                    {
                        result.Errors.Add(new ResultError("NotFound", "Not Found", AuthoResource.PermissionNotFound));
                    });
                    return result;
                }
            }

            return new Result(ResultType.Success);
        }
    }
}
