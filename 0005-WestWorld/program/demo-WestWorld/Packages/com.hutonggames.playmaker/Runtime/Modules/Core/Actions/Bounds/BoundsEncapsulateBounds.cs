
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Bounds)]
	[ActionDescription("Grows the Bounds to include the point.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Bounds.Encapsulate.html")]
	public sealed class BoundsEncapsulateBounds : BaseAction
	{
		
		[Tooltip("The Bounds.")]
		[SerializeField, WriteOnly]
		private BoundsRef _bounds;
		
		[Tooltip("Bounds.")]
		[SerializeField]
		private BoundsVar _other;
		
		public override bool CanExecute()
		{
			return CheckParameters(_bounds, _other);
		}
		
		public override void Execute()
		{
			_bounds.Value.Encapsulate(_other.Value);
		}
		
		public override string GetSummary()
		{
			return "Grow {_bounds} to encapsulate {_other}";
		}
	}
}
