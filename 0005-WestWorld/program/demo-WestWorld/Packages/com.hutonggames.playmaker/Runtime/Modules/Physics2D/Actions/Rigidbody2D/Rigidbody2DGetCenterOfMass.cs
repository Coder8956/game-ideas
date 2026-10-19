
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("The center of mass of the rigidBody in local space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-centerOfMass.html")]
	public sealed class Rigidbody2DGetCenterOfMass : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Get Rigidbody2D Center Of Mass")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getCenterOfMass;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _getCenterOfMass);
		}
		
		public override void Execute()
		{
			_getCenterOfMass.Value = _rigidbody2D.Value.centerOfMass;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody2D} center of mass -> {_getCenterOfMass}";
		}
	}
}
