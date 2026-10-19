
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Physics interpolation used between updates.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-interpolation.html")]
	public sealed class Rigidbody2DSetInterpolation : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Set Rigidbody2D Interpolation")]
		[SerializeField]
		private RigidbodyInterpolation2DVar _setInterpolation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _setInterpolation);
		}
		
		public override void Execute()
		{
			_rigidbody2D.Value.interpolation = _setInterpolation.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody2D} interpolation to {_setInterpolation}";
		}
	}
}
