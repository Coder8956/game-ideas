
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animator)]
	[ActionDescription("Sets the weight of the layer at the given index.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animator.SetLayerWeight.html")]
	public sealed class AnimatorSetLayerWeight : BaseAction
	{
		
		[Tooltip("The Animator.")]
		[SerializeField]
		private AnimatorVar _animator;
		
		[Tooltip("The layer index.")]
		[SerializeField]
		private IntegerVar _layerIndex;
		
		[Tooltip("The new layer weight.")]
		[SerializeField]
		private FloatVar _weight;
		
		public override bool CanExecute()
		{
			return CheckParameters(_animator, _layerIndex, _weight);
		}
		
		public override void Execute()
		{
			//UnityEngine.Animator.SetLayerWeight(System.Int32, System.Single);
			_animator.Value.SetLayerWeight(_layerIndex.Value, _weight.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_animator} layer {_layerIndex} weight to {_weight}";
		}
	}
}
