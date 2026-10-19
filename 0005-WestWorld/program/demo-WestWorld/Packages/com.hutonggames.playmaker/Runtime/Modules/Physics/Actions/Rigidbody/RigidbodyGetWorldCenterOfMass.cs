
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("The center of mass of the rigidbody in world space (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-worldCenterOfMass.html")]
	public sealed class RigidbodyGetWorldCenterOfMass : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Get Rigidbody World Center Of Mass")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getWorldCenterOfMass;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _getWorldCenterOfMass);
		}
		
		public override void Execute()
		{
			_getWorldCenterOfMass.Value = _rigidbody.Value.worldCenterOfMass;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody} world center of mass -> {_getWorldCenterOfMass}";
		}
	}
}
