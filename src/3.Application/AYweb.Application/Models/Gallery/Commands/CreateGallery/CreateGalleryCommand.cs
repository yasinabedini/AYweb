using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Gallery.Commands.CreateGallery
{
    public class CreateGalleryCommand:ICommand
    {
        public required string ImageName { get; set; }
    }
}
