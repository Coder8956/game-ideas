
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ConstantForce)]
	[ActionDescription("The force applied to the rigidbody every frame.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ConstantForce-force.html")]
	public sealed class ConstantForceGetForce : BaseAction
	{
		
		[Tooltip("The ConstantForce")]
		[SerializeField]
		private ConstantForceVar _constantForce;
		
		[Tooltip("Get ConstantForce Force")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getForce;
		
		public override bool CanExecute()
		{
			return CheckParameters(_constantForce, _getForce);
		}
		
		public override void Execute()
		{
			_getForce.Value = _constantForce.Value.force;
		}
		
		public override string GetSummary()
		{
			return "Get {_constantForce} force -> {_getForce}";
		}
	}
}
