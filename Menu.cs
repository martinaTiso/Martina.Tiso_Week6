using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpese
{
    internal class Menu
    {


        internal static void Start()
        {


            bool exits = true;


            do
            {

                Console.WriteLine("[Menu] " +
                            "\n[1] Visualizza elenco spese" +
                            "\n[2] Aggiungere nuova spesa" +
                            "\n[3] Approva spesa" +
                            "\n[4] Modifica Spesa" +
                            "\n[5] Elimina spesa" +
                            "\n[6] Visualizzare l'elenco delle spese per utente" +
                            "\n[7] Visualizzare l'elenco delle spese approvate" +
                            "\n[Q] Esci");

                char choice = Console.ReadKey().KeyChar;


                switch (choice)
                {
                    case '1':
                        AdoConnected.VisualizzazioneSpesa();
                        ;
                        break;
                    case '2':
                        AdoConnected.InsertSpesa();
                        ;
                        break;

                        AdoConnected.UpdateApprovata();

                    case '3':
                        break;
                    case '4':
                        AdoConnected.ModificationSpesa();
                        break;
                    case '5':
                        AdoDisconnected.DeleteSpesa();

                        break;
                    case '6':
                        AdoDisconnected.SpesaUtente();
                        break;
                    case '7':

                        break;

                    case 'Q':
                        break;
                    default:
                        Console.WriteLine("Scelta non valida");
                        break;
                }
            } while (exits);
        }
    }
}