using TeaRoundPicker.Domain.Models;

namespace TeaRoundPicker.Services.Interfaces;

public interface ICacheService
{
    Participant GetParticipant(string key);
    string CreateParticipant(string name);
}
