
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.BoxCollider)]
	[ActionDescription("The center of the box, measured in the object\'s local space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/BoxCollider-center.html")]
	public sealed class BoxColliderGetCenter : BaseAction
	{
		
		[Tooltip("The BoxCollider")]
		[SerializeField]
		private BoxColliderVar _boxCollider;
		
		[Tooltip("Get BoxCollider Center")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getCenter;
		
		public override bool CanExecute()
		{
			return CheckParameters(_boxCollider, _getCenter);
		}
		
		public override void Execute()
		{
			_getCenter.Value = _boxCollider.Value.center;
		}
		
		public override string GetSummary()
		{
			return "Get {_boxCollider} center -> {_getCenter}";
		}
	}
}
