
using FieldQuest.Services;

namespace FieldQuest.UI;

public class ConsoleMenu
{
    private readonly ObservationService _service;

    public ConsoleMenu(ObservationService service)
    {
        _service = service;
    }

    public void Run()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("================================");
            Console.WriteLine("          FIELDQUEST");
            Console.WriteLine("================================");
            Console.WriteLine("1 - Uj megfigyeles");
            Console.WriteLine("2 - Megfigyelesek listazasa");
            Console.WriteLine("3 - Statisztika");
            Console.WriteLine("0 - Kilepes");
            Console.WriteLine();

            Console.Write("Valassz egy menupontot: ");
            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    AddObservation();
                    break;

                case "2":
                    ShowObservations();
                    break;

                case "3":
                    ShowStatistics();
                    break;

                case "0":
                    running = false;
                    Console.WriteLine("Viszlat, kutato!");
                    break;

                default:
                    Console.WriteLine("Ismeretlen menupont!");
                    break;
            }
        }
    }

    private void AddObservation()
    {
        Console.Write("Faj neve: ");
        string species = Console.ReadLine() ?? "";

        Console.Write("Megfigyelo neve: ");
        string researcher = Console.ReadLine() ?? "";

        if (!int.TryParse(ReadText("Egyedek szama: "), out int count))
        {
            Console.WriteLine("Az egyedszam nem ervenyes egesz szam.");
            return;
        }

        try
        {
            var observation = _service.Add(species, count, researcher);

            Console.WriteLine(
                $"Megfigyeles mentve! Pontszam: {observation.Points}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Hibas adat: {ex.Message}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Nem sikerult menteni: {ex.Message}");
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"Nincs jogosultsag a menteshez: {ex.Message}");
        }
    }

    private void ShowObservations()
    {
        var observations = _service.GetAll();

        Console.WriteLine();
        Console.WriteLine("=== MEGFIGYELESEK ===");

        if (observations.Count == 0)
        {
            Console.WriteLine("Meg nincs rogzitett megfigyeles.");
            return;
        }

        for (int i = 0; i < observations.Count; i++)
        {
            var item = observations[i];

            Console.WriteLine();
            Console.WriteLine($"Azonosito: {i + 1}");
            Console.WriteLine($"Faj: {item.Species}");
            Console.WriteLine($"Egyedek: {item.Count}");
            Console.WriteLine($"Megfigyelo: {item.Researcher}");
            Console.WriteLine($"Pontok: {item.Points}");
        }
    }

    private void ShowStatistics()
    {
        Console.WriteLine();
        Console.WriteLine("=== STATISZTIKA ===");
        Console.WriteLine($"Megfigyelesek: {_service.GetAll().Count}");
        Console.WriteLine($"Osszes egyed: {_service.GetTotalIndividuals()}");
        Console.WriteLine($"Osszes pont: {_service.GetTotalPoints()}");
    }

    private string ReadText(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine() ?? "";
    }
}
