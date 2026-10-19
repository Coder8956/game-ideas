using System;
using HutongGames.PlayMaker.Actions.EventSystems;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(RaycastResultVariable), typeof(Vector3), "worldPosition", false)]
    public class RaycastResultWorldPositionVariable : BaseVariableProperty<RaycastResult, Vector3>
    {
        public override string PropertyName => "worldPosition";
        
#if UNITY_EDITOR
        public override string Description => "The world position where the raycast hit.";
#endif

        public override Vector3 Value
        {
            get => TargetAs<RaycastResultVariable>()?.Value.worldPosition ?? Vector3.zero;
            set { }
        }
    }
}
