using System;
using System.Data.SQLite;
using System.IO;
using System.Diagnostics;

namespace gestion_concrets.Services
{
    internal static class DatabaseService
    {
  
        private static readonly string projectRoot = Path.GetFullPath(
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..")
        );

   
        private static readonly string dataFolder = Path.Combine(projectRoot, "Data");
        private static readonly string dbPath = Path.Combine(dataFolder, "database.db");
        private static readonly string connectionString = $"Data Source={dbPath};";

        public static SQLiteConnection GetConnection()
        {
            Debug.WriteLine($"[INFO] Project root : {projectRoot}");
            Debug.WriteLine($"[INFO] Data folder  : {dataFolder}");

            try
            {
                
                //if (!Directory.Exists(dataFolder))
                //{
                //    Debug.WriteLine($"[INFO] Création du dossier racine Data : {dataFolder}");
                //    Directory.CreateDirectory(dataFolder);
                //} else
                //{
                //    Debug.WriteLine($"[INFO] Dossier racine Data existe déjà : {dataFolder}");
                //}


                //if (!File.Exists(dbPath))
                //{
                //    Debug.WriteLine($"[INFO] Création du fichier database.db : {dbPath}");
                //    SQLiteConnection.CreateFile(dbPath);
                //} else
                //{
                //    Debug.WriteLine($"[INFO] Fichier database.db existe déjà : {dbPath}");
                //}
                    return new SQLiteConnection(connectionString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERREUR] Impossible d'initialiser la connexion SQLite : {ex.Message}");
                throw;
            }
        }

        public static void InitializeTableDatabase()
        {
            Debug.WriteLine("[INFO] Initialisation des tables SQLite...");

            try
            {
                using var con = GetConnection();
                con.Open();
                Debug.WriteLine("[INFO] Connexion SQLite ouverte.");

                using (var pragmaCmd = new SQLiteCommand("PRAGMA foreign_keys = ON;", con))
                {
                    pragmaCmd.ExecuteNonQuery();
                    Debug.WriteLine("[INFO] PRAGMA foreign_keys activé.");
                }

                const string sql = @"
                    CREATE TABLE IF NOT EXISTS BPerson (
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
                    );
                    CREATE TABLE IF NOT EXISTS Alocalisation (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        IdBPerson INTEGER NOT NULL,
                        A1 TEXT NOT NULL,
                        A2 TEXT NOT NULL,
                        A3 TEXT NOT NULL,
                        A4 TEXT NOT NULL,
                        FOREIGN KEY(IdBPerson) REFERENCES BPerson(Id) ON DELETE CASCADE
                    );
                    CREATE TABLE IF NOT EXISTS Itransmission (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        IdBPerson INTEGER NOT NULL,
                        I11 TEXT NOT NULL,
                        I12 TEXT NOT NULL,
                        I2 TEXT NOT NULL,
                        I3 TEXT NOT NULL,
                        I4 TEXT NOT NULL,
                        I51 TEXT NOT NULL,
                        I52 TEXT NOT NULL,
                        I53 TEXT NOT NULL,
                        I54 TEXT NOT NULL,
                        I55 TEXT NOT NULL,
                        I56 TEXT NOT NULL,
                        I57 TEXT NOT NULL,
                        I58 TEXT NOT NULL,
                        I59 TEXT NOT NULL,
                        I510 TEXT NOT NULL,
                        I6 TEXT NOT NULL,
                        I7 TEXT NOT NULL,
                        I8 TEXT NOT NULL,
                        I9 TEXT NOT NULL,
                        FOREIGN KEY(IdBPerson) REFERENCES BPerson(Id) ON DELETE CASCADE
                    );
                    CREATE TABLE IF NOT EXISTS IIapplicationCDPH (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        IdBPerson INTEGER NOT NULL,
                        II1 TEXT NOT NULL,
                        II2 TEXT NOT NULL,
                        II3 TEXT NOT NULL,
                        II4 TEXT NOT NULL,
                        II5 TEXT NOT NULL,
                        II6 TEXT NOT NULL,
                        FOREIGN KEY(IdBPerson) REFERENCES BPerson(Id) ON DELETE CASCADE
                    );
                    CREATE TABLE IF NOT EXISTS IIIright (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        IdBPerson INTEGER NOT NULL,
                        III1 TEXT NOT NULL,
                        III2 TEXT NOT NULL,
                        III3 TEXT NOT NULL,
                        III21 TEXT NOT NULL,
                        III22 TEXT NOT NULL,
                        III23 TEXT NOT NULL,
                        III24 TEXT NOT NULL,
                        III25 TEXT NOT NULL,
                        III31 TEXT NOT NULL,
                        III32 TEXT NOT NULL,
                        III33 TEXT NOT NULL,
                        III41 TEXT NOT NULL,
                        III42 TEXT NOT NULL,
                        III43 TEXT NOT NULL,
                        III51 TEXT NOT NULL,
                        III52 TEXT NOT NULL,
                        III53 TEXT NOT NULL,
                        FOREIGN KEY(IdBPerson) REFERENCES BPerson(Id) ON DELETE CASCADE
                    );
                    CREATE TABLE IF NOT EXISTS IVdutyGov (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        IdBPerson INTEGER NOT NULL,
                        IV11 TEXT NOT NULL,
                        IV12 TEXT NOT NULL,
                        IV13 TEXT NOT NULL,
                        IV2 TEXT NOT NULL,
                        IV3 TEXT NOT NULL,
                        IV4 TEXT NOT NULL,
                        IV51 TEXT NOT NULL,
                        IV52 TEXT NOT NULL,
                        FOREIGN KEY(IdBPerson) REFERENCES BPerson(Id) ON DELETE CASCADE
                    );
                    CREATE TABLE IF NOT EXISTS VdevSupport (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        IdBPerson INTEGER NOT NULL,
                        V1 TEXT NOT NULL,
                        V2 TEXT NOT NULL,
                        V3 TEXT NOT NULL,
                        V41 TEXT NOT NULL,
                        V42 TEXT NOT NULL,
                        V51 TEXT NOT NULL,
                        V52 TEXT NOT NULL,
                        V53 TEXT NOT NULL,
                        FOREIGN KEY(IdBPerson) REFERENCES BPerson(Id) ON DELETE CASCADE
                    );
                    CREATE TABLE IF NOT EXISTS VIpartnerCollab (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        IdBPerson INTEGER NOT NULL,
                        VI1 TEXT NOT NULL,
                        VI2 TEXT NOT NULL,
                        VI3 TEXT NOT NULL,
                        FOREIGN KEY(IdBPerson) REFERENCES BPerson(Id) ON DELETE CASCADE
                    );
                    ";

                using var cmd = new SQLiteCommand(sql, con);
                cmd.ExecuteNonQuery();
                Debug.WriteLine("[SUCCÈS] Tables créée ou déjà existante avec contraintes FK activés.");
            }
            catch (Exception ex) when (ex is SQLiteException || ex is IOException)
            {
                Debug.WriteLine($"[ERREUR] {ex.GetType().Name} : {ex.Message}");
                throw;
            }
        }
    }
}
