namespace ResourceMaster.DAL.Repositories.ResourceProject;

public interface IResourceProjectRepository
{
    Task<List<Models.ProjectResource>> GetAvailability(int id, DateTime? from, DateTime? to);
}
