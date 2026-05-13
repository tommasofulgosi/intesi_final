using System.ComponentModel.DataAnnotations;

namespace social_V0._0._1.Models
{
    public class Utente
    {
        [Key]
        public int UtenteId { get; set; }

        [Required(ErrorMessage = "Il nome è obbligatorio")]
        [StringLength(50)] // Allineato al DB
        public string Nome { get; set; } = string.Empty; // Inizializzato per evitare warning CS8618

        [Required(ErrorMessage = "Il cognome è obbligatorio")]
        [StringLength(50)] // Allineato al DB
        public string Cognome { get; set; } = string.Empty;

        [Required(ErrorMessage = "L'email è obbligatoria")]
        [EmailAddress]
        [StringLength(50)] // Allineato allo screenshot del DB
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "La password è obbligatoria")]
        public string Password { get; set; } = string.Empty;

        [StringLength(50)] // Corretto da 10 a 50 come richiesto
        public string? Dipartimento { get; set; } // Nullable per i campi non obbligatori

        public DateTime? DataDiNascita { get; set; }

        public DateTime DataCreazione { get; set; } = DateTime.Now;

        [StringLength(255)] // Lunghezza come da screenshot
        public string? FotoUrl { get; set; }
    }
}