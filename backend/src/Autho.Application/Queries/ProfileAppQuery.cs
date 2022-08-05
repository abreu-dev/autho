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
    public class ProfileAppQuery : IProfileAppQuery
    {
        private readonly IAuthoContext _context;

        public ProfileAppQuery(IAuthoContext context)
        {
            _context = context;
        }

        public IPagedList<ProfileDto> GetPaged(IProfileParameters parameters)
        {
            var source = _context.Query<ProfileData>();

            source = string.IsNullOrEmpty(parameters.Order) ? source.OrderBy(p => p.Name) : source.Order(parameters.Order);

            if (parameters.Name.Any() && parameters.Name.All(x => !string.IsNullOrEmpty(x)))
            {
                source = source.ApplyFilter("Name", parameters.Name);
            }

            var totalItems = source.Count();

            var dtos = (from profile in source
                        select new ProfileDto()
                        {
                            Id = profile.Id,
                            Name = profile.Name,
                            Permissions = profile.Permissions.Select(profilePermission => new PermissionDto()
                            {
                                Id = profilePermission.Permission.Id,
                                Name = profilePermission.Permission.Name,
                                Code = profilePermission.Permission.Code,
                            })
                        })
                        .Skip(parameters.Page * parameters.Size)
                        .Take(parameters.Size)
                        .ToList();

            return new PagedList<ProfileDto>(dtos, totalItems, parameters.Page, parameters.Size);
        }
    }
}
