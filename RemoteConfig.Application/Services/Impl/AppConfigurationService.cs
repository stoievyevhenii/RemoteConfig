﻿using RemoteConfig.Application.Models.AppConfiguration;
using RemoteConfig.Core.Entities;
using RemoteConfig.Core.Exceptions;
using RemoteConfig.DataAccess.Repositories;
using RemoteConfig.DataAccess.Repositories.Impl;

namespace RemoteConfig.Application.Services.Impl
{
    public class AppConfigurationService : IAppConfigurationService
    {
        private readonly IAppConfigurationRepository _appConfigurationRepository;
        private readonly IAppConfigurationValueRepository _appConfigurationValueRepository;
        private readonly ICompanyService _companyService;
        private readonly IProjectService _projectService;

        public AppConfigurationService(
            IAppConfigurationRepository appConfigurationRepository,
            IAppConfigurationValueRepository appConfigurationValueRepository,
            IProjectService projectService,
            ICompanyService companyService)
        {
            _appConfigurationRepository = appConfigurationRepository;
            _projectService = projectService;
            _companyService = companyService;
            _appConfigurationValueRepository = appConfigurationValueRepository;
        }

        public async Task<AppConfiguration> AddAsync(CreateAppConfigurationRequest createAppConfigurationRequest)
        {
            var anyExist = await _appConfigurationRepository
                .GetFirstOrDefaultAsync(x => x.NormalizedKey == createAppConfigurationRequest.Key.ToUpper()
                        && x.Project.Id == Guid.Parse(createAppConfigurationRequest.ProjectId)) != null;

            if (anyExist)
            {
                throw new DublicateRecordException("App configuration already exist");
            }

            var project = await _projectService.GetAsync(Guid.Parse(createAppConfigurationRequest.ProjectId))
                ?? throw new RecordNotFoundException("Project not found");

            var appConfiguration = new AppConfiguration()
            {
                Key = createAppConfigurationRequest.Key,
                Values = createAppConfigurationRequest.Values,
                Project = project,
                NormalizedKey = createAppConfigurationRequest.Key.ToUpper()
            };

            return await _appConfigurationRepository.AddAsync(appConfiguration);
        }

        public async Task<bool> DeleteAsync(Guid projectId)
        {
            var project = await _appConfigurationRepository.GetFirstOrDefaultAsync(x => x.Id == projectId)
                ?? throw new RecordNotFoundException("App configuration not found");

            await _appConfigurationRepository.DeleteAsync(project);
            return true;
        }

        public async Task<List<AppConfigurationResponseDto>> GetAllRecordsInProjectAsync(Guid companyId)
        {
            var records = await _appConfigurationRepository
                .GetAsync(x => x.Project.Id == companyId);

            var dtosList = new List<AppConfigurationResponseDto>();

            foreach (var record in records)
            {
                dtosList.Add(new AppConfigurationResponseDto()
                {
                    Key = record.Key,
                    Values = record.Values,
                    UpdatedBy = record.UpdatedBy,
                    UpdatedOn = record.UpdatedOn
                });
            }

            return dtosList;
        }

        public async Task<AppConfigurationResponseDto> GetAsync(Guid appConfigurationGuid)
        {
            var record = await _appConfigurationRepository
                .GetFirstOrDefaultAsync(x => x.Id == appConfigurationGuid);

            return new AppConfigurationResponseDto()
            {
                Key = record.Key,
                Values = record.Values,
                UpdatedBy = record.UpdatedBy,
                UpdatedOn = record.UpdatedOn
            };
        }

        public async Task<AppConfigurationExternalResponse> GetAsync(AppConfigurationExternalRequest externalRequest)
        {
            var company = await _companyService.GetAsync(externalRequest.CompanyName)
                ?? throw new RecordNotFoundException("Company not found");

            var projectsList = await _projectService.GetAllRecordsInCompanyAsync(company.Id)
                ?? throw new RecordNotFoundException("Projects list is empty");

            var project = projectsList.FirstOrDefault(x => x.Name == externalRequest.ProjectName)
                ?? throw new RecordNotFoundException("Project not found");

            var appConfiguration = await _appConfigurationRepository
                .GetFirstOrDefaultAsync(x => x.Project.Id == project.Id
                    && x.NormalizedKey == externalRequest.AppConfigKey.ToUpper())
                ?? throw new RecordNotFoundException("App configuration not found");

            return new AppConfigurationExternalResponse()
            {
                Key = appConfiguration.Key,
                Values = appConfiguration.Values,
            };
        }

        public async Task<AppConfiguration> UpdateAsync(Guid id, UpdateAppConfigurationRequest updateAppConfigurationRequest)
        {
            var record = await _appConfigurationRepository.GetFirstOrDefaultAsync(x => x.Id == id);

            var mustUpdate = false;

            if (!string.IsNullOrEmpty(updateAppConfigurationRequest.ProjectId))
            {
                var projectGuid = Guid.Parse(updateAppConfigurationRequest.ProjectId);

                var project = await _projectService.GetAsync(projectGuid)
                ?? throw new RecordNotFoundException("Project not found");

                record.Project = project;
                mustUpdate = true;
            }

            if (!string.IsNullOrEmpty(updateAppConfigurationRequest.Key))
            {
                record.Key = updateAppConfigurationRequest.Key;
                record.NormalizedKey = updateAppConfigurationRequest.Key.ToUpper();

                mustUpdate = true;
            }

            var oldValues = new List<AppConfigurationValue>();

            if (updateAppConfigurationRequest.Values?.Count > 0)
            {
                oldValues = record.Values.ToList();

                record.Values = updateAppConfigurationRequest.Values.Select(v => new AppConfigurationValue
                {
                    Description = v.Description,
                    Value = v.Value,
                }).ToList();

                mustUpdate = true;
            }

            if (mustUpdate)
            {
                await _appConfigurationRepository.UpdateAsync(record);
            }

            await _appConfigurationValueRepository.DeleteRangeAsync(oldValues);

            return record;
        }
    }
}