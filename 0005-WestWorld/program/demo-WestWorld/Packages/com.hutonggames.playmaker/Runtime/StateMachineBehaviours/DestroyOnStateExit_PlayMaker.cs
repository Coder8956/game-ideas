using UnityEngine;
// ReSharper disable InconsistentNaming
// ReSharper disable RequiredBaseTypesIsNotInherited

namespace HutongGames.PlayMaker.StateMachineBehaviours
{
    [AddComponentMenu("PlayMaker/Destroy On State Exit")]
    public class DestroyOnStateExit_PlayMaker : StateMachineBehaviour
    {
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Destroy(animator.gameObject);
        }
    }
}