#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.PlayerInput)]
	[ActionDescription("Read the current bool value of the control that is driving this action. " +
	                   "If no bound control is actuated, returns false.")] 
	public sealed class PlayerInputReadBoolValue : PlayerInputReadValueBase
	{
		[Tooltip("Read the current bool value of the control that is driving this action.")]
		[SerializeField, WriteOnly]
		private BoolRef _value;

		public override bool CanExecute() => _value.IsAssigned && base.CanExecute();

		public override void Execute()
		{
			var action = GetInputAction();
			_value.Value = action?.ReadValue<bool>() ?? false;
		}
	}
}

#endif
