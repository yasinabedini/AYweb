using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Gallery.Commands.DeleteGallery
{
    public class DeleteGalleryCommand:ICommand
    {
        public long Id { get; set; }
    }
}
