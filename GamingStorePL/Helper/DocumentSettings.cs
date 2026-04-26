namespace GamingStorePL.Helper
{
    public static class DocumentSettings
    {
        public static string UploadeFile(IFormFile file)
        {
            string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), FileSettings.CoverPath);
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }
            string FileName = $"{Guid.NewGuid().ToString()}_" +
                $"{Path.GetFileNameWithoutExtension(file.FileName
                .Replace(" ", ""))}" +
                $"{Path.GetExtension(file.FileName)}";
            string FilePath = Path.Combine(FolderPath, FileName);
            using (var stream = new FileStream(FilePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return FileName;
        }
    }
}
