
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider2D)]
	[ActionDescription("The error state that indicates the state of the physics shapes the 2D Collider tr" +
		"ied to create. (Read Only)")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider2D-errorState.html")]
	public sealed class Collider2DGetErrorState : BaseAction
	{
		
		[Tooltip("The Collider2D")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("Get Collider2D Error State")]
		[SerializeField]
		[WriteOnly]
		private ColliderErrorState2DRef _getErrorState;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider2D, _getErrorState);
		}
		
		public override void Execute()
		{
			_getErrorState.Value = _collider2D.Value.errorState;
		}
		
		public override string GetSummary()
		{
			return "Get {_collider2D} error state -> {_getErrorState}";
		}
	}
}
