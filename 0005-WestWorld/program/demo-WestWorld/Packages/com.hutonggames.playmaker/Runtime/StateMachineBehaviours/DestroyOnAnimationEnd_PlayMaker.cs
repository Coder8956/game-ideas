using UnityEngine;
// ReSharper disable InconsistentNaming
// ReSharper disable RequiredBaseTypesIsNotInherited

namespace HutongGames.PlayMaker.StateMachineBehaviours
{
    [AddComponentMenu("PlayMaker/Destroy On Animation End")]
    public class DestroyOnAnimationEnd_PlayMaker : StateMachineBehaviour
    {
        [Tooltip("Delay in seconds before destroying the GameObject (0 = destroy immediately)")]
        public float destroyDelay;
    
        private bool _hasTriggeredDestroy;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // Reset the flag when entering the state
            _hasTriggeredDestroy = false;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // Check if animation has completed and we haven't already triggered destroy
            if (!_hasTriggeredDestroy && stateInfo.normalizedTime >= 1.0f)
            {
                _hasTriggeredDestroy = true;
            
                var targetObject = animator.gameObject;
            
                if (destroyDelay > 0f)
                {
                    Destroy(targetObject, destroyDelay);
                }
                else
                {
                    Destroy(targetObject);
                }
            }
        }
    }
}