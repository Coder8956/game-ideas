
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CharacterController)]
	[ActionDescription("The center of the character\'s capsule relative to the transform\'s position.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CharacterController-center.html")]
	public sealed class CharacterControllerGetCenter : BaseAction
	{
		
		[Tooltip("The CharacterController")]
		[SerializeField, OwnerDefaultValue]
		private CharacterControllerVar _characterController;
		
		[Tooltip("Get CharacterController Center")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getCenter;
		
		public override bool CanExecute()
		{
			return CheckParameters(_characterController, _getCenter);
		}
		
		public override void Execute()
		{
			_getCenter.Value = _characterController.Value.center;
		}
		
		public override string GetSummary()
		{
			return "Get {_characterController} center -> {_getCenter}";
		}
	}
}
