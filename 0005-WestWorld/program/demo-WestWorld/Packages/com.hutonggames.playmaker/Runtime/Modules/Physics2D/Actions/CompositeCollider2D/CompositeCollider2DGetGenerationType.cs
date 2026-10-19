
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CompositeCollider2D)]
	[ActionDescription("Specifies when to generate the Composite Collider geometry.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CompositeCollider2D-generationType.html")]
	public sealed class CompositeCollider2DGetGenerationType : BaseAction
	{
		
		[Tooltip("The CompositeCollider2D")]
		[SerializeField]
		private CompositeCollider2DVar _compositeCollider2D;
		
		[Tooltip("Get CompositeCollider2D Generation Type")]
		[SerializeField]
		[WriteOnly]
		private CompositeCollider2D_GenerationTypeRef _getGenerationType;
		
		public override bool CanExecute()
		{
			return CheckParameters(_compositeCollider2D, _getGenerationType);
		}
		
		public override void Execute()
		{
			_getGenerationType.Value = _compositeCollider2D.Value.generationType;
		}
		
		public override string GetSummary()
		{
			return "Get {_compositeCollider2D} generationType -> {_getGenerationType}";
		}
	}
}
