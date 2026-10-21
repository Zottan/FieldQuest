
using System.Text.Json;
using FieldQuest.Models;

namespace FieldQuest.Services;

public class JsonObservationRepository : IObservationRepository
{
    private readonly string _filePath;

    private readonly JsonSerializerOptions _jsonOptions = new()
    {
        WriteIndented = true
    };

    public JsonObservationRepository(string filePath)
    {
        _filePath = filePath;
    }

    public List<Observation> Load()
    {
        if (!File.Exists(_filePath))
        {
            return new List<Observation>();
        }

        string json = File.ReadAllText(_filePath);

        return JsonSerializer.Deserialize<List<Observation>>(
            json, _jsonOptions
        ) ?? new List<Observation>();
    }

    public void Save(List<Observation> observations)
    {
        string json = JsonSerializer.Serialize(
            observations, _jsonOptions
        );

        File.WriteAllText(_filePath, json);
    }
}
