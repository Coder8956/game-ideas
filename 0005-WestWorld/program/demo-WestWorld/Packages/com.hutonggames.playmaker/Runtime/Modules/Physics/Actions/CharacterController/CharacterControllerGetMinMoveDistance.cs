
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CharacterController)]
	[ActionDescription("Gets the minimum move distance of the character controller.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CharacterController-minMoveDistance.html")]
	public sealed class CharacterControllerGetMinMoveDistance : BaseAction
	{
		
		[Tooltip("The CharacterController")]
		[SerializeField, OwnerDefaultValue]
		private CharacterControllerVar _characterController;
		
		[Tooltip("Get CharacterController Min Move Distance")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getMinMoveDistance;
		
		public override bool CanExecute()
		{
			return CheckParameters(_characterController, _getMinMoveDistance);
		}
		
		public override void Execute()
		{
			_getMinMoveDistance.Value = _characterController.Value.minMoveDistance;
		}
		
		public override string GetSummary()
		{
			return "Get {_characterController} min move distance -> {_getMinMoveDistance}";
		}
	}
}
