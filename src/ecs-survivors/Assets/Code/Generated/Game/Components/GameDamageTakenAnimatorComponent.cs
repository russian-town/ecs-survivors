//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherDamageTakenAnimator;

    public static Entitas.IMatcher<GameEntity> DamageTakenAnimator {
        get {
            if (_matcherDamageTakenAnimator == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.DamageTakenAnimator);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDamageTakenAnimator = matcher;
            }

            return _matcherDamageTakenAnimator;
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

    public Code.Gameplay.Common.DamageTakenAnimator damageTakenAnimator { get { return (Code.Gameplay.Common.DamageTakenAnimator)GetComponent(GameComponentsLookup.DamageTakenAnimator); } }
    public Code.Gameplay.Common.Visuals.IDamageTakenAnimator DamageTakenAnimator { get { return damageTakenAnimator.Value; } }
    public bool hasDamageTakenAnimator { get { return HasComponent(GameComponentsLookup.DamageTakenAnimator); } }

    public GameEntity AddDamageTakenAnimator(Code.Gameplay.Common.Visuals.IDamageTakenAnimator newValue) {
        var index = GameComponentsLookup.DamageTakenAnimator;
        var component = (Code.Gameplay.Common.DamageTakenAnimator)CreateComponent(index, typeof(Code.Gameplay.Common.DamageTakenAnimator));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceDamageTakenAnimator(Code.Gameplay.Common.Visuals.IDamageTakenAnimator newValue) {
        var index = GameComponentsLookup.DamageTakenAnimator;
        var component = (Code.Gameplay.Common.DamageTakenAnimator)CreateComponent(index, typeof(Code.Gameplay.Common.DamageTakenAnimator));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveDamageTakenAnimator() {
        RemoveComponent(GameComponentsLookup.DamageTakenAnimator);
        return this;
    }
}
