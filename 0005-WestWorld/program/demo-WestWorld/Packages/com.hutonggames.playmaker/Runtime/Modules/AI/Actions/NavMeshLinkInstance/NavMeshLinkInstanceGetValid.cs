using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
#if UNITY_6000_0_OR_NEWER
	[Obsolete("Use MavMeshGetIsLinkValid instead.")]
#endif		
    [Serializable]
    [ActionCategory(Category.AI.NavMeshLinkInstance)]
    [ActionDescription("True if the NavMesh link is added to the navigation system - otherwise false (Read Only).")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshLinkInstance-valid.html")]
    public sealed class NavMeshLinkInstanceGetValid : BaseAction
    {
		
        [Tooltip("The NavMeshLinkInstance")]
        [SerializeField]
        private HutongGames.PlayMaker.Actions.AI.NavMeshLinkInstanceRef _navMeshLinkInstance;
		
        [Tooltip("Get NavMeshLinkInstance Valid")]
        [SerializeField]
        [WriteOnly]
        private HutongGames.PlayMaker.BoolRef _getValid;
		
        public override bool CanExecute()
        {
            return CheckParameters(_navMeshLinkInstance, _getValid);
        }
		
        public override void Execute()
        {
#if !UNITY_6000_0_OR_NEWER	
            this._getValid.Value = this._navMeshLinkInstance.Value.valid;
#endif
        }
		
        public override string GetSummary()
        {
            return "Get {_navMeshLinkInstance} Valid -> {_getValid}";
        }
    }
}