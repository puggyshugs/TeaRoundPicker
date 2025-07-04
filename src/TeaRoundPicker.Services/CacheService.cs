using TeaRoundPicker.Domain.Enums;
using TeaRoundPicker.Domain.Models;
using TeaRoundPicker.Services.Cache.Interfaces;

namespace TeaRoundPicker.Services;

public class CacheService
{
    private readonly ICache _cache;

    public CacheService(ICache cache)
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

    public string CreateParticipants(List<string> names)
    {
        var participants = new Dictionary<string, Participant>();

        foreach (var name in names)
        {
            var participant = new Participant
            {
                Name = name,
                CreatedAt = DateTime.UtcNow
            };
            participants[name] = participant;
        }
        _cache.SetMultipleParticipants(participants);

        return SuccessMessages.ParticipantsCreatedSuccessfully.ToString();
    }
}
