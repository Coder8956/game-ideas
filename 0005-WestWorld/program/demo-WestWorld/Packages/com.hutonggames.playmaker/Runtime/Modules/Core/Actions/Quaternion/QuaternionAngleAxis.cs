
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Quaternion)]
	[ActionDescription("Creates a rotation which rotates angle degrees around axis.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Quaternion.AngleAxis.html")]
	public sealed class QuaternionAngleAxis : BaseAction
	{
		
		[Tooltip("Angle.")]
		[SerializeField]
		private FloatVar _angle;
		
		[Tooltip("Axis.")]
		[SerializeField]
		private Vector3Var _axis;
		
		[Tooltip("Store the result in Quaternion variable.")]
		[SerializeField]
		[WriteOnly]
		private QuaternionRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_angle, _axis, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Quaternion.AngleAxis(System.Single, UnityEngine.Vector3);
			_result.Value = Quaternion.AngleAxis(_angle.Value, _axis.Value);
		}
		
		public override string GetSummary()
		{
			return "Quaternion Angle Axis: {_angle} {_axis} -> {_result}";
		}
	}
}
