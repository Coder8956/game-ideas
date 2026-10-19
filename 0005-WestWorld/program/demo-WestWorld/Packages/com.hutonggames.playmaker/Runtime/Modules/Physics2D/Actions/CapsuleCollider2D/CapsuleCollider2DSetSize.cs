
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CapsuleCollider2D)]
	[ActionDescription("The width and height of the capsule area.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CapsuleCollider2D-size.html")]
	public sealed class CapsuleCollider2DSetSize : BaseAction
	{
		
		[Tooltip("The CapsuleCollider2D")]
		[SerializeField]
		private CapsuleCollider2DVar _capsuleCollider2D;
		
		[Tooltip("Set CapsuleCollider2D Size")]
		[SerializeField]
		private Vector2Var _setSize;
		
		public override bool CanExecute()
		{
			return CheckParameters(_capsuleCollider2D, _setSize);
		}
		
		public override void Execute()
		{
			_capsuleCollider2D.Value.size = _setSize.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_capsuleCollider2D} Size to {_setSize}";
		}
	}
}
