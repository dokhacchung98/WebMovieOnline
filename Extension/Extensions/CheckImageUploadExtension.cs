using System.IO;

namespace Extension.Extensions
{
    public static class CheckImageUploadExtension
    {
        public static bool CheckImagePath(string imageName)
        {
            if (Path.GetExtension(imageName).ToLower() == ".jpg" ||
                Path.GetExtension(imageName).ToLower() == ".png" ||
                Path.GetExtension(imageName).ToLower() == ".gif" ||
                Path.GetExtension(imageName).ToLower() == ".jpeg")
            {
                return true;
            }

            return false;
        }
    }
}