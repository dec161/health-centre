using HealthCentre.Models;
using System.IO;

namespace HealthCentre.Extensions
{
    internal static class PhotoExtensions
    {
        public static string GetStoragePath(this Photo photo)
        {
            return Path.Combine("Photos", photo.RelativePath);
        }
    }
}
