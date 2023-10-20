namespace Share.Service.Helpers;

public static class MediaHelper
{
    public static string MakeImageName(string fileName)
    {
        var fileInfo = new FileInfo(fileName);
        var extension = fileInfo.Extension;
        var name = "_IMG" + Guid.NewGuid() + extension;
        return name;
    }
}