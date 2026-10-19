
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Quaternion)]
	[ActionDescription("Converts this quaternion to a quaternion with the same orientation but with a magnitude of 1.0.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Quaternion.Normalize.html")]
	public sealed class QuaternionNormalize : BaseAction
	{
		
		[Tooltip("The Quaternion.")]
		[SerializeField]
		private QuaternionRef _quaternion;
		
		public override bool CanExecute()
		{
			return CheckParameters(_quaternion);
		}
		
		public override void Execute()
		{
			//UnityEngine.Quaternion.Normalize();
			_quaternion.Value.Normalize();
		}
		
		public override string GetSummary()
		{
			return "Normalize {_quaternion} ";
		}
	}
}
