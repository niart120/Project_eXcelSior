namespace Project_eXcelSior.Misc
{
    internal class DirectoryUtils
    {
        public static DirectoryInfo? SafeCreateDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                return null;
            }
            return Directory.CreateDirectory(path);
        }

        public static string[] GetFileNames(string path, params string[] extensions)
        {
            return Directory.GetFiles(path, "*.*")
                .Where(c => extensions.Any(extension => c.ToLower().EndsWith(extension.ToLower())))
                .Select(s=>Path.GetFileName(s))
                .ToArray()
            ;
        }
    }
}
