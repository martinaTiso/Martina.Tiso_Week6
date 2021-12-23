// See https://aka.ms/new-console-template for more information
using GestioneSpese;

Console.WriteLine("Connessione stabilita!");
AdoConnected.ConnectionDemo();
Menu.Start();

QuerySyntax();
LambdaSyntax();




static List<Spesa> GetSpesa()
{
    var spese = new List<Spesa>()
            {
                new Spesa() {
                    Id = 1,
                    Data = new DateTime(2021,12,20),
                    Descrizione = "Pagamento luce",
                    Utente = "Martina",
                    Importo =50.02m,
                    Approvata = true,
                    IdCateg = 1,


                },
                new Spesa() {
                    Id = 2,
                    Data = new DateTime(2021,11,20),
                    Descrizione = "Pagemento affitto mese aprile",
                    Utente = "Anna",
                    Importo = 400.02m,
                    Approvata=false,
                    IdCateg = 2,
                },
        new Spesa() {
                    Id = 3,
                    Data = new DateTime(2021,10,20),
                    Descrizione = "Pagemento bollo mese april",
                    Utente = "Serena",
                    Importo = 135.23m,
                    Approvata=true,
                    IdCateg = 3,
                },
        new Spesa() {
                    Id = 4,
                    Data = new DateTime(2021,12,20),
                    Descrizione = "Pagemento mutuo mese Dicembre",
                    Utente = "Davide",
                    Importo = 512.02m,
                    Approvata=true,
                    IdCateg = 4,
                }
};
        
    return spese;
}



static void QuerySyntax()
{
    var spese = GetSpesa();

    var spesaOver100 = from spesa in spese
                       where spesa.Importo >= 100
                       select spesa;
    foreach (var spesa in spesaOver100)
    {
        Console.WriteLine($"Id {spesa.Id} - Importo {spesa.Importo}");
    }


    var bookDicembre = from spesa in spese
                       where spesa.Data.Month == 12
                       select spesa;




    foreach(var spesa in bookDicembre)
    {
        Console.WriteLine($"Id{spesa.Id} - Descrizione{spesa.Descrizione}");

    }


    var orderedDataImporto = from spesa in spese
                           orderby spesa.Data ascending, spesa.Importo descending
                           select spesa;


    foreach (var sp in orderedDataImporto)
    {
        Console.WriteLine($"ID: {sp.Data} - Voto: {sp.Importo}");
    }

}



 static void LambdaSyntax()
{
    var spese = GetSpesa();



    var spesaOver100 = spese.Where(x => x.Importo > 100);
   
    foreach (var item in spesaOver100)
    {
        Console.WriteLine($"{item.Id} - {item.Importo} - ");
    }


    var bookDicembre = spese.Where(spesa => spesa.Data.Month == 12).Select(spesa => spesa.Id  );
    foreach (var item in bookDicembre)
    {
        Console.WriteLine($"Title: {item}");
    }



    var orderedDataImporto = spese.OrderBy(s => s.Importo).ThenByDescending(r => r.Data);
    foreach (var sp in orderedDataImporto)
    {
        Console.WriteLine($"{sp.Id} - {sp.Importo} - {sp.Data}");
    }
}