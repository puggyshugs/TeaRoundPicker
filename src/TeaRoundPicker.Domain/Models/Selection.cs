using System;

namespace TeaRoundPicker.Domain.Models;

public class Selection
{
    public int Id { get; set; }
    public int ParticipantId { get; set; }
    public DateTime SelectedAt { get; set; } = DateTime.UtcNow;

    public Participant Participant { get; set; } = null!;
}
