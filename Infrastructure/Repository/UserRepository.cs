using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;


namespace Infrastructure.Repository;
public class UserRepository : GenericRepository<User>, IUser
{
    private readonly E2AppContext _context;
    public UserRepository(E2AppContext context) : base(context)
    {
        _context = context;
    }
    public async Task<User> GetByUserNameAsync (string userName)
    {
        return await _context.Users.Include(u => u.Rols).FirstOrDefaultAsync (u => u.Name_User.ToLower()==userName.ToLower());
    }
}
