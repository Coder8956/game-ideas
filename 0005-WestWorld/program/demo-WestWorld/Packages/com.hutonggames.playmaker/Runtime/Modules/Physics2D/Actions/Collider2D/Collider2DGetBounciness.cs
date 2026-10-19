
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider2D)]
	[ActionDescription("Get the bounciness used by the collider.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider2D-bounciness.html")]
	public sealed class Collider2DGetBounciness : BaseAction
	{
		
		[Tooltip("The Collider2D")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("Get Collider2D Bounciness")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getBounciness;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider2D, _getBounciness);
		}
		
		public override void Execute()
		{
			_getBounciness.Value = _collider2D.Value.bounciness;
		}
		
		public override string GetSummary()
		{
			return "Get {_collider2D} bounciness -> {_getBounciness}";
		}
	}
}
