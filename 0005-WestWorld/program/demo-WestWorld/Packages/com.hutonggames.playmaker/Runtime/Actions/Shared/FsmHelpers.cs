using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    public static class FsmHelpers
    {
        public static BaseFsmComponent FindFsmComponent(GameObject go, StringVar fsmName)
        {
            // If a name is not specified, get the first
            // FsmComponent on the GameObject
            if (fsmName.IsNone || string.IsNullOrEmpty(fsmName.Value))
            {
                return go.GetComponent<BaseFsmComponent>();
            }

            // Otherwise, find the FsmComponent with the specified name
            var components = go.GetComponents<BaseFsmComponent>();
            foreach (var fsmComponent in components)
            {
                if (!fsmComponent) continue;
                if (fsmComponent.Fsm?.Name == fsmName.Value)
                {
                    return fsmComponent;
                }
            }

            // No FsmComponent found
            return null;
        }

        public static BaseFsmComponent FindFsmComponentInParent(GameObject go, StringVar fsmName, BoolVar includeInactive)
        {
            if (fsmName.IsNone || string.IsNullOrEmpty(fsmName.Value))
            {
                return go.GetComponentInParent<BaseFsmComponent>(includeInactive.Value);
            }

            var components = go.GetComponentsInParent<BaseFsmComponent>(includeInactive.Value);
            foreach (var fsmComponent in components)
            {
                if (!fsmComponent) continue;
                if (fsmComponent.Fsm?.Name == fsmName.Value)
                {
                    return fsmComponent;
                }
            }

            return null;
        }
    }
}
