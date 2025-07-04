using TeaRoundPicker.Domain.Models;
using TeaRoundPicker.Services.Cache.Interfaces;

namespace TeaRoundPicker.Services.Cache;

public class Cache : ICache
{
    private readonly Dictionary<string, Participant> _cachedParticipants = new();

    public Participant? GetParticipant(string key)
    {
        if (_cachedParticipants.TryGetValue(key, out var participant))
        {
            return participant;
        }
        return null;
    }

    public List<Participant> GetAllParticipants()
    {
        return _cachedParticipants.Values.ToList();
    }

    public void SetParticipant(string key, Participant participant)
    {
        _cachedParticipants[key] = participant;
    }
}