using AIPFramework.Commands;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Blog.Commands.ChangeImage
{
    public class ChangeImageCommand:ICommand
    {
        public required long Id { get; set; }

        public required string ImageName { get; set; }
    }
}
