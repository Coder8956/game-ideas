
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animator)]
	[ActionDescription("Additional layers affects the center of mass.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animator-layersAffectMassCenter.html")]
	public sealed class AnimatorSetLayersAffectMassCenter : BaseAction
	{
		
		[Tooltip("The Animator")]
		[SerializeField]
		private AnimatorVar _animator;
		
		[Tooltip("Set Animator Layers Affect Mass Center")]
		[SerializeField]
		private BoolVar _setLayersAffectMassCenter;
		
		public override bool CanExecute()
		{
			return CheckParameters(_animator, _setLayersAffectMassCenter);
		}
		
		public override void Execute()
		{
			_animator.Value.layersAffectMassCenter = _setLayersAffectMassCenter.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_animator} layers affect mass center to {_setLayersAffectMassCenter}";
		}
	}
}
