namespace Autho.Infra.Data.Core.Entities
{
    public abstract class BaseData
    {
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }

        protected BaseData()
        {
            CreatedDate = DateTime.UtcNow;
            CreatedBy = "System";
        }

        public void OnCreate(DateTime createdDate, string createdBy)
        {
            CreatedDate = createdDate;
            CreatedBy = createdBy;
        }

        public void OnUpdate(DateTime updatedDate, string updatedBy)
        {
            UpdatedDate = updatedDate;
            UpdatedBy = updatedBy;
        }
    }
}
