using System;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(BoundsIntVariable), typeof(Rect), "toRectXY")]
    public class BoundsIntToRectXYVariable : BaseVariableProperty<BoundsInt, Rect>
    {
        public override string PropertyName => "toRectXY";
        
#if UNITY_EDITOR
        public override string Description => "Gets a Rect from the XY Plane.";
#endif

        private BoundsIntVariable BoundsIntVariable => TargetAs<BoundsIntVariable>();
        public override Rect Value
        {
            get
            {
                if (BoundsIntVariable == null) return default;
                var boundsInt = BoundsIntVariable.Value;
                return new Rect(boundsInt.min.x, boundsInt.min.y, boundsInt.size.x, boundsInt.size.y);
            }
            set
            {
                if (BoundsIntVariable == null) return;
                var boundsInt = BoundsIntVariable.Value;
                boundsInt.min = new Vector3Int((int) value.x,(int) value.y, 0);
                boundsInt.size = new Vector3Int((int) value.width, (int) value.height, 0);
                BoundsIntVariable.Value = boundsInt;   
            }
        }
    }
}
