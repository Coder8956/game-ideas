using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    /// <summary>
    /// Base class for action blocks that define a direction (e.g., DebugDrawRay).
    /// </summary>
    [System.Serializable]
    public abstract class BaseDirectionBlock : BaseActionBlock
    {
        public Vector3 StartPosition { get; private set;}
        
        public void SetStartPosition(Vector3 startPosition)
        {
            StartPosition = startPosition;
        }
        
        /// <summary>
        /// Get the direction vector defined by the block.
        /// </summary>
        public abstract Vector3 GetDirection();

        public virtual void SetDirection(Vector3 worldPosition) {}
    }
}
