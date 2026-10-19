
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("Interpolation provides a way to manage the appearance of jitter in the movement o" +
		"f your Rigidbody GameObjects at run time.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-interpolation.html")]
	public sealed class RigidbodyGetInterpolation : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Get Rigidbody Interpolation")]
		[SerializeField]
		[WriteOnly]
		private RigidbodyInterpolationRef _getInterpolation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _getInterpolation);
		}
		
		public override void Execute()
		{
			_getInterpolation.Value = _rigidbody.Value.interpolation;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody} interpolation -> {_getInterpolation}";
		}
	}
}
