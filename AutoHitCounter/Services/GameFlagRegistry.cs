using System.Collections.Generic;

namespace AutoHitCounter.Services;

public static class GameFlagRegistry
{
    private static readonly Dictionary<string, IReadOnlyList<(string Key, string DisplayName)>> _flags = new()
    {
        ["Dark Souls Remastered"] = [],
        ["Dark Souls 2 Vanilla"]  = [],
        ["Dark Souls 2 Scholar"]  = [
            ("ignore_shulva_spikes", "Ignore Shulva Spikes"),
        ],
        ["Dark Souls 3"]          = [],
        ["Sekiro"]                = [],
        ["Elden Ring"]            = [],
    };

    public static IReadOnlyList<(string Key, string DisplayName)> GetFlags(string gameName)
        => _flags.TryGetValue(gameName, out var flags) ? flags : [];
}
