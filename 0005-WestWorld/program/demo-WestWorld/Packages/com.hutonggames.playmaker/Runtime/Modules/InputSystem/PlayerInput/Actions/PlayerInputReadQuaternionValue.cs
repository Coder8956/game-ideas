#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.PlayerInput)]
	[ActionDescription("Read the current Quaternion value of the control that is driving this action. " +
	                   "If no bound control is actuated, returns Quaternion.identity.")] 
	public sealed class PlayerInputReadQuaternionValue : PlayerInputReadValueBase
	{
		[Tooltip("Read the current Quaternion value of the control that is driving this action.")]
		[SerializeField, WriteOnly]
		private QuaternionRef _value;

		public override bool CanExecute() => _value.IsAssigned && base.CanExecute();

		public override void Execute()
		{
			var action = GetInputAction();
			_value.Value = action?.ReadValue<Quaternion>() ?? Quaternion.identity;
		}
	}
}

#endif
