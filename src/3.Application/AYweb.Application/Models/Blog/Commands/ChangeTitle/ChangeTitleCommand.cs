using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Blog.Commands.ChangeTitle
{
    public class ChangeTitleCommand:ICommand
    {
        public long Id { get; set; }
        public required string Title { get; set; }
    }
}
