
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.BoxCollider2D)]
	[ActionDescription("The width and height of the rectangle.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/BoxCollider2D-size.html")]
	public sealed class BoxCollider2DSetSize : BaseAction
	{
		
		[Tooltip("The BoxCollider2D")]
		[SerializeField]
		private BoxCollider2DVar _boxCollider2D;
		
		[Tooltip("Set BoxCollider2D Size")]
		[SerializeField]
		private Vector2Var _setSize;
		
		public override bool CanExecute()
		{
			return CheckParameters(_boxCollider2D, _setSize);
		}
		
		public override void Execute()
		{
			_boxCollider2D.Value.size = _setSize.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_boxCollider2D} Size to {_setSize}";
		}
	}
}
