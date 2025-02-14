using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteConfig.Application.Models.AppConfiguration
{
    public class GetAppConfigurationRequest
    {
        [Required]
        public string ProjectId { get; set; } = string.Empty;
    }
}