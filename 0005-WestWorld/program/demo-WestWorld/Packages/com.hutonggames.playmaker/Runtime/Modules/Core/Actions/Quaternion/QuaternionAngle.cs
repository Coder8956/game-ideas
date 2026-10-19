
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Quaternion)]
	[ActionDescription("Returns the angle in degrees between two rotations a and b. " +
	                   "The resulting angle ranges from 0 to 180.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Quaternion.Angle.html")]
	public sealed class QuaternionAngle : BaseAction
	{
		
		[Tooltip("Rotation A.")]
		[SerializeField]
		private QuaternionVar _a;
		
		[Tooltip("Rotation B.")]
		[SerializeField]
		private QuaternionVar _b;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute() => CheckParameters(_a, _b, _result);

		public override void Execute()
		{
			//UnityEngine.Quaternion.Angle(UnityEngine.Quaternion, UnityEngine.Quaternion);
			_result.Value = Quaternion.Angle(_a.Value, _b.Value);
		}
		
		public override string GetSummary()
		{
			return "Angle: {_a} {_b} -> {_result}";
		}
	}
}
