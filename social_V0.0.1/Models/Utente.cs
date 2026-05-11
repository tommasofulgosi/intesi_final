public class Utente
{
    public int UtenteID { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; } // hash di BCrypt
    public string Email { get; set; }
}