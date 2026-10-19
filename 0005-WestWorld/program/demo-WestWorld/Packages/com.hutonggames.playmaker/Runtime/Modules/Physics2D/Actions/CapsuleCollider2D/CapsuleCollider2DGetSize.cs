
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CapsuleCollider2D)]
	[ActionDescription("The width and height of the capsule area.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CapsuleCollider2D-size.html")]
	public sealed class CapsuleCollider2DGetSize : BaseAction
	{
		
		[Tooltip("The CapsuleCollider2D")]
		[SerializeField]
		private CapsuleCollider2DVar _capsuleCollider2D;
		
		[Tooltip("Get CapsuleCollider2D Size")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getSize;
		
		public override bool CanExecute()
		{
			return CheckParameters(_capsuleCollider2D, _getSize);
		}
		
		public override void Execute()
		{
			_getSize.Value = _capsuleCollider2D.Value.size;
		}
		
		public override string GetSummary()
		{
			return "Get {_capsuleCollider2D} size -> {_getSize}";
		}
	}
}
