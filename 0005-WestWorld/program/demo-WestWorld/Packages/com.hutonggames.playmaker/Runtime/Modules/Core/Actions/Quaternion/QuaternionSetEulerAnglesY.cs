
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Quaternion)]
	[ActionDescription("Sets the euler angle rotation around Y in degrees.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Quaternion-eulerAngles.html")]
	public sealed class QuaternionSetEulerAnglesY : BaseAction
	{
		
		[Tooltip("The Quaternion")]
		[SerializeField]
		private QuaternionRef _quaternion;
		
		[Tooltip("Set rotation around Y")]
		[SerializeField]
		private FloatVar _angleAroundY;
		
		public override bool CanExecute()
		{
			return CheckParameters(_quaternion, _angleAroundY);
		}
		
		public override void Execute()
		{
			var value = _quaternion.Value;
			var eulerAngles = value.eulerAngles;
			value.eulerAngles = new Vector3(eulerAngles.x, _angleAroundY.Value, eulerAngles.z);
			_quaternion.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_quaternion} Y Rotation to {_angleAroundY}";
		}
	}
}
