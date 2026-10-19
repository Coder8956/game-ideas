
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.BoxCollider2D)]
	[ActionDescription("Set the offset and size to match a rect in world space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/BoxCollider2D-size.html")]
	public sealed class BoxCollider2DSetRect : BaseAction
	{
		
		[Tooltip("The BoxCollider2D")]
		[SerializeField]
		private BoxCollider2DVar _boxCollider2D;
		
		[Tooltip("Set BoxCollider2D Size")]
		[SerializeField]
		private RectVar _setRect;
		
		public override bool CanExecute() => CheckParameters(_boxCollider2D, _setRect);

		public override void Execute()
		{
			_boxCollider2D.Value.offset = _setRect.Value.center - (Vector2) _boxCollider2D.Value.transform.position;
			_boxCollider2D.Value.size = _setRect.Value.size;
		}
		
		public override string GetSummary()
		{
			return "Set {_boxCollider2D} rect to {_setRect}";
		}
	}
}
