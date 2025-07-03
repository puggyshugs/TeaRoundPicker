using TeaRoundPicker.Domain.Enums;
using TeaRoundPicker.Domain.Models;

namespace TeaRoundPicker.Services;

public class CacheService
{
    private readonly Cache _cache;

    public CacheService(Cache cache)
    {
        _cache = cache;
    }

    public List<Participant> GetAllParticipants()
    {
        return _cache.GetAllParticipants();
    }

    public Participant GetParticipant(string key)
    {
        var participant = _cache.GetParticipant(key) ?? new Participant
        {
            Name = string.Empty,
            CreatedAt = DateTime.UtcNow,
            SuccessMessage = SuccessMessages.ParticipantNotFound.ToString()
        };

        return participant;
    }

    public string CreateParticipant(string name)
    {
        var participant = new Participant
        {
            Name = name,
            CreatedAt = DateTime.UtcNow
        };
        _cache.SetParticipant(name, participant);

        return SuccessMessages.ParticipantCreatedSuccessfully.ToString();
    }
}
