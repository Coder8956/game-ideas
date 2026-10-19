using System;
using JetBrains.Annotations;
using UnityEngine;
using Object = UnityEngine.Object;

namespace HutongGames.PlayMaker.Actions
{
#if UNITY_6000_5_OR_NEWER
    [Obsolete("Object.GetInstanceID is deprecated in Unity 6.5+. A replacement action using EntityId is required.")]
#endif
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Object)]
#if UNITY_6000_4_OR_NEWER
    [ActionDescription("Get the instance ID of an Object. Note: on Unity 6.4+ this uses the legacy GetInstanceID API and may be removed in a future update.")]
#else
    [ActionDescription("Get the instance ID of an Object.")]
#endif
    [HelpURL("https://docs.unity3d.com/ScriptReference/Object.GetInstanceID.html")]
    public class ObjectGetInstanceID : BaseAction
    {
        [Tooltip("The Object.")]
        [BaseType(typeof(Object))]
        public ObjectVar Object;
        
        [Tooltip("Store the instance ID in an Integer variable")]
        public IntegerRef StoreResult;
        
        public override bool CanExecute()
        {
#if UNITY_6000_5_OR_NEWER
            return false;
#else
            return CheckParameters(Object, StoreResult);
#endif
        }
        
        public override void Execute()
        {
#if !UNITY_6000_5_OR_NEWER
            if (!RuntimeCheck(Object)) return;
#pragma warning disable CS0618, CS0619
            StoreResult.Value = Object.Value.GetInstanceID();
#pragma warning restore CS0618, CS0619
#endif
        }
        
        public override string GetSummary()
        {
#if UNITY_6000_5_OR_NEWER
            return null;
#else
            return "Get {Object} instance ID -> {StoreResult}";
#endif
        }
    }
}
