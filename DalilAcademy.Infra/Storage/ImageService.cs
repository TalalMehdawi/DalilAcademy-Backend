using System;

using DalilAcademy.Core.Exceptions;
using DalilAcademy.Core.Storage;


namespace DalilAcademy.Infra.Storage;

public class ImageService : IImageService
{
    private readonly string _folderPath=Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","images","courses");
    private readonly string[] Allowed=[".jpg",".jpeg",".png"];


    public async Task<string> SaveCourseImageAsync(Stream content,string fileName,long length)
    {
        if( length ==0 || length>2*1024*1024)
            throw new InvalidFileException("Image must be less than 2 mb and bigger than 0");
        var ext=Path.GetExtension(fileName).ToLower();
        if(!Allowed.Contains(ext))
            throw new InvalidFileException("only .jpg .jpeg .png is Allowed ");
        Directory.CreateDirectory(_folderPath);
        var name = $"{Guid.NewGuid()}{ext}";
        await using var file=File.Create(Path.Combine(_folderPath,name));
        await content.CopyToAsync(file);
        return "/image/courses/" + name;
    }

    public void deleteCourseImage(string? imageUrl)
    {
        if(string.IsNullOrEmpty(imageUrl))return;
        var path=Path.Combine(_folderPath,Path.GetFileName(imageUrl));
        if(File.Exists(path))
            File.Delete(path);

    }
}
