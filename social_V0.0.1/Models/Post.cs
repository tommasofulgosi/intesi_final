using System;

namespace social_V0._0._1.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Titolo { get; set; } = string.Empty;
        public string Contenuto { get; set; } = string.Empty;
        public string Reparto { get; set; } = "Tutti";
        public string Tipo { get; set; } = "Info";
        public bool IsBroadcast { get; set; }
        public DateTime DataCreazione { get; set; } = DateTime.Now; 
        public string Autore { get; set; } = "Anonimo";
        
        public int LikesCount { get; set; }
        public bool GiaMessoLike { get; set; }
    }
}