/*
#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;
using UnityEngine.InputSystem;


namespace HutongGames.PlayMaker.Actions.InputActionMap
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.InputActionMap)]
	[ActionDescription("If the action map is part of an asset, this refers to the asset. Otherwise it is null.")]
	[HelpURL(HelpUrls.InputActionMap +"#UnityEngine_InputSystem_InputActionMap_asset")]
	public sealed class InputActionMapGetAsset : BaseAction
	{
		
		[Tooltip("The InputActionMap")]
		[SerializeField]
		private InputActionMapRef _inputActionMap;
		
		[Tooltip("Get InputActionMap Asset")]
		[SerializeField]
		[WriteOnly]
		private InputActionAssetRef _getAsset;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputActionMap, _getAsset);
		}
		
		public override void Execute()
		{
			_getAsset.Value = _inputActionMap.Value.asset;
		}
		
		public override string GetSummary()
		{
			return "Get {_inputActionMap} Asset -> {_getAsset}";
		}
	}
}
#endif
*/