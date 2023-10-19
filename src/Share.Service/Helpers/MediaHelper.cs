namespace Share.Service.Helpers;

public class MediaHelper
{
    public static string MakeImageName(string fileName)
    {
        FileInfo fileInfo = new FileInfo(fileName);
        string extension = fileInfo.Extension;
        string name = "_IMG" + Guid.NewGuid() + extension;
        return name;
    }
}