
using UnityEngine;
// ReSharper disable InconsistentNaming
// ReSharper disable UnassignedField.Global


namespace HutongGames.PlayMaker.Actions
{
	
	[System.Serializable]
	public abstract class BaseAnimatorParameterAction : BaseAction
	{
		[DisplayOrder(-1000)]
		[Tooltip("The Animator.")]
		[SerializeField]
		protected AnimatorVar _animator;
		
		[DisplayOrder(-999)]
		[Tooltip("The parameter name.")]
		[AnimatorParameter]
		[SerializeField]
		protected StringVar _name;

		private string _cachedName;
		protected int ParameterID;
		
		public override bool CanExecute() => CheckParameters(_animator, _name);

		public override void Execute()
		{
			UpdateCachedId();
		}

		private void UpdateCachedId()
		{
			if (_cachedName == _name.Value) return;
			ParameterID = Animator.StringToHash(_name.Value);
			_cachedName = _name.Value;
		}
	}
}
