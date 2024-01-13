using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPFramework.ValueObjects.Conversion
{
    public class BussinesIdConversion : ValueConverter<BusinessId, string>
    {
        public BussinesIdConversion() : base(t => t.Value.ToString(), t => BusinessId.FromString(t)) { }
    }
}
