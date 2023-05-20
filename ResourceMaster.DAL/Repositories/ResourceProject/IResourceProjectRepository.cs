namespace ResourceMaster.DAL.Repositories.ResourceProject;

public interface IResourceProjectRepository
{
    Task<IEnumerable<Models.ResourceProject>> GetAvailability(int id, DateTime? from, DateTime? to);
}
