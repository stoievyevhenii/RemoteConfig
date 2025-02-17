namespace RemoteConfig.Application.Models.AppConfiguration
{
    public class AppConfigurationExternalRequest
    {
        public string AppConfigKey { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string ProjectName { get; set; } = string.Empty;
    }
}