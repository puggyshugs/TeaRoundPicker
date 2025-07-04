using TeaRoundPicker.Domain.Models;

namespace TeaRoundPicker.Services.Interfaces;

public interface ICacheService
{
    List<Participant> GetAllParticipants();
    Participant GetParticipant(string key);
    string CreateParticipant(string name);
    string CreateParticipants(List<string> names);
}
