#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.PlayerInput)]
	[ActionDescription("Read the current Vector3 value of the control that is driving this action. " +
	                   "If no bound control is actuated, returns Vector3.zero.")] 
	public sealed class PlayerInputReadVector3Value : PlayerInputReadValueBase
	{
		[Tooltip("Read the current Vector3 value of the control that is driving this action.")]
		[SerializeField, WriteOnly]
		private Vector3Ref _value;

		public override bool CanExecute() => _value.IsAssigned && base.CanExecute();

		public override void Execute()
		{
			var action = GetInputAction();
			_value.Value = action?.ReadValue<Vector3>() ?? Vector3.zero;
		}
	}
}

#endif
