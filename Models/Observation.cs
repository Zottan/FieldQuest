
namespace FieldQuest.Models;

public class Observation
{
    public string Species { get; }
    public int Count { get; }
    public string Researcher { get; }

    public int Points => Math.Min(Count * 10, 100);

    public Observation(string species, int count, string researcher)
    {
        Species = species;
        Count = count;
        Researcher = researcher;
    }
}
