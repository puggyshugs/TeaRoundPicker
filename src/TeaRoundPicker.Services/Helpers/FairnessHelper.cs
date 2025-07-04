using System.Security.Cryptography;

namespace TeaRoundPicker.Services.Helpers;

public static class FairnessHelper
{
    public static T PickRandom<T>(List<T> items)
    {
        if (items == null || items.Count == 0)
            throw new ArgumentException("List must not be empty.");

        var index = RandomNumberGenerator.GetInt32(items.Count);
        return items[index];
    }
}
