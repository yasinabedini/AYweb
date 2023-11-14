using AYweb.Core.Convertors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace AYweb.Core.Tools;

public class FileTools
{
    public void SaveImage(IFormFile profileImage, string imageName, string whichFolder, bool thumbSave)
    {
        string imagePath = imagePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\images\\{whichFolder}", imageName);

        using (var stream = new FileStream(imagePath, FileMode.Create))
        {
            profileImage.CopyTo(stream);
        }

        //save ThumbNail
        if (thumbSave)
        {
            string thumbImagePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\images\\{whichFolder}\\Thumb", imageName);
            ImageConvertor imageConvertor = new ImageConvertor();
            imageConvertor.Image_resize(imagePath, thumbImagePath, 213);
        }
    }
    public static void DeleteFile(string path)
    {
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
}
