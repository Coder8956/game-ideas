
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider2D)]
	[ActionDescription("The local offset of the collider geometry.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider2D-offset.html")]
	public sealed class Collider2DGetOffset : BaseAction
	{
		
		[Tooltip("The Collider2D")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("Get Collider2D Offset")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getOffset;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider2D, _getOffset);
		}
		
		public override void Execute()
		{
			_getOffset.Value = _collider2D.Value.offset;
		}
		
		public override string GetSummary()
		{
			return "Get {_collider2D} offset -> {_getOffset}";
		}
	}
}
