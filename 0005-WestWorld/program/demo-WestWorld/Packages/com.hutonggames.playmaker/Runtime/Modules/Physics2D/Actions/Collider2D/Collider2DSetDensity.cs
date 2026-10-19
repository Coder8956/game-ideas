
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
	public sealed class Collider2DSetDensity : BaseAction
	{
		
		[Tooltip("The Collider2D")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("Set Collider2D Density")]
		[SerializeField]
		private FloatVar _setDensity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider2D, _setDensity);
		}
		
		public override void Execute()
		{
			_collider2D.Value.density = _setDensity.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_collider2D} density to {_setDensity}";
		}
	}
}
