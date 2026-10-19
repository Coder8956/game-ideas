
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider2D)]
	[ActionDescription("The density of the collider used to calculate its mass (when auto mass is enabled" +
		").")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider2D-density.html")]
	public sealed class Collider2DGetDensity : BaseAction
	{
		
		[Tooltip("The Collider2D")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("Get Collider2D Density")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getDensity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider2D, _getDensity);
		}
		
		public override void Execute()
		{
			_getDensity.Value = _collider2D.Value.density;
		}
		
		public override string GetSummary()
		{
			return "Get {_collider2D} density -> {_getDensity}";
		}
	}
}
