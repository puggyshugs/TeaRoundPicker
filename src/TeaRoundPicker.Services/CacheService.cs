using TeaRoundPicker.Domain.Enums;
using TeaRoundPicker.Domain.Models;
using TeaRoundPicker.Services.Cache.Interfaces;
using TeaRoundPicker.Services.Interfaces;

namespace TeaRoundPicker.Services;

public class CacheService : ICacheService
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
            SuccessMessage = SuccessMessages.ParticipantNotFound.ToString()
        };

        return participant;
    }

    public string CreateParticipant(string name)
    {

        var participant = new Participant
        {
            Name = name,
            SuccessMessage = SuccessMessages.ParticipantCreatedSuccessfully.ToString()
        };
        _cache.SetParticipant(name, participant);

        return SuccessMessages.ParticipantCreatedSuccessfully.ToString();
    }

    public string CreateParticipants(List<string> names)
    {
        var participants = new Dictionary<string, Participant>();
        if (!AreAllNamesUnique(names))
        {
            return SuccessMessages.DuplicateParticipantName.ToString();
        }

        foreach (var name in names)
        {
            var participant = new Participant
            {
                Name = name,
                SuccessMessage = SuccessMessages.ParticipantsCreatedSuccessfully.ToString()
            };
            participants[name] = participant;
        }
        _cache.SetMultipleParticipants(participants);

        return SuccessMessages.ParticipantsCreatedSuccessfully.ToString();
    }

    private bool AreAllNamesUnique(List<string> names)
    {
        var existingNames = _cache.GetAllParticipants()
                                  .Select(p => p.Name);

        foreach (var name in names)
        {
            if (existingNames.Contains(name))
            {
                return false;
            }
        }
        return true;
    }
}
