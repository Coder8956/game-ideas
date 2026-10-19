using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    public abstract class CollisionBlock : BaseActionBlock
    {
        /// <summary>
        /// Get info from Collision.
        /// </summary>
        public abstract void GetInfo(Collision collision);
    }
}