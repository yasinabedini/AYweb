using AYweb.Domain.Models.Gallery.Repositories;
using AYweb.Infrastructure.Common.Repository;
using AYweb.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Infrastructure.Models.Gallery.Repositories;

public class GelleryRepository : BaseRepository<Domain.Models.Gallery.Entities.Gallery>, IGalleryRepository
{
    public GelleryRepository(AyWebDbContext context) : base(context)
    {
    }
}
