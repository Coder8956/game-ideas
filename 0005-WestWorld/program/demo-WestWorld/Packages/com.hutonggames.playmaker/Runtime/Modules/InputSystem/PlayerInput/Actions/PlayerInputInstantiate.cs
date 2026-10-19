#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.InputSystem;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputSystem.PlayerInput)]
	[ActionDescription("Instantiate a player object, set up and enable its inputs.")]
	[HelpURL(HelpUrls.InputSystem+"#UnityEngine_InputSystem_PlayerInput_Instantiate_UnityEngine_GameObject_System_Int32_System_String_System_Int32_UnityEngine_InputSystem_InputDevice_")]

	public sealed class PlayerInputInstantiate : BaseAction
	{
		
		[Tooltip("Prefab to clone. Must contain a PlayerInput component somewhere in its hierarchy.")]
		[SerializeField]
		private GameObjectVar _prefab;
		
		[Tooltip("Player index to assign to the player. " +
		         "By default will be assigned automatically based on how many players are in all.")]
		[SerializeField, DefaultValue(-1)]
		private IntegerVar _playerIndex;
		
		[Tooltip("Control scheme to activate.")]
		[SerializeField]
		private StringVar _controlScheme;
		
		[Tooltip("Which split screen to instantiate on.")]
		[SerializeField, DefaultValue(-1)]
		private IntegerVar _splitScreenIndex;
		
		[Tooltip("Store the result in PlayerInput variable.")]
		[SerializeField]
		[WriteOnly]
		private PlayerInputRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_prefab, _playerIndex, _controlScheme, _splitScreenIndex, _result);
		}
		
		public override void Execute()
		{
			_result.Value = PlayerInput.Instantiate(_prefab.Value, _playerIndex.Value, _controlScheme.Value, _splitScreenIndex.Value);
		}
		
		public override string GetSummary()
		{
			return "Instantiate PlayerInput from {_prefab} -> {_result}";
		}
	}
}

#endif
