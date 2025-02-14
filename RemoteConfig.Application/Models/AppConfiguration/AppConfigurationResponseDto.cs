using RemoteConfig.Core.Entities;

namespace RemoteConfig.Application.Models.AppConfiguration
{
    public class AppConfigurationResponseDto
    {
        public string Key { get; set; } = string.Empty;
        public string UpdatedBy { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public IEnumerable<AppConfigurationValue> Values { get; set; }
    }
}