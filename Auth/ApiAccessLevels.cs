namespace GestionFacturation.Api.Auth
{
    public enum ApiAccessLevels
    {
        None = 0,
        Admin = 1,
        Technicien = 2,
        Full = Admin | Technicien 
    }
}