using System;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(RaycastHit2DVariable), typeof(GameObject), "gameObject", false)]
    public class RaycastHit2DGameObjectVariable : BaseVariableProperty<RaycastHit2D, GameObject>
    {
        public override string PropertyName => "gameObject";
        
#if UNITY_EDITOR
        public override string Description => "The GameObject that was hit.";
#endif

        public override GameObject Value
        {
            get => TargetAs<RaycastHit2DVariable>()?.Value.transform?.gameObject;
            set { }
        }
    }
}
