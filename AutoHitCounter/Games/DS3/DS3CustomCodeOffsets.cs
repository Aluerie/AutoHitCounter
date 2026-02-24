// 

namespace AutoHitCounter.Games.DS3;

public static class DS3CustomCodeOffsets
{
    public static nint Base;

    //Flags

    public const int Hit = 0x10;
    public const int CheckPlayerDead = 0x20;

    public const int HitCode = 0x100;
    public const int LethalFall = 0x400;
}