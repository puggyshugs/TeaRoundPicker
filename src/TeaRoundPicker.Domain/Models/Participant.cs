using System;

namespace TeaRoundPicker.Domain.Models;

public class Participant
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public List<Selection> Selections { get; set; } = new();
}

