
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animator)]
	[ActionDescription("Returns true if there is a transition on the given layer, false otherwise.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animator.IsInTransition.html")]
	public sealed class AnimatorIsInTransition : BaseAction
	{
		
		[Tooltip("The Animator.")]
		[SerializeField]
		private AnimatorVar _animator;
		
		[Tooltip("The layer index.")]
		[SerializeField]
		private IntegerVar _layerIndex;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_animator, _layerIndex, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Animator.IsInTransition(System.Int32);
			_result.Value = _animator.Value.IsInTransition(_layerIndex.Value);
		}
		
		public override string GetSummary()
		{
			return "Check {_animator} is in transition -> {_result} ({_layerIndex})";
		}
	}
}
