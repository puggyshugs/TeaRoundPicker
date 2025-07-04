using System;
using TeaRoundPicker.Domain.Models;

namespace TeaRoundPicker.Services.Cache.Interfaces;

public interface ICache
{
    Participant? GetParticipant(string key);
    List<Participant> GetAllParticipants();
    void SetParticipant(string key, Participant participant);
}
