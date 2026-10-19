
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ControllerColliderHit)]
	[ActionDescription("How far the character has travelled until it hit the collider.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ControllerColliderHit-moveLength.html")]
	public sealed class ControllerColliderHitGetMoveLength : BaseAction
	{
		
		[Tooltip("The ControllerColliderHit")]
		[SerializeField]
		private ControllerColliderHitRef _controllerColliderHit;
		
		[Tooltip("Get ControllerColliderHit Move Length")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getMoveLength;
		
		public override bool CanExecute()
		{
			return CheckParameters(_controllerColliderHit, _getMoveLength);
		}
		
		public override void Execute()
		{
			_getMoveLength.Value = _controllerColliderHit.Value.moveLength;
		}
		
		public override string GetSummary()
		{
			return "Get {_controllerColliderHit} moveLength -> {_getMoveLength}";
		}
	}
}
