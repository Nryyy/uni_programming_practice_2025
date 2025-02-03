namespace HromadaWEB.Infrastructure.Interfaces.Role
{
    public interface IRoleService
    {
        public Task<IEnumerable<Models.Entities.Role>> GetRolesAsync();
    }
}
