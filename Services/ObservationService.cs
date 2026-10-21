
using FieldQuest.Models;

namespace FieldQuest.Services;

public class ObservationService
{
    private readonly IObservationRepository _repository;
    private readonly List<Observation> _observations;

    public ObservationService(IObservationRepository repository)
    {
        _repository = repository;
        _observations = _repository.Load();
    }

    public IReadOnlyList<Observation> GetAll()
    {
        return _observations.AsReadOnly();
    }

    public Observation Add(string species, int count, string researcher)
    {
        if (string.IsNullOrWhiteSpace(species))
            throw new ArgumentException("A faj neve kotelezo.");

        if (string.IsNullOrWhiteSpace(researcher))
            throw new ArgumentException("A megfigyelo neve kotelezo.");

        if (count <= 0)
            throw new ArgumentOutOfRangeException(
                nameof(count), "Az egyedszamnak pozitivnak kell lennie.");

        var observation = new Observation(species, count, researcher);

        _observations.Add(observation);

        try
        {
            _repository.Save(_observations);
        }
        catch
        {
            _observations.Remove(observation);
            throw;
        }

        return observation;
    }

    public int GetTotalIndividuals()
    {
        return _observations.Sum(item => item.Count);
    }

    public int GetTotalPoints()
    {
        return _observations.Sum(item => item.Points);
    }
}
