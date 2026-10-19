using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("GameObject")]
    public class RaycastHitGetGameObjectBlock : RaycastHitBlock
    {
        [WriteOnly]
        [Tooltip("Get the GameObject hit by the raycast.")]
        public GameObjectRef GameObject;

        public override void GetInfo(RaycastHit hit) => GameObject.Value = hit.collider ? hit.collider.gameObject : null;
    }
}