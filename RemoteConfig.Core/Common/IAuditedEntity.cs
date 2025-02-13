namespace RemoteConfig.Core.Common
{
    public interface IAuditedEntity
    {
        public string CreatedBy { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public DateTimeOffset? UpdatedOn { get; set; }
    }
}