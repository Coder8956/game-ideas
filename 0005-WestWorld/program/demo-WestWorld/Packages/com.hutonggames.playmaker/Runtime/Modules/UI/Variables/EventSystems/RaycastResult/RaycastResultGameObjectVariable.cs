using System;
using HutongGames.PlayMaker.Actions.EventSystems;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(RaycastResultVariable), typeof(GameObject), "gameObject", false)]
    public class RaycastResultGameObjectVariable : BaseVariableProperty<RaycastResult, GameObject>
    {
        public override string PropertyName => "gameObject";
        
#if UNITY_EDITOR
        public override string Description => "The GameObject hit by the raycast.";
#endif

        public override GameObject Value
        {
            get => TargetAs<RaycastResultVariable>()?.Value.gameObject;
            set { }
        }
    }
}
