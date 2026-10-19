
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector4)]
	[ActionDescription("Moves a point current towards target.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector4.MoveTowards.html")]
	public sealed class Vector4MoveTowards : BaseAction
	{
		public override bool CanUsePerSecond => true;
		
		[Tooltip("Current.")]
		[SerializeField]
		private Vector4Var _current;
		
		[Tooltip("Target.")]
		[SerializeField]
		private Vector4Var _target;
		
		[Tooltip("Max Distance Delta.")]
		[SerializeField]
		private FloatVar _maxDistanceDelta;
		
		[Tooltip("Store the result in Vector4 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector4Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_current, _target, _maxDistanceDelta, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Vector4.MoveTowards(UnityEngine.Vector4, UnityEngine.Vector4, System.Single);
			_result.Value = Vector4.MoveTowards(_current.Value, _target.Value, _maxDistanceDelta.Value * PerSecond);
		}
		
		public override string GetSummary()
		{
			return "Vector4 Move Towards: {_current} {_target} {_maxDistanceDelta} {PerSecond} -> {_result}";
		}
	}
}
