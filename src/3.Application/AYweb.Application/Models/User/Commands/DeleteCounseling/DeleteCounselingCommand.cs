﻿using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Commands.DeleteCounseling
{
    public class DeleteCounselingCommand:ICommand
    {
        public long Id { get; set; }
    }
}
