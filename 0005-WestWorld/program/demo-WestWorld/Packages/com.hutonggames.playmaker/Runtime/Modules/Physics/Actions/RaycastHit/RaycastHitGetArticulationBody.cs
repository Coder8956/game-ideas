
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RaycastHit)]
	[ActionDescription("The ArticulationBody of the collider that was hit. If the collider is not attache" +
		"d to an articulation body then it is null.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RaycastHit-articulationBody.html")]
	public sealed class RaycastHitGetArticulationBody : BaseAction
	{
		
		[Tooltip("The RaycastHit")]
		[SerializeField]
		private RaycastHitRef _raycastHit;
		
		[Tooltip("Get RaycastHit Articulation Body")]
		[SerializeField]
		[WriteOnly]
		private ArticulationBodyRef _getArticulationBody;
		
		public override bool CanExecute()
		{
			return CheckParameters(_raycastHit, _getArticulationBody);
		}
		
		public override void Execute()
		{
			_getArticulationBody.Value = _raycastHit.Value.articulationBody;
		}
		
		public override string GetSummary()
		{
			return "Get {_raycastHit} Articulation Body -> {_getArticulationBody}";
		}
	}
}
