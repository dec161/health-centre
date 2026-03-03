using HealthCentre.Models;
using System;
using System.Linq;

namespace HealthCentre
{
    internal static class CalorieCalculator
    {
        private static float? CalculateCalories(int patientId, float activityCoefficient)
        {
            using (var context = new HealthCentreModel())
            {
                var currentPatient = context.Patient.FirstOrDefault(patient => patient.Id == patientId);
                if (currentPatient is null)
                {
                    return null;
                }

                var age = (DateTime.Now - currentPatient.BirthDate).Days / 365;
                var genderVariable = currentPatient.Gender.Name == "Муж" ? 5 : -161;

                var voo = 9.99f * currentPatient.Weight + 6.25f * currentPatient.Height - 4.92f * age + genderVariable;
                return activityCoefficient * voo;
            }
        }
    }
}
