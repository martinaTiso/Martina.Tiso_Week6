using Microsoft.Extensions.Configuration;
using SupportDisconnected;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpese
{
    public class AdoDisconnected
    {

        static IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(@"C:\Users\martina.tiso\Desktop\Esercitazione6\GestioneSpese")
            .AddJsonFile("appsettings.json")
            .Build();

        static string ConnectionString = config.GetConnectionString("GestioneDB");



        public static void DeleteSpesa()
        {
            DataSet spesaDs = new DataSet();

            using SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                connection.Open();
                SqlDataAdapter adapter = Class1.InitSpesaDataSetAndAdapter(
                    spesaDs, connection);
                connection.Close();
                DataRow rowToDelete = spesaDs.Tables["Spesa"].Rows.Find(3);
                if (rowToDelete != null)
                    rowToDelete.Delete(); //cancellata dal dataset (ma non dal db)
                adapter.Update(spesaDs, "Spesa");
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Generic Error: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }

        }
        public static void SpesaUtente()
        {

            DataSet spesaDs = new DataSet();

            using SqlConnection conn = new SqlConnection(ConnectionString);
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    Console.WriteLine("Connessione stabilita");
                }
                else
                {
                    Console.WriteLine("Connessione non riuscita");
                    return;
                }

                //OPERAZIONI DI RECUPERO DEI DATI
                Class1.InitSpesaDataSetAndAdapter(spesaDs, conn);

                conn.Close();
                //lavoro in modalità disconnessa
                Console.WriteLine("=== Spesa List ===");
                //STAMPA DEI DATI IN LOCALE
                List<Spesa> spese = new List<Spesa>();
                foreach (DataRow row in spesaDs.Tables["Spesa"].Rows)
                {
                    Console.WriteLine($"[ {row["Id"]} ] Data: {row["Data"]} " +
                        $"Descrzione: {row["Descrizione"]} Utente: {row["Utente"] }Importo: {row["Importo"]} Approvata:{row["Approvata"]} IdCateg:{row["IdCateg"]}");
                    spese.Add(new Spesa
                    {
                        Id = (int)row["Id"],
                        Data = (DateTime)row["Data"],
                        Descrizione = (string)row["Descrizione"],
                        Utente = (string)row["Utente"],
                        Importo = (decimal)row["Importo"],
                        Approvata = (bool)row["Approvata"],

                    });
                }
                spesaDs.Where(x => x.Utente);
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Errror: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Generic Error: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }


    }
}
        

