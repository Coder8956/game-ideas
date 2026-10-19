using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    /// <summary>
    /// Base class for action blocks that define a rotation.
    /// </summary>
    [System.Serializable]
    public abstract class BaseRotationBlock : BaseActionBlock
    {
        /// <summary>
        /// Get the rotation defined by the block.
        /// </summary>
        public abstract Quaternion GetRotation();

        /// <summary>
        /// Set the rotation for this block.
        /// This is used less often by the parent action,
        /// but this "round trip" method lets us more easily
        /// make editing gizmos in the scene view.
        /// </summary>
        /// <param name="rotation"></param>
        public abstract void SetRotation(Quaternion rotation);
    }
}
