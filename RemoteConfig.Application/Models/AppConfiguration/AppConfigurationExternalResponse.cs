using RemoteConfig.Core.Entities;

namespace RemoteConfig.Application.Models.AppConfiguration
{
    public class AppConfigurationExternalResponse
    {
        public string Key { get; set; } = string.Empty;
        public IEnumerable<AppConfigurationValue> Values { get; set; }
    }
}