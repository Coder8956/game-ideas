using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CharacterController)]
	[ActionDescription("Safely teleports a CharacterController by temporarily disabling it, moving its transform, syncing physics, then restoring its enabled state. By default the current rotation is preserved.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CharacterController.html")]
	public sealed class CharacterControllerTeleport : BaseAction
	{
		
		[Tooltip("The CharacterController to teleport.")]
		[SerializeField, OwnerDefaultValue]
		private CharacterControllerVar _characterController;
		
		[Tooltip("The world position to teleport to.")]
		[SerializeField]
		private Vector3Var _position;
		
		[Tooltip("Set a new world rotation during the teleport. If false, the current rotation is preserved.")]
		[SerializeField, DefaultValue(false)]
		private BoolVar _setRotation;
		
		[Tooltip("The world rotation to teleport to.")]
		[SerializeField, DefaultValue("Quaternion.identity"), HideIf(nameof(HideRotation))]
		private QuaternionVar _rotation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_characterController, _position, _setRotation)
			       && (!_setRotation.Value || CheckParameters(_rotation));
		}
		
		public override void Execute()
		{
			var controller = _characterController.Value;
			var transformCache = controller.transform;
			var wasEnabled = controller.enabled;

			if (wasEnabled)
			{
				controller.enabled = false;
			}

			transformCache.position = _position.Value;
			
			if (_setRotation.Value)
			{
				transformCache.rotation = _rotation.Value;
			}

			Physics.SyncTransforms();

			if (wasEnabled)
			{
				controller.enabled = true;
			}
		}
		
		public override string GetSummary()
		{
			return "Teleport {_characterController} to {_position}"
			       + (_setRotation.Value ? " rot {_rotation}" : " keep rotation")
			       + " sync transforms";
		}

		private bool HideRotation() => !_setRotation.Value;
	}
}
