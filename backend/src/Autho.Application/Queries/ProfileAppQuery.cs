using Autho.Application.Contracts;
using Autho.Application.Queries.Interfaces;
using Autho.Domain.Repositories;

namespace Autho.Application.Queries
{
    public class ProfileAppQuery : IProfileAppQuery
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileAppQuery(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public IEnumerable<ProfileDto> GetAll()
        {
            var profiles = _profileRepository.GetAllWithPermissions();

            return profiles.Select(x => new ProfileDto()
            {
                Id = x.Id,
                Name = x.Name,
                Permissions = x.Permissions.Select(y => new PermissionDto()
                {
                    Id = y.Id,
                    Name = y.Name,
                    Code = y.Code
                })
            });
        }
    }
}
