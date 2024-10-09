//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherRotateAlignedAlongDirection;

    public static Entitas.IMatcher<GameEntity> RotateAlignedAlongDirection {
        get {
            if (_matcherRotateAlignedAlongDirection == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.RotateAlignedAlongDirection);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherRotateAlignedAlongDirection = matcher;
            }

            return _matcherRotateAlignedAlongDirection;
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

    static readonly Code.Gameplay.Features.Movement.RotateAlignedAlongDirection rotateAlignedAlongDirectionComponent = new Code.Gameplay.Features.Movement.RotateAlignedAlongDirection();

    public bool isRotateAlignedAlongDirection {
        get { return HasComponent(GameComponentsLookup.RotateAlignedAlongDirection); }
        set {
            if (value != isRotateAlignedAlongDirection) {
                var index = GameComponentsLookup.RotateAlignedAlongDirection;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : rotateAlignedAlongDirectionComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}