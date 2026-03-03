using HealthCentre.Enums;
using HealthCentre.Models;

namespace HealthCentre.Extensions
{
    internal static class UserExtensions
    {
        public static Group GetRole(this User user)
        {
            return user.Role.ToGroup();
        }
    }
}
