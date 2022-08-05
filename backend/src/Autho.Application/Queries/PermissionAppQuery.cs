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
    public class PermissionAppQuery : IPermissionAppQuery
    {
        private readonly IAuthoContext _context;

        public PermissionAppQuery(IAuthoContext context)
        {
            _context = context;
        }

        public IPagedList<PermissionDto> GetPaged(IPermissionParameters parameters)
        {
            var source = _context.Query<PermissionData>();

            source = string.IsNullOrEmpty(parameters.Order) ? source.OrderBy(p => p.Name) : source.Order(parameters.Order);

            var totalItems = source.Count();

            var dtos = (from permission in source
                        select new PermissionDto()
                        {
                            Id = permission.Id,
                            Name = permission.Name,
                            Code = permission.Code
                        })
                        .Skip(parameters.Page * parameters.Size)
                        .Take(parameters.Size)
                        .ToList();

            return new PagedList<PermissionDto>(dtos, totalItems, parameters.Page, parameters.Size);
        }
    }
}
