using HealthCentre.Enums;
using System;

namespace HealthCentre.Extensions
{
    internal static class EnumExtensions
    {
        public static Permissions GetPermissions(this Group role)
        {
            switch (role)
            {
                case Group.Guest:
                case Group.Patient:
                    return Permissions.None;

                case Group.Doctor:
                    return Permissions.ViewPatients;

                case Group.Admin:
                    return Permissions.All;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
