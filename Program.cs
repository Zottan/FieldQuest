
using FieldQuest.Services;
using FieldQuest.UI;

string filePath = Path.Combine(
    Environment.CurrentDirectory,
    "fieldquest.json");

IObservationRepository repository =
    new JsonObservationRepository(filePath);

var service = new ObservationService(repository);

var menu = new ConsoleMenu(service);

menu.Run();
