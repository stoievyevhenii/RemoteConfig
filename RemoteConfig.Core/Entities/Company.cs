using RemoteConfig.Core.Common;

namespace RemoteConfig.Core.Entities
{
    public class Company : BaseEntity, IAuditedEntity
    {
        public string CreatedBy { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public string Name { get; set; } = string.Empty;
        public string UpdatedBy { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
    }
}