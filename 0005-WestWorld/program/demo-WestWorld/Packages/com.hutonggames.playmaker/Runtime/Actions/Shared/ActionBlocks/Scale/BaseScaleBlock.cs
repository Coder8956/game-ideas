using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    public abstract class BaseScaleBlock : BaseActionBlock
    {
        public abstract Vector3 GetScale();

        public abstract void SetScale(Vector3 scale);
    }
}