﻿using RemoteConfig.Application.Models.Project;
using RemoteConfig.Core.Entities;
using RemoteConfig.Core.Exceptions;
using RemoteConfig.DataAccess.Repositories;

namespace RemoteConfig.Application.Services.Impl
{
    public class ProjectService : IProjectService
    {
        private readonly ICompanyService _companyService;
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository, ICompanyService companyService)
        {
            _projectRepository = projectRepository;
            _companyService = companyService;
        }

        public async Task<Project> AddRecord(CreateProjectRequest createProjectRequest)
        {
            var anyExist = await _projectRepository
                .GetFirstOrDefaultAsync(x => x.NormalizedName == createProjectRequest.Name.ToUpper()
                        && x.Company.Id == Guid.Parse(createProjectRequest.CompanyId)) != null;

            if (anyExist)
            {
                throw new DublicateRecordException("Project already exist");
            }

            var company = await _companyService.GetAsync(Guid.Parse(createProjectRequest.CompanyId))
                ?? throw new RecordNotFoundException("Company not found");

            var project = new Project()
            {
                Name = createProjectRequest.Name,
                Company = company,
                NormalizedName = createProjectRequest.Name.ToUpper()
            };

            return await _projectRepository.AddAsync(project);
        }

        public async Task<bool> Delete(Guid projectId)
        {
            var project = await _projectRepository.GetFirstOrDefaultAsync(x => x.Id == projectId)
                ?? throw new RecordNotFoundException("Project not found");

            await _projectRepository.DeleteAsync(project);
            return true;
        }

        public async Task<List<Project>> GetAllRecordsInCompanyAsync(Guid companyId)
        {
            return await _projectRepository.GetAsync(x => x.Company.Id == companyId);
        }

        public async Task<Project> Update(Guid id, UpdateProjectRequest updateProject)
        {
            var record = await _projectRepository.GetFirstOrDefaultAsync(x => x.Id == id);

            var companyGuid = Guid.Parse(updateProject.CompanyId);

            if (record.NormalizedName == updateProject.Name.ToUpper() && record.Company.Id == companyGuid)
            {
                return record;
            }

            var company = await _companyService.GetAsync(companyGuid)
                ?? throw new RecordNotFoundException("Company not found");

            record.Name = updateProject.Name;
            record.NormalizedName = updateProject.Name.ToUpper();
            record.Company = company;

            await _projectRepository.UpdateAsync(record);
            return record;
        }
    }
}