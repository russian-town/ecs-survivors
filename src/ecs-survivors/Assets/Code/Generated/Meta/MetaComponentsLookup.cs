//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentLookupGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public static class MetaComponentsLookup {

    public const int Destructed = 0;
    public const int Duration = 1;
    public const int GoldGainBoost = 2;
    public const int Tick = 3;
    public const int Gold = 4;
    public const int GoldPerSecond = 5;
    public const int Storage = 6;

    public const int TotalComponents = 7;

    public static readonly string[] componentNames = {
        "Destructed",
        "Duration",
        "GoldGainBoost",
        "Tick",
        "Gold",
        "GoldPerSecond",
        "Storage"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Code.Common.Destructed),
        typeof(Code.Meta.Features.Simulation.Duration),
        typeof(Code.Meta.Features.Simulation.GoldGainBoost),
        typeof(Code.Meta.Features.Simulation.Tick),
        typeof(Code.Meta.Features.Storage.Gold),
        typeof(Code.Meta.Features.Storage.GoldPerSecond),
        typeof(Code.Meta.Features.Storage.Storage)
    };
}
