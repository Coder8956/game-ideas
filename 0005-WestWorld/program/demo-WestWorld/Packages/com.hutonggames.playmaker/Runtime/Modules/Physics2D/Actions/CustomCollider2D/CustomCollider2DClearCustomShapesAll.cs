
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CustomCollider2D)]
	[ActionDescription("Deletes all the shapes and associated vertices for those shapes from the Collider" +
		".")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CustomCollider2D.ClearCustomShapes.html")]
	public sealed class CustomCollider2DClearCustomShapesAll : BaseAction
	{
		
		[Tooltip("The CustomCollider2D.")]
		[SerializeField]
		private CustomCollider2DVar _customCollider2D;
		
		public override bool CanExecute()
		{
			return CheckParameters(_customCollider2D);
		}
		
		public override void Execute()
		{
			//UnityEngine.CustomCollider2D.ClearCustomShapes();
			_customCollider2D.Value.ClearCustomShapes();
		}
		
		public override string GetSummary()
		{
			return "Clear Custom Shapes {_customCollider2D} ";
		}
	}
}
