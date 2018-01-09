using System.IO;

namespace ReleaseWITAlert.Lib
{
    public static class Constants
    {
        public static string ProjectFolderPath =>
            $"{Directory.GetParent(Directory.GetCurrentDirectory()).FullName}\\Projects\\";
    }
}
