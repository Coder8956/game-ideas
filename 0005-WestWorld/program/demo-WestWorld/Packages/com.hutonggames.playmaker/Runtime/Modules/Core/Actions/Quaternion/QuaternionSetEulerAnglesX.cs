
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Quaternion)]
	[ActionDescription("Sets the euler angle rotation around X in degrees.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Quaternion-eulerAngles.html")]
	public sealed class QuaternionSetEulerAnglesX : BaseAction
	{
		
		[Tooltip("The Quaternion")]
		[SerializeField]
		private QuaternionRef _quaternion;
		
		[Tooltip("Set rotation around X")]
		[SerializeField]
		private FloatVar _angleAroundX;
		
		public override bool CanExecute()
		{
			return CheckParameters(_quaternion, _angleAroundX);
		}
		
		public override void Execute()
		{
			var value = _quaternion.Value;
			var eulerAngles = value.eulerAngles;
			value.eulerAngles = new Vector3(_angleAroundX.Value, eulerAngles.y, eulerAngles.z);
			_quaternion.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_quaternion} X Rotation to {_angleAroundX}";
		}
	}
}
