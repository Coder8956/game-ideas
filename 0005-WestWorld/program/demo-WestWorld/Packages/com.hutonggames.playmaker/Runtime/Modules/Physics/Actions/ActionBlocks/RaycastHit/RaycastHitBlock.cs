using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    public abstract class RaycastHitBlock : BaseActionBlock
    {
        /// <summary>
        /// Get info from RaycastHit.
        /// </summary>
        public abstract void GetInfo(RaycastHit hit);
    }
}