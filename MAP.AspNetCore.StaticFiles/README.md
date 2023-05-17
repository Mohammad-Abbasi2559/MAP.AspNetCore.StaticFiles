# With this package you can work with static file name
* Create uniqe name for file
* Take file ContentType
* Compare two url for asp.net core
* ...
#### More features will be released soon

## FileContentType class
This class work with cntent type

#### fileContentType(string? name)
Get content type from file name
#### TryContentType(string name)
Check file content type is exist or not


## RegularFileName class
This class work with file name

#### `SetNameWithOutExtension(string name)`
This method creates a unique name for your file and short your file name to dont exception url
This method replace  "_" and "." from name to "-"
This method set file name with out Extension 
#### `SetNameWithExtension(string name)`
This method creates a unique name for your file and short your file name to dont exception url
This method replace  "_" and "." from name to "-"  
#### `SetNameWithExtension(string name, string extention)`
This method creates a unique name for your file and short your file name to dont exception url
This method replace  "_" and "." from name to "-"
#### `RemoveGuidFromNameWithOutExtension(string name)`
This method remove uniqe code from file name and remove extension
#### `RemoveGuidFromNameWithExtension(string name)`
This method remove uniqe code from file name
#### `toEnDigits(string input)`
This method change Persian/Arabic number to English number
#### `fileNameWithExtensionFromUrl(string url)`
Get file name from Url
#### `CheckUrl(string path1, string path2)`
Check Url in asp.net Core Actions and Files


## FileExtensions class

#### `GetFileExtension(string fileName)`
This method get file extension