
using MAP.AspNetCore.StaticFiles.FilesAction.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MAP.AspNetCore.StaticFiles.FilesAction.Actions;

public static class FileActions
{
    private static IWebHostEnvironment WebEnv()
    {
        var _accessor = new HttpContextAccessor();
        return _accessor.HttpContext.RequestServices.GetRequiredService<IWebHostEnvironment>();
    }

    public static void CreateDirectory()
    {
        if (!Directory.Exists(WebEnv().WebRootPath + "\\File"))
            Directory.CreateDirectory(WebEnv().WebRootPath + "\\File");
        if (!Directory.Exists(WebEnv().WebRootPath + "\\File\\audio"))
            Directory.CreateDirectory(WebEnv().WebRootPath + "\\File\\audio");
        if (!Directory.Exists(WebEnv().WebRootPath + "\\File\\document"))
            Directory.CreateDirectory(WebEnv().WebRootPath + "\\File\\document");
        if (!Directory.Exists(WebEnv().WebRootPath + "\\File\\image"))
            Directory.CreateDirectory(WebEnv().WebRootPath + "\\File\\image");
        if (!Directory.Exists(WebEnv().WebRootPath + "\\File\\video"))
            Directory.CreateDirectory(WebEnv().WebRootPath + "\\File\\video");
    }

    public static bool Upload(IFormFile file, string fileName = "", string alt = "", string title = "", string fileType = "", string sourceRedirect = "")
    {
        if (file == null) return false;
        try
        {
            var path = "";
            string fileId;
            FileInfo info = new FileInfo(file.FileName);
            CreateDirectory();
            if (fileType.Contains("image"))
            {
                if (fileName == "")
                {
                    fileId = RegularFileName.SetNameWithOutExtension(file.FileName) + "_" + Convert.ToString(Guid.NewGuid()) + info.Extension.ToString();
                    path = WebEnv().WebRootPath + "\\File\\image\\" + fileId;
                }
                else
                {
                    fileId = RegularFileName.SetNameWithOutExtension(fileName) + "_" + Convert.ToString(Guid.NewGuid()) + info.Extension.ToString();
                    path = WebEnv().WebRootPath + "\\File\\image\\" + fileId;
                }
                using var f = File.Create(path);
                file.CopyTo(f);
                path = path.Split("wwwroot")[1];
                try
                {
                    RootFile file1 = new RootFile()
                    {
                        fileName = fileId,
                        fileAddress = path,
                        fileType = fileType,
                        alt = alt,
                        title = title,
                        date = DateTime.Now,
                        sourceRedirect = sourceRedirect,
                        fileSize = FileSize.Size(info.Length)
                    };

                    return true;
                }
                catch
                {
                    if (File.Exists(WebEnv().WebRootPath + path))
                        File.Delete(WebEnv().WebRootPath + path);
                    return false;
                }
            }
            else if (fileType.Contains("video"))
            {
                if (fileName == "")
                {
                    fileId = RegularFileName.SetNameWithOutExtension(file.FileName) + "_" + Convert.ToString(Guid.NewGuid()) + info.Extension.ToString();
                    path = WebEnv().WebRootPath + "\\File\\video\\" + fileId;
                }
                else
                {
                    fileId = RegularFileName.SetNameWithOutExtension(fileName) + "_" + Convert.ToString(Guid.NewGuid()) + info.Extension.ToString();
                    path = WebEnv().WebRootPath + "\\File\\video\\" + fileId;
                }
                using var f = File.Create(path);
                file.CopyTo(f);
                path = path.Split("wwwroot")[1];
                try
                {
                    RootFile file1 = new RootFile()
                    {
                        fileName = fileId,
                        fileAddress = path,
                        fileType = fileType,
                        date = DateTime.Now,
                        alt = alt,
                        title = title,
                        fileSize = FileSize.Size(info.Length)
                    };

                    return true;
                }
                catch
                {
                    if (File.Exists(WebEnv().WebRootPath + path))
                        File.Delete(WebEnv().WebRootPath + path);
                    return false;
                }
            }
            else if (fileType.Contains("audio"))
            {
                if (fileName == "")
                {
                    fileId = RegularFileName.SetNameWithOutExtension(file.FileName) + "_" + Convert.ToString(Guid.NewGuid()) + info.Extension.ToString();
                    path = WebEnv().WebRootPath + "\\File\\audio\\" + fileId;
                }
                else
                {
                    fileId = RegularFileName.SetNameWithOutExtension(fileName) + "_" + Convert.ToString(Guid.NewGuid()) + info.Extension.ToString();
                    path = WebEnv().WebRootPath + "\\File\\audio\\" + fileId;
                }
                using var f = File.Create(path);
                file.CopyTo(f);
                path = path.Split("wwwroot")[1];
                try
                {
                    RootFile file1 = new RootFile()
                    {
                        fileName = fileId,
                        fileAddress = path,
                        fileType = fileType,
                        date = DateTime.Now,
                        alt = alt,
                        title = title,
                        fileSize = FileSize.Size(info.Length)
                    };

                    return true;
                }
                catch
                {
                    if (File.Exists(WebEnv().WebRootPath + path))
                        File.Delete(WebEnv().WebRootPath + path);
                    return false;
                }
            }
            else
            {
                if (fileName == "")
                {
                    fileId = RegularFileName.SetNameWithOutExtension(file.FileName) + "_" + Convert.ToString(Guid.NewGuid()) + info.Extension.ToString();
                    path = WebEnv().WebRootPath + "\\File\\document\\" + fileId;
                }
                else
                {
                    fileId = RegularFileName.SetNameWithOutExtension(fileName) + "_" + Convert.ToString(Guid.NewGuid()) + info.Extension.ToString();
                    path = WebEnv().WebRootPath + "\\File\\document\\" + fileId;
                }
                using var f = File.Create(path);
                file.CopyTo(f);
                path = path.Split("wwwroot")[1];
                try
                {
                    RootFile file1 = new RootFile()
                    {
                        fileName = fileId,
                        fileAddress = path,
                        fileType = fileType,
                        date = DateTime.Now,
                        fileSize = FileSize.Size(info.Length)
                    };

                    return true;
                }
                catch
                {
                    if (File.Exists(WebEnv().WebRootPath + path))
                        File.Delete(WebEnv().WebRootPath + path);
                    return false;
                }
            }
        }
        catch
        {
            return false;
        }
    }
}
