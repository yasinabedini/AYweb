﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Dal.Entities.Order
{
    public class OrderStatus
    {

        public OrderStatus(string status)
        {
            Status = status;
        }
        public string Status { get; set; }
    }
}
