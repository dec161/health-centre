namespace HealthCentre.Enums
{
    public enum Permissions
    {
        None = 0,
        ViewPatients = 2 << 0,
        EditPatients = 2 << 1,
        All = ViewPatients | EditPatients
    }
}
