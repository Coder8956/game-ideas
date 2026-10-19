
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
	public sealed class RigidbodySetInterpolation : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Set Rigidbody Interpolation")]
		[SerializeField]
		private RigidbodyInterpolationVar _setInterpolation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _setInterpolation);
		}
		
		public override void Execute()
		{
			_rigidbody.Value.interpolation = _setInterpolation.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody} interpolation to {_setInterpolation}";
		}
	}
}
