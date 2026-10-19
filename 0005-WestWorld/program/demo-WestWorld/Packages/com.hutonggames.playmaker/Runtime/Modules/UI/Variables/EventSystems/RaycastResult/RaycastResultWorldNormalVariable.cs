using System;
using HutongGames.PlayMaker.Actions.EventSystems;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(RaycastResultVariable), typeof(Vector3), "worldNormal", false)]
    public class RaycastResultWorldNormalVariable : BaseVariableProperty<RaycastResult, Vector3>
    {
        public override string PropertyName => "worldNormal";
        
#if UNITY_EDITOR
        public override string Description => "The world normal where the raycast hit.";
#endif

        public override Vector3 Value
        {
            get => TargetAs<RaycastResultVariable>()?.Value.worldNormal ?? Vector3.zero;
            set { }
        }
    }
}
