using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
#if UNITY_6000_0_OR_NEWER
	[Obsolete("Use MavMeshSetLinkOwner instead.")]
#endif	
    [Serializable]
    [ActionCategory(Category.AI.NavMeshLinkInstance)]
    [ActionDescription("Set the owning Object.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshLinkInstance-owner.html")]
    public sealed class NavMeshLinkInstanceSetOwner : BaseAction
    {
		
        [Tooltip("The NavMeshLinkInstance")]
        [SerializeField]
        private HutongGames.PlayMaker.Actions.AI.NavMeshLinkInstanceRef _navMeshLinkInstance;
		
        [Tooltip("Set NavMeshLinkInstance Owner")]
        [SerializeField]
        private HutongGames.PlayMaker.ObjectVar _setOwner;
		
        public override bool CanExecute()
        {
            return CheckParameters(_navMeshLinkInstance, _setOwner);
        }
		
        public override void Execute()
        {
#if !UNITY_6000_0_OR_NEWER	
            var value = this._navMeshLinkInstance.Value;
            value.owner = this._setOwner.Value;
            this._navMeshLinkInstance.Value = value;
#endif
        }
		
        public override string GetSummary()
        {
            return "Set {_navMeshLinkInstance} Owner to {_setOwner}";
        }
    }
}