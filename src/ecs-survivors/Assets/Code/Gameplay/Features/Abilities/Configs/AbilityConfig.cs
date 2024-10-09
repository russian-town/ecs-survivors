﻿using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Configs
{
    [CreateAssetMenu(menuName = "ECS Survivors", fileName = "Ability Config", order = 0)]
    public class AbilityConfig : ScriptableObject
    {
        public AbilityId AbilityId;
        public List<AbilityLevel> Levels;
    }
}