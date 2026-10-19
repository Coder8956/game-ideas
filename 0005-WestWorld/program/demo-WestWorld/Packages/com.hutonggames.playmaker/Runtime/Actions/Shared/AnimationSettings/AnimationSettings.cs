using UnityEngine;

namespace HutongGames.PlayMaker
{
    [System.Serializable]
    public struct AnimationSettings
    {
        [Min(0f)]
        public float Duration;

        public AnimationCurve Ease;

        public bool UseUnscaledTime;

        public static AnimationSettings Default => new()
        {
            Duration = 0.2f,
            Ease = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f),
            UseUnscaledTime = true
        };
    }
}