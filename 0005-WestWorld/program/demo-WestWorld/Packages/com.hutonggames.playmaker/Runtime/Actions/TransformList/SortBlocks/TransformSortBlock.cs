using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    public abstract class TransformSortBlock : BaseActionBlock
    {
        public abstract bool TryGetSortValue(Transform transform, out object value);
    }
}