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

        public void OnUpdate()
        {
            UpdatedDate = DateTime.UtcNow;
            UpdatedBy = "System";
        }
    }
}
