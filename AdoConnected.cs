using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpese
{
   public class AdoConnected
    {

        static string ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=GestSpese;Trusted_Connection=True;";

        public static void ConnectionDemo()
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            if (connection.State == System.Data.ConnectionState.Open)
                Console.WriteLine("Connessi al DB");
            else
                Console.WriteLine("NON connessi al DB");

            connection.Close();
        }
        public static void DataReaderDemo()
        {
            //CREO LA CONNESSIONE
            using SqlConnection conn = new SqlConnection(ConnectionString);

            try
            {
                //OPERAZIONI DA ESEGUIRE SUL DATABASE
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                    Console.WriteLine("Connessi al DB");
                else
                    Console.WriteLine("Non connessi al DB");


                SqlCommand readCommand = new SqlCommand();
                readCommand.Connection = conn;
                readCommand.CommandType = System.Data.CommandType.Text;
                readCommand.CommandText = "SELECT * FROM GestSpese";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore :{ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }

        public static void VisualizzazioneSpesa()
        {
            using SqlConnection conn = new SqlConnection(ConnectionString);

            try
            {



                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                    Console.WriteLine("Connessi al DB");
                else
                    Console.WriteLine("Non connessi al DB");

                string SqlStatement = "select * from Spesa";
                SqlCommand readCommand = new SqlCommand(SqlStatement, conn);

                SqlDataReader reader = readCommand.ExecuteReader();
                Console.WriteLine("Spesa");

                while(reader.Read())
                {
                    Console.WriteLine("{0}-{1} {2} {3} {4} {5} {6}",
                        reader["Id"],
                        reader["Data"],
                        reader["Descrizione"],
                        reader["Utente"],
                        reader["Importo"],
                        reader["Approvata"],
                        reader["IdCateg"]);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
            }
            finally
            {
                conn.Close();

            }
        }





        public static void InsertSpesa()
        {
            using SqlConnection conn = new SqlConnection(ConnectionString);
            try
            {
                conn.Open();

                Console.WriteLine("inserire una nuova spesa:");
                Console.ReadLine();
                Console.WriteLine("inserisci id : ");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("inseire la data:");
                DateTime data=DateTime.Now;
                Console.WriteLine("inserire la nuova descrizione: ");
                string descrzione = Console.ReadLine();
                Console.WriteLine("inserisci il nome utente:");
                string utente = Console.ReadLine();
                Console.WriteLine("inserisci importo:");
                decimal importo = decimal.Parse(Console.ReadLine());
                bool approvata = true;

                string insertSqlStatemente= "Insert Spesa set Id=@id,Data=@data,Descrizione=@descrizione,Utente=@utente,Importo=@importo";

                SqlCommand insertCommand = conn.CreateCommand();
                insertCommand.CommandText = insertSqlStatemente;

                insertCommand.Parameters.AddWithValue("@Id", id);
                insertCommand.Parameters.AddWithValue("@Data", data);
                insertCommand.Parameters.AddWithValue("@Descrizione",descrzione);

                insertCommand.Parameters.AddWithValue("@utente", utente);

                insertCommand.Parameters.AddWithValue("@importo", importo);

                int result = insertCommand.ExecuteNonQuery();

                if (result == 1)
                    Console.WriteLine("Inserimento avvenuto con successo");
                else
                    Console.WriteLine("Errore di inserimento");

            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }




        public static void UpdateApprovata()
        {
            using SqlConnection conn = new SqlConnection(ConnectionString);
            try
            {


                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                    Console.WriteLine("Connessi al DB");
                else
                    Console.WriteLine("Non connessi al DB");

                Console.WriteLine("Inserisci Id della lista da approvare:");
                int id=int.Parse(Console.ReadLine());

                string updateSqlStatement = "update Spesa set Approvata=1 where id=@Id";
                SqlCommand updateCommand=conn.CreateCommand();
                updateCommand.CommandText=updateSqlStatement;

                int result = updateCommand.ExecuteNonQuery();
                if (result == 1)
                    Console.WriteLine("Spesa approvata con successo");
                else
                    Console.WriteLine("Errore di approvazione");


            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }







            public static void ModificationSpesa()
            {
            using SqlConnection conn = new SqlConnection(ConnectionString);
            try
            {
                conn.Open();

                Console.WriteLine("Inserire la nuova spesa:");
                Console.ReadLine();
                Console.WriteLine("inserisci id della spesa da modificare:");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Insererisci nuova descrizione:");
                string nuovadescrzione = Console.ReadLine();

                string updateSqlStatement = "update Spesa set Descrizione=@nuovadescrizione where approvata=@approvata";
                SqlCommand updateCommand = conn.CreateCommand();
                updateCommand.CommandText = updateSqlStatement;


               
                int result = updateCommand.ExecuteNonQuery();
                if (result == 1)
                    Console.WriteLine("Spesa modificata con successo");
                else
                    Console.WriteLine("Errore di Modifica");
            }   
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
            }
            finally
            {
                conn.Close();

             
            }
        }
            }
        }
     

