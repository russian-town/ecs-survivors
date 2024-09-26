using Entitas;
using UnityEngine;

namespace Code.Gameplay.Input
{
    [Game] public class Input : IComponent { }
    [Game] public class Axis : IComponent { public Vector2 Value; }
}