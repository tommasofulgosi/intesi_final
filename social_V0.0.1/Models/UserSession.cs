namespace social_V0._0._1.Models
{
    public class UserSession
    {
        public string? Username { get; set; }
        public bool IsLoggedIn => !string.IsNullOrEmpty(Username);

        // Questo evento avviserà il menu di ricaricarsi
        public event Action? OnChange;

        public void Login(string username)
        {
            Username = username;
            NotifyStateChanged();
        }

        public void Logout()
        {
            Username = null;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}