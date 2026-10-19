
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
	public sealed class ConstantForceGetRelativeForce : BaseAction
	{
		
		[Tooltip("The ConstantForce")]
		[SerializeField]
		private ConstantForceVar _constantForce;
		
		[Tooltip("Get ConstantForce Relative Force")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getRelativeForce;
		
		public override bool CanExecute()
		{
			return CheckParameters(_constantForce, _getRelativeForce);
		}
		
		public override void Execute()
		{
			_getRelativeForce.Value = _constantForce.Value.relativeForce;
		}
		
		public override string GetSummary()
		{
			return "Get {_constantForce} relativeForce -> {_getRelativeForce}";
		}
	}
}
