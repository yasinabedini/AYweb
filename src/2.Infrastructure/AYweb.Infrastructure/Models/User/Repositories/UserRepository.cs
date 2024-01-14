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
    public UserRepository(AyWebDbContext context) : base(context)
    {
    }

    public Domain.Models.User.Entities.User GetUSerByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public Domain.Models.User.Entities.User GetUSerByPhoneNumber(string phoneNumber)
    {
        throw new NotImplementedException();
    }

    public Domain.Models.User.Entities.User GetUSerByUsername(string username)
    {
        throw new NotImplementedException();
    }
}
