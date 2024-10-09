//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherEffectSetups;

    public static Entitas.IMatcher<GameEntity> EffectSetups {
        get {
            if (_matcherEffectSetups == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.EffectSetups);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherEffectSetups = matcher;
            }

            return _matcherEffectSetups;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Code.Gameplay.Features.Armaments.EffectSetups effectSetups { get { return (Code.Gameplay.Features.Armaments.EffectSetups)GetComponent(GameComponentsLookup.EffectSetups); } }
    public System.Collections.Generic.List<Code.Gameplay.Features.Effects.EffectSetup> EffectSetups { get { return effectSetups.Value; } }
    public bool hasEffectSetups { get { return HasComponent(GameComponentsLookup.EffectSetups); } }

    public GameEntity AddEffectSetups(System.Collections.Generic.List<Code.Gameplay.Features.Effects.EffectSetup> newValue) {
        var index = GameComponentsLookup.EffectSetups;
        var component = (Code.Gameplay.Features.Armaments.EffectSetups)CreateComponent(index, typeof(Code.Gameplay.Features.Armaments.EffectSetups));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceEffectSetups(System.Collections.Generic.List<Code.Gameplay.Features.Effects.EffectSetup> newValue) {
        var index = GameComponentsLookup.EffectSetups;
        var component = (Code.Gameplay.Features.Armaments.EffectSetups)CreateComponent(index, typeof(Code.Gameplay.Features.Armaments.EffectSetups));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveEffectSetups() {
        RemoveComponent(GameComponentsLookup.EffectSetups);
        return this;
    }
}
