
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CapsuleCollider2D)]
	[ActionDescription("The direction that the capsule sides can extend.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CapsuleCollider2D-direction.html")]
	public sealed class CapsuleCollider2DSetDirection : BaseAction
	{
		
		[Tooltip("The CapsuleCollider2D")]
		[SerializeField]
		private CapsuleCollider2DVar _capsuleCollider2D;
		
		[Tooltip("Set CapsuleCollider2D Direction")]
		[SerializeField]
		private CapsuleDirection2DVar _setDirection;
		
		public override bool CanExecute()
		{
			return CheckParameters(_capsuleCollider2D, _setDirection);
		}
		
		public override void Execute()
		{
			_capsuleCollider2D.Value.direction = _setDirection.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_capsuleCollider2D} Direction to {_setDirection}";
		}
	}
}
