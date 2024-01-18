using AIPFramework.Commands;
using AYweb.Domain.Common.ValueObjects;
using AYweb.Domain.Models.Product.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Product.Commands.AddComment
{
    public class AddCommentCommand:ICommand
    {
        public  required string Title { get;  set; }

        public required string Text { get;  set; }

        public required string UserName { get;  set; }

        public required string UserPhoneNumber { get;  set; }

        public required int ProductId { get;  set; }


    }
}
