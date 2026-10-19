
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ActionDescription("Returns a copy of vector with its magnitude clamped to maxLength.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2.ClampMagnitude.html")]
	public sealed class Vector2ClampMagnitude : BaseAction
	{
		
		[Tooltip("Vector.")]
		[SerializeField]
		private Vector2Var _vector;
		
		[Tooltip("Max Length.")]
		[SerializeField]
		private FloatVar _maxLength;
		
		[Tooltip("Store the result in Vector2 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector, _maxLength, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Vector2.ClampMagnitude(UnityEngine.Vector2, System.Single);
			_result.Value = Vector2.ClampMagnitude(_vector.Value, _maxLength.Value);
		}
		
		public override string GetSummary()
		{
			return "Vector2 Clamp Magnitude: {_vector} {_maxLength} -> {_result}";
		}
	}
}
