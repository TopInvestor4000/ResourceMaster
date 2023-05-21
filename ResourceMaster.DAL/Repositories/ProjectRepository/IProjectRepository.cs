﻿using ResourceMaster.DAL.Models;

namespace ResourceMaster.DAL.Repositories.ProjectRepository
{
    public interface IProjectRepository
    {
        Task AddAsync(Project project);
        Task<IEnumerable<Project>> GetAllAsync();
        Task<Project> GetSingle(int id);
        Task UpdateAsync(Project updatedItem);
    }
}
