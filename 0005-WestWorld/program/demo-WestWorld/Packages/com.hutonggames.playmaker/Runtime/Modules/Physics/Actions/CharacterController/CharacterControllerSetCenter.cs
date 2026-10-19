
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CharacterController)]
	[ActionDescription("The center of the character\'s capsule relative to the transform\'s position.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CharacterController-center.html")]
	public sealed class CharacterControllerSetCenter : BaseAction
	{
		
		[Tooltip("The CharacterController")]
		[SerializeField, OwnerDefaultValue]
		private CharacterControllerVar _characterController;
		
		[Tooltip("Set CharacterController Center")]
		[SerializeField]
		private Vector3Var _setCenter;
		
		public override bool CanExecute()
		{
			return CheckParameters(_characterController, _setCenter);
		}
		
		public override void Execute()
		{
			_characterController.Value.center = _setCenter.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_characterController} center to {_setCenter}";
		}
	}
}
