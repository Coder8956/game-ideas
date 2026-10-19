
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CompositeCollider2D)]
	[ActionDescription("Specifies when to generate the Composite Collider geometry.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CompositeCollider2D-generationType.html")]
	public sealed class CompositeCollider2DSetGenerationType : BaseAction
	{
		
		[Tooltip("The CompositeCollider2D")]
		[SerializeField]
		private CompositeCollider2DVar _compositeCollider2D;
		
		[Tooltip("Set CompositeCollider2D Generation Type")]
		[SerializeField]
		private CompositeCollider2D_GenerationTypeVar _setGenerationType;
		
		public override bool CanExecute()
		{
			return CheckParameters(_compositeCollider2D, _setGenerationType);
		}
		
		public override void Execute()
		{
			_compositeCollider2D.Value.generationType = _setGenerationType.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_compositeCollider2D} Generation Type to {_setGenerationType}";
		}
	}
}
