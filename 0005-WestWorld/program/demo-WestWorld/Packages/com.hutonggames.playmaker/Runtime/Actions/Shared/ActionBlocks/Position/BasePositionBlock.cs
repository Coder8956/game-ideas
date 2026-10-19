using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    /// <summary>
    /// Base class for action blocks that define a position.
    /// </summary>
    /// <remarks>
    /// Note: Variants are generally shown in a menu where
    /// the context is obvious. E.g., LineCast From [Position].
    /// So the DisplayName (also used in menus) can be short.
    /// </remarks>
    [System.Serializable]
    public abstract class BasePositionBlock : BaseActionBlock
    {
        /// <summary>
        /// Get the world position defined by the block.
        /// </summary>
        public abstract Vector3 GetWorldPosition();

        /// <summary>
        /// Set the world position for this block.
        /// This is used less often by the parent action,
        /// but this "round trip" method lets us more easily
        /// make editing gizmos in the scene view.
        /// </summary>
        public abstract void SetWorldPosition(Vector3 position);
    }
}
