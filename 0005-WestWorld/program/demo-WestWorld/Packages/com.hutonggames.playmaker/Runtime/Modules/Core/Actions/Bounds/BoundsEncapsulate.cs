
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Bounds)]
	[ActionDescription("Grows the Bounds to include the point.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Bounds.Encapsulate.html")]
	public sealed class BoundsEncapsulate : BaseAction
	{
		
		[Tooltip("The Bounds.")]
		[SerializeField, WriteOnly]
		private BoundsRef _bounds;
		
		[Tooltip("Point.")]
		[SerializeField]
		private Vector3Var _point;
		
		public override bool CanExecute()
		{
			return CheckParameters(_bounds, _point);
		}
		
		public override void Execute()
		{
			//UnityEngine.Bounds.Encapsulate(UnityEngine.Vector3);
			_bounds.Value.Encapsulate(_point.Value);
		}
		
		public override string GetSummary()
		{
			return "Grow {_bounds} to encapsulate {_point} ";
		}
	}
}
