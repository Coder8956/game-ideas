using System;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(BoundsIntVariable), typeof(RectInt), "toRectIntXY")]
    public class BoundsIntToRectIntXYVariable : BaseVariableProperty<BoundsInt, RectInt>
    {
        public override string PropertyName => "toRectIntXY";
        
#if UNITY_EDITOR
        public override string Description => "Gets a RectInt from the XY Plane.";
#endif

        private BoundsIntVariable BoundsIntVariable => TargetAs<BoundsIntVariable>();
        public override RectInt Value
        {
            get
            {
                if (BoundsIntVariable == null) return default;
                var boundsInt = BoundsIntVariable.Value;
                return new RectInt(boundsInt.min.x, boundsInt.min.y, boundsInt.size.x, boundsInt.size.y);
            }
            set
            {
                if (BoundsIntVariable == null) return;
                var boundsInt = BoundsIntVariable.Value;
                boundsInt.min = new Vector3Int(value.x, value.y, 0);
                boundsInt.size = new Vector3Int(value.width, value.height, 0);
                BoundsIntVariable.Value =boundsInt;   
            }
        }
    }
}
