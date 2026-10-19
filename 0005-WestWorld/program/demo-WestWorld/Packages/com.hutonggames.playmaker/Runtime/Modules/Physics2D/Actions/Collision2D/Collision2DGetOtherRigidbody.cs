
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collision2D)]
	[ActionDescription("The other Rigidbody2D involved in the collision with the rigidbody.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collision2D-otherRigidbody.html")]
	public sealed class Collision2DGetOtherRigidbody : BaseAction
	{
		
		[Tooltip("The Collision2D")]
		[SerializeField]
		private Collision2DRef _collision2D;
		
		[Tooltip("Get Collision2D Other Rigidbody")]
		[SerializeField]
		[WriteOnly]
		private Rigidbody2DRef _getOtherRigidbody;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collision2D, _getOtherRigidbody);
		}
		
		public override void Execute()
		{
			_getOtherRigidbody.Value = _collision2D.Value.otherRigidbody;
		}
		
		public override string GetSummary()
		{
			return "Get {_collision2D} otherRigidbody -> {_getOtherRigidbody}";
		}
	}
}
