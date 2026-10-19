
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("Returns a copy of vector with its magnitude clamped to maxLength.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3.ClampMagnitude.html")]
	public sealed class Vector3ClampMagnitude : BaseAction
	{
		
		[Tooltip("Vector.")]
		[SerializeField]
		private Vector3Var _vector;
		
		[Tooltip("Max Length.")]
		[SerializeField]
		private FloatVar _maxLength;
		
		[Tooltip("Store the result in Vector3 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector, _maxLength, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Vector3.ClampMagnitude(UnityEngine.Vector3, System.Single);
			_result.Value = Vector3.ClampMagnitude(_vector.Value, _maxLength.Value);
		}
		
		public override string GetSummary()
		{
			return "Vector3 Clamp Magnitude: {_vector} {_maxLength} -> {_result}";
		}
	}
}
