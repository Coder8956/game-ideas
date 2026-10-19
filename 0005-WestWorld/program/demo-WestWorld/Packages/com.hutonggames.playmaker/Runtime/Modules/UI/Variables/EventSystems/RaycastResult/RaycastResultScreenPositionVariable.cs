using System;
using HutongGames.PlayMaker.Actions.EventSystems;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(RaycastResultVariable), typeof(Vector2), "screenPosition", false)]
    public class RaycastResultScreenPositionVariable : BaseVariableProperty<RaycastResult, Vector2>
    {
        public override string PropertyName => "screenPosition";
        
#if UNITY_EDITOR
        public override string Description => "The screen position of the event.";
#endif

        public override Vector2 Value
        {
            get => TargetAs<RaycastResultVariable>()?.Value.screenPosition ?? Vector2.zero;
            set { }
        }
    }
}
