
namespace MAP.AspNetCore.StaticFiles;

public static class FileExtensions
{
    /// <summary>
    /// This method get file extension
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public static string? GetFileExtension(string fileName)
    {
        if (fileName == null || fileName == "") throw new ArgumentNullException("FileNameRquired");
        if (!fileName.Contains(".")) throw new ArgumentException("FileDontHaveExtention");

        return fileName.Split('.').AsQueryable().LastOrDefault();
    }
}