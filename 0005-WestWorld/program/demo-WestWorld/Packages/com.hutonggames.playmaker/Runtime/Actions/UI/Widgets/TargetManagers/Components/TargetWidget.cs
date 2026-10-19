using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker.UI
{
    /// <summary>
    /// Attached to a spawned UI widget instance (offscreen indicator, minimap icon, etc.).
    /// Stores the target being represented so other scripts/FSMS on this GameObject
    /// can query that info without knowing about the specific manager type.
    /// </summary>
    [AddComponentMenu("PlayMaker/Widgets/Target Object")]
    [Icon(Strings.EditorIconsPath + "TargetIndicatorIcon.png")]
    [HelpURL("https://hutonggames.com/playmaker/docs/guides/ui-widgets/target-managers/")]
    public sealed class TargetWidget : MonoBehaviour
    {
        /// <summary>
        /// The manager that spawned/controls this widget.
        /// Could be OffscreenIndicator, OnscreenTargets, Minimap, etc.
        /// Exposed as Component to avoid hard-coding a specific type.
        /// </summary>
        public Component Manager { get; internal set; }

        /// <summary>
        /// The world-space target this widget represents.
        /// </summary>
        public Transform Target { get; internal set; }

        /// <summary>
        /// Style id tag passed in by the manager (optional).
        /// </summary>
        public int StyleId { get; internal set; }

        /// <summary>
        /// Called by the manager after instantiation.
        /// </summary>
        internal void Initialize(Component manager, Transform target, int styleId)
        {
            Manager = manager;
            Target  = target;
            StyleId = styleId;
        }

        /// <summary>
        /// Optional: called by the manager when this widget is removed.
        /// </summary>
        internal void OnRemoved()
        {
            // You can trigger cleanup, events, etc. here if needed.
            // For now we just clear references.
            // Manager = null;
            // Target  = null;
        }
    }
}