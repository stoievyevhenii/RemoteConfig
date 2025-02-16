using RemoteConfig.Core.Entities;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteConfig.Application.Models.AppConfiguration
{
    public class UpdateAppConfigurationRequest
    {
        public string Key { get; set; } = string.Empty;
        public string ProjectId { get; set; } = string.Empty;
        public List<AppConfigurationValueDto> Values { get; set; } = new List<AppConfigurationValueDto>();
    }
}