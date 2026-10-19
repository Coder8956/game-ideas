
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider)]
	[ActionDescription("The articulation body the collider is attached to.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider-attachedArticulationBody.html")]
	public sealed class ColliderGetAttachedArticulationBody : BaseAction
	{
		
		[Tooltip("The Collider")]
		[SerializeField]
		private ColliderVar _collider;
		
		[Tooltip("Get Collider Attached Articulation Body")]
		[SerializeField]
		[WriteOnly]
		private ArticulationBodyVar _getAttachedArticulationBody;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider, _getAttachedArticulationBody);
		}
		
		public override void Execute()
		{
			_getAttachedArticulationBody.Value = _collider.Value.attachedArticulationBody;
		}
		
		public override string GetSummary()
		{
			return "Get {_collider} attached articulation body -> {_getAttachedArticulationBody}";
		}
	}
}
