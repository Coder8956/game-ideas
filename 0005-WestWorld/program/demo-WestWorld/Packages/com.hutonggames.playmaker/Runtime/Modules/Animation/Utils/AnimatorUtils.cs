using UnityEngine;

namespace HutongGames
{
    public class AnimatorUtils
    {
        public static bool IsPlaying(Animator anim, int animLayer, string stateName)
        {
            var stateInfo = anim.GetCurrentAnimatorStateInfo(animLayer);
            return stateInfo.IsName(stateName) && (stateInfo.loop || stateInfo.normalizedTime < 1.0f);
        }
    }
}
