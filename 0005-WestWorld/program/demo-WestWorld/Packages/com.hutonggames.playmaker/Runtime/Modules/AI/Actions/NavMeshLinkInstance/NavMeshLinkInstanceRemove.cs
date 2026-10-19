using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
#if UNITY_6000_0_OR_NEWER
	[Obsolete("Use MavMeshRemoveLink instead.")]
#endif	
    [Serializable]
    [ActionCategory(Category.AI.NavMeshLinkInstance)]
    [ActionDescription("Removes this instance from the game.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshLinkInstance.Remove.html")]
    public sealed class NavMeshLinkInstanceRemove : BaseAction
    {
		
        [Tooltip("The NavMeshLinkInstance.")]
        [SerializeField]
        private HutongGames.PlayMaker.Actions.AI.NavMeshLinkInstanceRef _navMeshLinkInstance;
		
        public override bool CanExecute()
        {
            return CheckParameters(_navMeshLinkInstance);
        }
		
        public override void Execute()
        {
#if !UNITY_6000_0_OR_NEWER	
            _navMeshLinkInstance.Value.Remove();
#endif
        }
		
        public override string GetSummary()
        {
            return "{_navMeshLinkInstance} remove ";
        }
    }
}