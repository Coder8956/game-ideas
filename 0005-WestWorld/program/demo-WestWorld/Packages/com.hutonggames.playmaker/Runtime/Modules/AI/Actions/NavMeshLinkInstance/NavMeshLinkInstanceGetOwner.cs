using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
#if UNITY_6000_0_OR_NEWER
	[Obsolete("Use MavMeshGetLinkOwner instead.")]
#endif	
    [Serializable]
    [ActionCategory(Category.AI.NavMeshLinkInstance)]
    [ActionDescription("Get the owning Object.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshLinkInstance-owner.html")]
    public sealed class NavMeshLinkInstanceGetOwner : BaseAction
    {
		
        [Tooltip("The NavMeshLinkInstance")]
        [SerializeField]
        private HutongGames.PlayMaker.Actions.AI.NavMeshLinkInstanceRef _navMeshLinkInstance;
		
        [Tooltip("Get NavMeshLinkInstance Owner")]
        [SerializeField]
        [WriteOnly]
        private HutongGames.PlayMaker.ObjectRef _getOwner;
		
        public override bool CanExecute()
        {
            return CheckParameters(_navMeshLinkInstance, _getOwner);
        }
		
        public override void Execute()
        {
#if !UNITY_6000_0_OR_NEWER			
            this._getOwner.Value = this._navMeshLinkInstance.Value.owner;
#endif
        }
		
        public override string GetSummary()
        {
            return "Get {_navMeshLinkInstance} Owner -> {_getOwner}";
        }
    }
}