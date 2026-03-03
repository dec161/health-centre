using HealthCentre.Enums;
using HealthCentre.Models;
using System;

namespace HealthCentre.Extensions
{
    internal static class RoleExtensions
    {
        public static Group ToGroup(this Role role)
        {
            switch (role.Name)
            {
                case "Пациент":
                    return Group.Patient;

                case "Врач":
                    return Group.Doctor;

                case "Администратор":
                    return Group.Admin;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
