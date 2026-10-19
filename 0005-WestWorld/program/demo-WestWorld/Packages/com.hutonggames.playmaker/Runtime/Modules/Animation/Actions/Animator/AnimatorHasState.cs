
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animator)]
	[ActionDescription("Returns true if the state exists in this layer, false otherwise.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animator.HasState.html")]
	public sealed class AnimatorHasState : BaseAction
	{
		
		[Tooltip("The Animator.")]
		[SerializeField]
		private AnimatorVar _animator;
		
		[Tooltip("The layer index.")]
		[SerializeField]
		private IntegerVar _layerIndex;
		
		[Tooltip("The state ID.")]
		[SerializeField]
		private IntegerVar _stateID;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_animator, _layerIndex, _stateID, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Animator.HasState(System.Int32, System.Int32);
			_result.Value = _animator.Value.HasState(_layerIndex.Value, _stateID.Value);
		}
		
		public override string GetSummary()
		{
			return "Check {_animator} has state {_stateID} -> {_result} ({_layerIndex})";
		}
	}
}
