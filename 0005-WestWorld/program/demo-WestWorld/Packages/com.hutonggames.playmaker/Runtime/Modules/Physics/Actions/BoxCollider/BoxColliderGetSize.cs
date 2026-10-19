
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.BoxCollider)]
	[ActionDescription("The size of the box, measured in the object\'s local space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/BoxCollider-size.html")]
	public sealed class BoxColliderGetSize : BaseAction
	{
		
		[Tooltip("The BoxCollider")]
		[SerializeField]
		private BoxColliderVar _boxCollider;
		
		[Tooltip("Get BoxCollider Size")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getSize;
		
		public override bool CanExecute()
		{
			return CheckParameters(_boxCollider, _getSize);
		}
		
		public override void Execute()
		{
			_getSize.Value = _boxCollider.Value.size;
		}
		
		public override string GetSummary()
		{
			return "Get {_boxCollider} size -> {_getSize}";
		}
	}
}
