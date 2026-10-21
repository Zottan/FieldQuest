
using FieldQuest.Models;

namespace FieldQuest.Services;

public interface IObservationRepository
{
    List<Observation> Load();
    void Save(List<Observation> observations);
}
