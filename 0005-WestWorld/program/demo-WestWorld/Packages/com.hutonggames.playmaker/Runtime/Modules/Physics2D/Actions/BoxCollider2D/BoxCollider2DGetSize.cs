
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.BoxCollider2D)]
	[ActionDescription("The width and height of the rectangle.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/BoxCollider2D-size.html")]
	public sealed class BoxCollider2DGetSize : BaseAction
	{
		
		[Tooltip("The BoxCollider2D")]
		[SerializeField]
		private BoxCollider2DVar _boxCollider2D;
		
		[Tooltip("Get BoxCollider2D Size")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getSize;
		
		public override bool CanExecute()
		{
			return CheckParameters(_boxCollider2D, _getSize);
		}
		
		public override void Execute()
		{
			_getSize.Value = _boxCollider2D.Value.size;
		}
		
		public override string GetSummary()
		{
			return "Get {_boxCollider2D} size -> {_getSize}";
		}
	}
}
