
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Quaternion)]
	[ActionDescription("Sets the euler angle rotation around Z in degrees.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Quaternion-eulerAngles.html")]
	public sealed class QuaternionSetEulerAnglesZ : BaseAction
	{
		
		[Tooltip("The Quaternion")]
		[SerializeField]
		private QuaternionRef _quaternion;
		
		[Tooltip("Set rotation around Z")]
		[SerializeField]
		private FloatVar _angleAroundZ;
		
		public override bool CanExecute()
		{
			return CheckParameters(_quaternion, _angleAroundZ);
		}
		
		public override void Execute()
		{
			var value = _quaternion.Value;
			var eulerAngles = value.eulerAngles;
			value.eulerAngles = new Vector3(eulerAngles.x, eulerAngles.y, _angleAroundZ.Value);
			_quaternion.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_quaternion} Z Rotation to {_angleAroundZ}";
		}
	}
}
