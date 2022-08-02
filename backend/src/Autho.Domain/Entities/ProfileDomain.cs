using Autho.Domain.Core.Entities;
using Autho.Domain.Validations.Interfaces;
using FluentValidation;
using FluentValidation.Results;

namespace Autho.Domain.Entities
{
    public class ProfileDomain : BaseDomain
    {
        public string Name { get; private set; }

        public virtual ICollection<PermissionDomain> Permissions { get; private set; }

        public ProfileDomain(Guid id, string name, ICollection<PermissionDomain> permissions) : base(id)
        {
            Name = name;
            Permissions = permissions;
        }

        public ProfileDomain(string name, ICollection<PermissionDomain> permissions)
        {
            Name = name;
            Permissions = permissions;
        }

        public void UpdateName(string name)
        {
            Name = name;
        }

        public void ClearPermissions()
        {
            Permissions.Clear();
        }

        public void AddPermissions(ICollection<PermissionDomain> permissions)
        {
            permissions.ToList().ForEach(permission =>
            {
                AddPermission(permission);
            });
        }

        private void AddPermission(PermissionDomain permission)
        {
            if (!ExistsPermission(permission))
            {
                Permissions.Add(permission);
            }
        }

        private bool ExistsPermission(PermissionDomain permission)
        {
            return Permissions.Any(x => x.Id == permission.Id);
        }

        public ValidationResult ValidationResult { get; private set; }

        public bool IsValid(IProfileValidation validation)
        {
            ValidationResult = validation.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
