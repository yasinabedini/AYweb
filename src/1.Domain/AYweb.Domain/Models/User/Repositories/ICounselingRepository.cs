using AYweb.Domain.Common.Repositories;
using AYweb.Domain.Models.User.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Domain.Models.User.Repositories
{
    public interface ICounselingRepository:IRepository<Counseling>
    {
        void CallSuccess(long id);
    }
}
