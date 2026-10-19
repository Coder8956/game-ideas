
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Gets the center of mass of the rigidBody in global space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-worldCenterOfMass.html")]
	public sealed class Rigidbody2DGetWorldCenterOfMass : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Get Rigidbody2D World Center Of Mass")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getWorldCenterOfMass;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _getWorldCenterOfMass);
		}
		
		public override void Execute()
		{
			_getWorldCenterOfMass.Value = _rigidbody2D.Value.worldCenterOfMass;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody2D} world center of mass -> {_getWorldCenterOfMass}";
		}
	}
}
