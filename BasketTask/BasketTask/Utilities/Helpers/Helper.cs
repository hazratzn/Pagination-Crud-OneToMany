using System.IO;

namespace BasketTask.Utilities.Helpers
{
    public static class Helper
    {
        public static string GetFilePath(string root, string folder, string subFolder, string fileName)
        {
            return Path.Combine(root, folder, subFolder, fileName);
        }

        public static void DeleteFile(string path)
        {
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }
    }
}
