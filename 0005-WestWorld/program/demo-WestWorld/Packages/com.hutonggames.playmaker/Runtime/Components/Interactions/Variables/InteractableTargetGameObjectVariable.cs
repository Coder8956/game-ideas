using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(InteractableVariable), typeof(GameObject), "targetGameObject", false)]
    public class InteractableTargetGameObjectVariable : BaseVariableProperty<Interactable, GameObject>
    {
        public override string PropertyName => "targetGameObject";

#if UNITY_EDITOR
        public override string Description => "The target GameObject, falling back to the Interactable's GameObject when not explicitly assigned.";
#endif

        public override GameObject Value
        {
            get => TargetAs<InteractableVariable>()?.Value ? TargetAs<InteractableVariable>().Value.TargetGameObject : null;
            set { }
        }
    }
}
