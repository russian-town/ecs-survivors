using UnityEngine;

namespace Code.Meta.Features.AfkGain.Configs
{
    [CreateAssetMenu(fileName = "AfkGainConfig", menuName = "ECS Survivors/AFK Gain", order = 0)]
    public class AfkGainConfig : ScriptableObject
    {
        public float GoldPerSeconds;
    }
}
