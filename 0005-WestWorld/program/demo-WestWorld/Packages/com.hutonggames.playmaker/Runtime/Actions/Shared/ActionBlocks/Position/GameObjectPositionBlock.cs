using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    /// <summary>
    /// Defines a position using a target GameObject.
    /// </summary>
    [Serializable]
    [DisplayOrder(3)]
    [Tooltip("Use the position of a GameObject.")]
    public class GameObjectPositionBlock : BasePositionBlock
    {
        [Tooltip("GameObject position.")]
        public GameObjectVar GameObject;

        public override bool IsValid => GameObject.HasValue();
        
        public override Vector3 GetWorldPosition() => GameObject.Value.transform.position;

        public override void SetWorldPosition(Vector3 position) => GameObject.Value.transform.position = position;

        public override string GetSummary() => "{GameObject}";
    }
}