
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Physics interpolation used between updates.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-interpolation.html")]
	public sealed class Rigidbody2DGetInterpolation : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Get Rigidbody2D Interpolation")]
		[SerializeField]
		[WriteOnly]
		private RigidbodyInterpolation2DRef _getInterpolation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _getInterpolation);
		}
		
		public override void Execute()
		{
			_getInterpolation.Value = _rigidbody2D.Value.interpolation;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody2D} interpolation -> {_getInterpolation}";
		}
	}
}
