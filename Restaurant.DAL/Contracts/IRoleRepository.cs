using Restaurant.DAL.Models;

namespace Restaurant.DAL.Contracts
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Role GetRoleByName(string name);
    }
}
