namespace ResourceMaster.DAL.Repositories.ResourceProject;

public interface IResourceProjectRepository
{
    Task<IEnumerable<Models.ProjectResource>> GetAvailability(int id, DateTime? from, DateTime? to);
}
