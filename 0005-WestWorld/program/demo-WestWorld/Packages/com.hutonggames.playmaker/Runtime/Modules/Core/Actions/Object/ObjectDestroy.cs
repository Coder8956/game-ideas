using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Object)]
    [ActionDescription("Removes a GameObject, component or asset.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Object.Destroy.html")]
    public class ObjectDestroy : BaseAction
    {
        [Tooltip("The Object to destroy.")]
        [BaseType(typeof(Object))]
        public ObjectVar Object;

        [Tooltip("Optional delay in seconds.")]
        public FloatVar Delay;
        
        public override void Execute()
        {
            if (Object.Value == null) return;
            UnityEngine.Object.Destroy(Object.Value, Delay.Value);
        }
        
        public override string GetSummary()
        {
            return "Destroy {Object} " + (Delay.IsNotDefault() ? "after {Delay:seconds}" : "");
        }
    }
}