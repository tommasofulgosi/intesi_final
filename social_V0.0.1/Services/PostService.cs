namespace social_V0._0._1.Services
{
    using Microsoft.Data.SqlClient;
    using social_V0._0._1.Models;
    using System.Data;

    public class PostService
    {
        private readonly string _connectionString = "Server=192.168.16.215,1433;Database=db.social;User Id=app_user;Password=2026Intesi;TrustServerCertificate=True;";
        public async Task InsertPostAsync(int utenteId, string contenuto)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                // Query SQL per inserire il post. 
                // Nota: LikeCount parte da 0 e DataPubblicazione è l'ora attuale del server SQL
                string sql = @"INSERT INTO Post (UtenteId, Contenuto, DataPubblicazione, LikeCount) 
                       VALUES (@uid, @cont, GETDATE(), 0)";

                var command = new SqlCommand(sql, connection);

                // Usiamo i parametri per evitare SQL Injection (fondamentale per la sicurezza!)
                command.Parameters.AddWithValue("@uid", utenteId);
                command.Parameters.AddWithValue("@cont", contenuto);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
        }
        public async Task<List<PostViewModel>> GetAllPostsAsync()
        {
            var lista = new List<PostViewModel>();
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"SELECT P.PostId, P.Contenuto, P.DataPubblicazione, 
                                      U.Nome, U.Cognome, U.Dipartimento, U.FotoUrl
                               FROM Post P
                               INNER JOIN Utenti U ON P.UtenteId = U.UtenteId
                               ORDER BY P.DataPubblicazione DESC";

                var command = new SqlCommand(sql, connection);
                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        lista.Add(new PostViewModel
                        {
                            PostId = (int)reader["PostId"],
                            Contenuto = reader["Contenuto"].ToString(),
                            DataPubblicazione = (DateTime)reader["DataPubblicazione"],
                            Nome = reader["Nome"].ToString(),
                            Cognome = reader["Cognome"].ToString(),
                            Dipartimento = reader["Dipartimento"].ToString(),
                            FotoUrl = reader["FotoUrl"] == DBNull.Value ? null : reader["FotoUrl"].ToString()
                        });
                    }
                }
            }
            return lista;
        }
    }
}