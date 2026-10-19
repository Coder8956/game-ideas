
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CompositeCollider2D)]
	[ActionDescription("Regenerates the Composite Collider geometry.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CompositeCollider2D.GenerateGeometry.htm" +
		"l")]
	public sealed class CompositeCollider2DGenerateGeometry : BaseAction
	{
		
		[Tooltip("The CompositeCollider2D.")]
		[SerializeField]
		private CompositeCollider2DVar _compositeCollider2D;
		
		public override bool CanExecute()
		{
			return CheckParameters(_compositeCollider2D);
		}
		
		public override void Execute()
		{
			//UnityEngine.CompositeCollider2D.GenerateGeometry();
			_compositeCollider2D.Value.GenerateGeometry();
		}
		
		public override string GetSummary()
		{
			return "Generate Geometry {_compositeCollider2D} ";
		}
	}
}
