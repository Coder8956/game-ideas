
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.BoxCollider)]
	[ActionDescription("The center of the box, measured in the object\'s local space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/BoxCollider-center.html")]
	public sealed class BoxColliderSetCenter : BaseAction
	{
		
		[Tooltip("The BoxCollider")]
		[SerializeField]
		private BoxColliderVar _boxCollider;
		
		[Tooltip("Set BoxCollider Center")]
		[SerializeField]
		private Vector3Var _setCenter;
		
		public override bool CanExecute()
		{
			return CheckParameters(_boxCollider, _setCenter);
		}
		
		public override void Execute()
		{
			_boxCollider.Value.center = _setCenter.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_boxCollider} Center to {_setCenter}";
		}
	}
}
