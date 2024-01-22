using AIPFramework.Commands;
using AYweb.Domain.Models.Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Project.Commands.UpdateProject
{
    public class UpdateProjectCommand:ICommand
    {
        public required Domain.Models.Project.Entities.Project Project { get; set; }
    }
}
