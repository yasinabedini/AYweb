using AIPFramework.Commands;
using AYweb.Domain.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Project.Commands.CreateProject
{
    public class CreateProjectCommand:ICommand
    {
        public required string Title { get;  set; }

        public required string ShortDescription { get;  set; }

        public required string Description { get;  set; }

        public required string ShamsiDateString { get;  set; }

        public required string CustomerName { get;  set; }

        public required string RelatedService { get;  set; }

        public required string Link { get;  set; }
    }
}
