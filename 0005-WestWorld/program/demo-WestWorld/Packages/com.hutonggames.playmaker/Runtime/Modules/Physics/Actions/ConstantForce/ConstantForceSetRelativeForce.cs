
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ConstantForce)]
	[ActionDescription("The force - relative to the rigid bodies coordinate system - applied every frame." +
		"")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ConstantForce-relativeForce.html")]
	public sealed class ConstantForceSetRelativeForce : BaseAction
	{
		
		[Tooltip("The ConstantForce")]
		[SerializeField]
		private ConstantForceVar _constantForce;
		
		[Tooltip("Set ConstantForce Relative Force")]
		[SerializeField]
		private Vector3Var _setRelativeForce;
		
		public override bool CanExecute()
		{
			return CheckParameters(_constantForce, _setRelativeForce);
		}
		
		public override void Execute()
		{
			_constantForce.Value.relativeForce = _setRelativeForce.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_constantForce} Relative Force to {_setRelativeForce}";
		}
	}
}
