
namespace MAP.AspNetCore.StaticFiles;

public static class RegularFileName
{
    /// <summary>
    /// This method creates a unique name for your file and short your file name to dont exception url
    /// This mothod replace  "_" and "." from name to "-"
    /// This method set file name with out Extension 
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static string SetNameWithOutExtention(string name)
    {
        if (FileContentType.TryContentType(name))
            return string.Join("", toEnDigits(string.Join(".", name.Split(".").Take(name.Split(".").Count() - 1)).Replace(".", "-").Replace("_", "-").Replace(" - ", "-").Replace(" ", "-")).ToCharArray().Take(50));
        return string.Join("", toEnDigits(name.Replace(".", "-").Replace("_", "-").Replace(" - ", "-").Replace(" ", "-")).ToCharArray().Take(50));
    }

    /// <summary>
    /// This method creates a unique name for your file and short your file name to dont exception url
    /// This mothod replace  "_" and "." from name to "-"    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static string SetNameWithExtention(string name)
    {
        return string.Join("", toEnDigits(string.Join(".", name.Split(".").Take(name.Split(".").Count() - 1)).Replace(".", "-").Replace(" - ", "-").Replace(" ", "-")).ToCharArray().Take(50)) + "." + toEnDigits(name.Split(".").AsQueryable().Last());
    }

    /// <summary>
    /// This method creates a unique name for your file and short your file name to dont exception url
    /// This mothod replace  "_" and "." from name to "-"
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static string SetNameWithExtention(string name, string extention)
    {
        return string.Join("", toEnDigits(name.Replace("_", "-").Replace(".", "-").Replace(" - ", "-").Replace(" ", "-")).ToCharArray().Take(50)) + "." + toEnDigits(extention.Split(".").AsQueryable().Last());
    }
    
    /// <summary>
    /// This method remove uniqe code from file name and remove extension
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static string RemoveGuidFromNameWithOutExtention(string name)
    {
        return toEnDigits(name.Replace("_" + name.Split("_")[1], string.Empty).Replace(" - ", "-").Replace(" ", "-"));
    }

    /// <summary>
    /// This method remove uniqe code from file name 
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static string RemoveGuidFromNameWithExtention(string name)
    {
        return toEnDigits(name.Replace("_" + name.Split("_")[1], string.Empty).Replace(" - ", "-").Replace(" ", "-") + "." + name.Split(".")[1]);
    }

    /// <summary>
    /// This method change Persian/Arabic number to English number
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string toEnDigits(string input)
    {
        string[] persian = new string[10] { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };

        for (int j = 0; j < persian.Length; j++)
            input = input.Replace(persian[j], j.ToString());

        return input;
    }

    /// <summary>
    /// Get file name from Url
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public static string fileNameWithExtentionFromUrl(string url)
    {
        return url.Split("\\").AsQueryable().Last();
    }

    /// <summary>
    /// Check Url in asp.net Core Actions and Files
    /// Exception When Use Folder with Index and Home name in wwwroot 
    /// </summary>
    /// <param name="path1"></param>
    /// <param name="path2"></param>
    /// <returns></returns>
    public static bool CheckUrl(string path1, string path2)
    {
        path1 = path1.ToLower().Replace("/home/index", string.Empty).Replace("/index", string.Empty);
        if (path1.EndsWith("/"))
            path1 = path1.Remove(path1.Length - 1, 1);

        path2 = path2.ToLower().Replace("/home/index", string.Empty).Replace("/index", string.Empty);
        if (path2.EndsWith("/"))
            path2 = path2.Remove(path2.Length - 1, 1);

        if (path1 == path2)
            return true;

        return false;
    }
}
