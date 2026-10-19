
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CapsuleCollider2D)]
	[ActionDescription("The direction that the capsule sides can extend.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CapsuleCollider2D-direction.html")]
	public sealed class CapsuleCollider2DGetDirection : BaseAction
	{
		
		[Tooltip("The CapsuleCollider2D")]
		[SerializeField]
		private CapsuleCollider2DVar _capsuleCollider2D;
		
		[Tooltip("Get CapsuleCollider2D Direction")]
		[SerializeField]
		[WriteOnly]
		private CapsuleDirection2DRef _getDirection;
		
		public override bool CanExecute()
		{
			return CheckParameters(_capsuleCollider2D, _getDirection);
		}
		
		public override void Execute()
		{
			_getDirection.Value = _capsuleCollider2D.Value.direction;
		}
		
		public override string GetSummary()
		{
			return "Get {_capsuleCollider2D} direction -> {_getDirection}";
		}
	}
}
