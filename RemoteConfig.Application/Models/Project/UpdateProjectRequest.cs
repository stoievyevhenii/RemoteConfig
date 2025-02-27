﻿using System.ComponentModel.DataAnnotations;

namespace RemoteConfig.Application.Models.Project
{
    public class UpdateProjectRequest
    {
        public string CompanyId { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
    }
}