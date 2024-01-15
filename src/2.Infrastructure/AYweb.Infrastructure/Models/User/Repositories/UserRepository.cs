using AYweb.Domain.Models.User.Repositories;
using AYweb.Infrastructure.Common.Repository;
using AYweb.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Infrastructure.Models.User.Repositories;

public class UserRepository : BaseRepository<Domain.Models.User.Entities.User>, IUserRepository
{
    private readonly AyWebDbContext _context;

    public UserRepository(AyWebDbContext context) : base(context)
    {
        _context = context;
    }

    public Domain.Models.User.Entities.User GetUserByEmail(string email)
    {
        return _context.Users.First(t => t.Email == email);
    }

    public Domain.Models.User.Entities.User GetUserById(long id)
    {
        return _context.Users.Find(id);
    }

    public Domain.Models.User.Entities.User GetUSerByPhoneNumber(string phoneNumber)
    {
        return _context.Users.First(t => t.PhoneNumber.Value == phoneNumber);
    }

    public Domain.Models.User.Entities.User GetUSerByUsername(string username)
    {
        throw new NotImplementedException();
    }
}
