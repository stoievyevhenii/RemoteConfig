using RemoteConfig.Core.Common;

namespace RemoteConfig.Core.Entities
{
    public class AppConfigurationValue : BaseEntity, IAuditedEntity
    {
        public string CreatedBy { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public string Description { get; set; }
        public string UpdatedBy { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public string Value { get; set; }
    }
}