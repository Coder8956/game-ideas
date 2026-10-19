
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CharacterController)]
	[ActionDescription("Sets the minimum move distance of the character controller.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CharacterController-minMoveDistance.html" +
		"")]
	public sealed class CharacterControllerSetMinMoveDistance : BaseAction
	{
		
		[Tooltip("The CharacterController")]
		[SerializeField, OwnerDefaultValue]
		private CharacterControllerVar _characterController;
		
		[Tooltip("Set CharacterController Min Move Distance")]
		[SerializeField]
		private FloatVar _setMinMoveDistance;
		
		public override bool CanExecute()
		{
			return CheckParameters(_characterController, _setMinMoveDistance);
		}
		
		public override void Execute()
		{
			_characterController.Value.minMoveDistance = _setMinMoveDistance.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_characterController} min move distance to {_setMinMoveDistance}";
		}
	}
}
