
using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.Serialization;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Quaternion)]
	[ActionDescription("Rotates a rotation towards a target rotation.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Quaternion.RotateTowards.html")]
	public sealed class QuaternionRotateTowards : BaseAction
	{
		public override bool CanUsePerSecond => true;
		
		[Tooltip("The unit quaternion to be aligned with to.")]
		[SerializeField]
		private QuaternionVar _from;
		
		[Tooltip("The target unit quaternion.")]
		[SerializeField]
		private QuaternionVar _to;
		
		[FormerlySerializedAs("_maxDegreesDelta")]
		[Tooltip("The maximum angle in degrees allowed for this rotation.")]
		[SerializeField]
		private FloatVar _maxDelta;
		
		[Tooltip("Store the result in Quaternion variable.")]
		[SerializeField]
		[WriteOnly]
		private QuaternionRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_from, _to, _maxDelta, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Quaternion.RotateTowards(UnityEngine.Quaternion, UnityEngine.Quaternion, System.Single);
			_result.Value = Quaternion.RotateTowards(_from.Value, _to.Value, _maxDelta.Value * PerSecond);
		}
		
		public override string GetSummary()
		{
			return "Rotate {_from} towards {_to} @{_maxDelta} {PerSecond} -> {_result}";
		}
	}
}
