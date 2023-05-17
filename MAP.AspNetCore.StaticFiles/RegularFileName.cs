
using System.Linq;

namespace MAP.AspNetCore.StaticFiles;

public static class RegularFileName
{
    /// <summary>
    /// This method creates a unique name for your file and short your file name to dont exception url
    /// This method replace  "_" and "." from name to "-"
    /// This method set file name with out Extension 
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static string SetNameWithOutExtension(string name)
    {
        if (FileContentType.TryContentType(name))
            return string.Join("", toEnDigits(string.Join(".", name.Split(".").Take(name.Split(".").Count() - 1)).Replace(".", "-").Replace("_", "-").Replace(" - ", "-").Replace(" ", "-")).ToCharArray().Take(50));
        return string.Join("", toEnDigits(name.Replace(".", "-").Replace("_", "-").Replace(" - ", "-").Replace(" ", "-")).ToCharArray().Take(50));
    }

    /// <summary>
    /// This method creates a unique name for your file and short your file name to dont exception url
    /// This method replace  "_" and "." from name to "-"    
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static string SetNameWithExtension(string name)
    {
        return string.Join("", toEnDigits(string.Join(".", name.Split(".").Take(name.Split(".").Count() - 1)).Replace(".", "-").Replace(" - ", "-").Replace(" ", "-")).ToCharArray().Take(50)) + "." + toEnDigits(name.Split(".").AsQueryable().Last());
    }

    /// <summary>
    /// This method creates a unique name for your file and short your file name to dont exception url
    /// This method replace  "_" and "." from name to "-"
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static string SetNameWithExtension(string name, string extention)
    {
        return string.Join("", toEnDigits(name.Replace("_", "-").Replace(".", "-").Replace(" - ", "-").Replace(" ", "-")).ToCharArray().Take(50)) + "." + toEnDigits(extention.Split(".").AsQueryable().Last());
    }
    
    /// <summary>
    /// This method remove uniqe code from file name and remove extension
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static string RemoveGuidFromNameWithOutExtension(string name)
    {
        return toEnDigits(name.Replace("_" + name.Split("_")[1], string.Empty).Replace(" - ", "-").Replace(" ", "-"));
    }

    /// <summary>
    /// This method remove uniqe code from file name 
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static string RemoveGuidFromNameWithExtension(string name)
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
    public static string fileNameWithExtensionFromUrl(string url)
    {
        return url.Split("\\").AsQueryable().Last();
    }

    /// <summary>
    /// Check Url in asp.net Core Actions and Files
    /// </summary>
    /// <param name="url1"></param>
    /// <param name="url2"></param>
    /// <returns></returns>
    public static bool CheckUrl(string url1, string url2)
    {
        if (fileNameWithExtensionFromUrl(url1).Contains("?") || fileNameWithExtensionFromUrl(url2).Contains("?"))
        {
            url1 = url1.ToLower().Replace("/home/index", string.Empty).Replace("/index", string.Empty);
            if (url1.EndsWith("/"))
                url1 = url1.Remove(url1.Length - 1, 1);

            url2 = url2.ToLower().Replace("/home/index", string.Empty).Replace("/index", string.Empty);
            if (url2.EndsWith("/"))
                url2 = url2.Remove(url2.Length - 1, 1);

            if (url1 == url2)
                return true;
        }
        else
        {
            if(FileContentType.TryContentType(fileNameWithExtensionFromUrl(url1)) || FileContentType.TryContentType(fileNameWithExtensionFromUrl(url2)))
            {
                url1 = url1.ToLower();
                url2 = url2.ToLower();
                if(url1 == url2)
                    return true;
            }
            else
            {
                url1 = url1.ToLower().Replace("/home/index", string.Empty).Replace("/index", string.Empty);
                if (url1.EndsWith("/"))
                    url1 = url1.Remove(url1.Length - 1, 1);

                url2 = url2.ToLower().Replace("/home/index", string.Empty).Replace("/index", string.Empty);
                if (url2.EndsWith("/"))
                    url2 = url2.Remove(url2.Length - 1, 1);

                if (url1 == url2)
                    return true;
            }
        }
        return false;
    }
}