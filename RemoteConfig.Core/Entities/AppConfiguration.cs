﻿using RemoteConfig.Core.Common;

namespace RemoteConfig.Core.Entities
{
    public class AppConfiguration : BaseEntity, IAuditedEntity
    {
        public string CreatedBy { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public string Description { get; set; }
        public string Key { get; set; } = string.Empty;
        public string NormalizedKey { get; set; } = string.Empty;
        public Project Project { get; set; }
        public string UpdatedBy { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public IEnumerable<AppConfigurationValue> Values { get; set; }
    }
}