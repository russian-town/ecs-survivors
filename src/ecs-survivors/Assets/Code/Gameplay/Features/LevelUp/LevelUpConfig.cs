using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.LevelUp
{
    [CreateAssetMenu(fileName = "LevelUpConfig", menuName = "ECS Survivors/LevelUp Config")]
    public class LevelUpConfig : ScriptableObject
    {
        public int MaxLevel;
        public List<float> ExperienceForLevel;
    }
}
