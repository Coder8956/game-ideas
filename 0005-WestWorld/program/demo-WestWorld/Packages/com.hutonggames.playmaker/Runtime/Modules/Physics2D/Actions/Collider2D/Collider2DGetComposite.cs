
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider2D)]
	[ActionDescription("Get the CompositeCollider2D that is available to be attached to the collider.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider2D-composite.html")]
	public sealed class Collider2DGetComposite : BaseAction
	{
		
		[Tooltip("The Collider2D")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("Get Collider2D Composite")]
		[SerializeField]
		[WriteOnly]
		private CompositeCollider2DVar _getComposite;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider2D, _getComposite);
		}
		
		public override void Execute()
		{
			_getComposite.Value = _collider2D.Value.composite;
		}
		
		public override string GetSummary()
		{
			return "Get {_collider2D} composite -> {_getComposite}";
		}
	}
}
