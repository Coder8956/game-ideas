using System;
using HutongGames.PlayMaker.Actions.EventSystems;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(RaycastResultVariable), typeof(float), "distance", false)]
    public class RaycastResultDistanceVariable : BaseVariableProperty<RaycastResult, float>
    {
        public override string PropertyName => "distance";
        
#if UNITY_EDITOR
        public override string Description => "Distance to the hit.";
#endif

        public override float Value
        {
            get => TargetAs<RaycastResultVariable>()?.Value.distance ?? 0;
            set { }
        }
    }
}
