using System.ComponentModel.DataAnnotations;

namespace RemoteConfig.Application.Models.Project
{
    public class GetProjectRequest
    {
        [Required]
        public string CompanyId { get; set; } = string.Empty;
    }
}