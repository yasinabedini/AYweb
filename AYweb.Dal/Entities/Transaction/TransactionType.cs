﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Dal.Entities.Transaction
{
    public class TransactionType
    {
        public string Type { get; set; }

        public TransactionType(string type)
        {
            Type = type;
        }
    }
}