using System.ComponentModel.DataAnnotations;

namespace RemoteConfig.Application.Models.Project
{
    public class UpdateProjectRequest
    {
        [Required]
        public string CompanyId { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;
    }
}