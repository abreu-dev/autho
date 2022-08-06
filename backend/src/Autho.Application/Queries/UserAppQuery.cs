using Autho.Application.Contracts;
using Autho.Application.Queries.Interfaces;
using Autho.Application.Queries.Parameters.Interfaces;
using Autho.Core.Extensions;
using Autho.Domain.Core.Data.Pagination;
using Autho.Domain.Core.Data.Pagination.Interfaces;
using Autho.Infra.Data.Context;
using Autho.Infra.Data.Entities;

namespace Autho.Application.Queries
{
    public class UserAppQuery : IUserAppQuery
    {
        private readonly IAuthoContext _context;

        public UserAppQuery(IAuthoContext context)
        {
            _context = context;
        }

        public IPagedList<UserDto> GetPaged(IUserParameters parameters)
        {
            var source = _context.Query<UserData>();

            source = string.IsNullOrEmpty(parameters.Order) ? source.OrderBy(p => p.Name) : source.Order(parameters.Order);

            var totalItems = source.Count();

            var dtos = (from user in source
                        select new UserDto()
                        {
                            Id = user.Id,
                            Name = user.Name,
                            Email = user.Email,
                            Login = user.Login,
                            Language = user.Language.GetEnumDisplayName() ?? "",
                            Profiles = user.Profiles.Select(userProfile => new ProfileDto()
                            {
                                Id = userProfile.Profile.Id,
                                Name = userProfile.Profile.Name,
                                Permissions = userProfile.Profile.Permissions.Select(profilePermission => new PermissionDto()
                                {
                                    Id = profilePermission.Permission.Id,
                                    Name = profilePermission.Permission.Name,
                                    Code = profilePermission.Permission.Code,
                                })
                            })
                        })
                        .Skip(parameters.Page * parameters.Size)
                        .Take(parameters.Size)
                        .ToList();

            return new PagedList<UserDto>(dtos, totalItems, parameters.Page, parameters.Size);
        }
    }
}
