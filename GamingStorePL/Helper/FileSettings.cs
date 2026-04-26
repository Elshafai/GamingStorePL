namespace GamingStorePL.Helper
{
    public static class FileSettings
    {
        public const string CoverPath = "wwwroot/Files";
        public const string AllowedExtensions = ".jpg,.jpeg,.png";
        public const int MaxFileSizeInBytes = MaxFileSizeInMB * 1024 * 1024; // 5 MB
        public const int MaxFileSizeInMB = 5; // 5 MB
    }
}
