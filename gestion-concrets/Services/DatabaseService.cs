using System;
using System.Data.SQLite;
using System.IO;

namespace gestion_concrets.Services
{
    internal class DatabaseService
    {
        // Pointe vers Data\database.db dans la racine du projet
        private static string dbPath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "..", "..", "Data", "database.db");
        private static string connectionString = $"Data Source={dbPath};Version=3;";

        public static SQLiteConnection GetConnection()
        {
            var directory = Path.GetDirectoryName(dbPath);
            try
            {
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                    Console.WriteLine($"Dossier créé : {directory}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la création du dossier : {ex.Message}");
                throw;
            }

            Console.WriteLine($"Chemin de la base de données : {dbPath}");
            if (!File.Exists(dbPath))
            {
                Console.WriteLine("Le fichier de base de données n'existe pas, il sera créé.");
            }

            try
            {
                return new SQLiteConnection(connectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la création de la connexion : {ex.Message}");
                throw;
            }
        }

        public static void InitializeTableDatabase()
        {
            try
            {
                using var con = GetConnection();
                con.Open();
                Console.WriteLine("Connexion à la base de données réussie.");

                var command = con.CreateCommand();
                command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Person (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        B1 TEXT NOT NULL,
                        B2 INTEGER NOT NULL,
                        B3 TEXT NOT NULL,
                        Adress TEXT NOT NULL,
                        Phone TEXT NOT NULL,
                        Email TEXT NOT NULL,
                        B4 TEXT NOT NULL,
                        B51 TEXT NOT NULL,
                        B52 TEXT NOT NULL,
                        B6 TEXT NOT NULL,
                        B7 TEXT NOT NULL,
                        B71 TEXT NOT NULL,
                        B72 TEXT NOT NULL,
                        B8 TEXT NOT NULL
                    );";
                command.ExecuteNonQuery();
                Console.WriteLine("Tableau 'Person' créé ou déjà existant.");
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine($"Erreur SQLite : {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur générale : {ex.Message}");
                throw;
            }
        }
    }
}