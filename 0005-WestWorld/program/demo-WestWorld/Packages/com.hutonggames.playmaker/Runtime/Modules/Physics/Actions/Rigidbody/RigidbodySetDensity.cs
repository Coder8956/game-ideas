
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	#if UNITY_6000_1_OR_NEWER
	[Obsolete("Use SetMass instead. Setting density on a Rigidbody no longer has any effect.")]
	#endif

	[Serializable]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("Sets the mass based on the attached colliders assuming a constant density.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody.html")]
	public sealed class RigidbodySetDensity : BaseAction
	{
		
		[Tooltip("The Rigidbody.")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Density.")]
		[SerializeField]
		private FloatVar _density;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _density);
		}
		
		public override void Execute()
		{
#if !UNITY_6000_1_OR_NEWER
			_rigidbody.Value.SetDensity(_density.Value);
#endif			
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody} density to {_density}";
		}
	}
}

