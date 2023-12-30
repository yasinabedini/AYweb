using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Dal.Enums
{
    public enum _OrderStatus
    {
        Cart=1,
        AwaitingApproval=2,
        Failed = 3,
        PreparingSend = 4,
        Posted =5
                        
    }
}
