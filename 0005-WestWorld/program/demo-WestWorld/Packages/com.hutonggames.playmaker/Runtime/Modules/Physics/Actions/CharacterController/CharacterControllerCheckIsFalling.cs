
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CharacterController)]
	[ConvertibleGroup("CharacterControllerGrounded")]
	[ActionDescription("Uses a support probe based on the CharacterController shape to check if it is falling. " +
	                   "This is more reliable than isGrounded alone on slopes, stairs, and ledges. " +
	                   "<br/>This check pairs best with CharacterControllerFall for gravity-only unsupported descent.")]
	public sealed class CharacterControllerCheckIsFalling : BaseTrueFalseAction
	{
		private const float GroundCastPadding = 0.01f;
		private readonly RaycastHit[] _hits = new RaycastHit[8];

		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
		
		[Tooltip("The CharacterController.")]
		[SerializeField, OwnerDefaultValue]
		private CharacterControllerVar _characterController;

		[Tooltip("Extra distance below the CharacterController to check for support." +
		         "The Character Controller's Step Offset should work well here.")]
		[SerializeField, DefaultValue(0.3f)]
		private FloatVar _rayLength;
		
		public override bool CanExecute() => CheckParameters(_characterController, _rayLength) && base.CanExecute();

		protected override bool Test()
		{
			var controller = _characterController.Value;
			if (!controller) return false;

			return !CheckGrounded(controller);
		}
		
		private bool CheckGrounded(CharacterController controller)
		{
			if (controller.isGrounded)
			{
				return true;
			}

			var transformCache = controller.transform;
			var up = transformCache.up;
			var radius = GetScaledRadius(controller);
			var origin = GetBottomSphereCenter(controller, radius) + up * GroundCastPadding;
			var maxDistance = Mathf.Max(_rayLength.Value + GroundCastPadding, GroundCastPadding * 2f);
			var minGroundDot = Mathf.Cos(controller.slopeLimit * Mathf.Deg2Rad);

			var hitCount = Physics.SphereCastNonAlloc(origin,
			                                          radius,
			                                          -up,
			                                          _hits,
			                                          maxDistance,
			                                          Physics.DefaultRaycastLayers,
			                                          QueryTriggerInteraction.Ignore);

			for (var i = 0; i < hitCount; ++i)
			{
				var hit = _hits[i];
				var collider = hit.collider;
				if (!collider)
				{
					continue;
				}

				var hitTransform = collider.transform;
				if (hitTransform == transformCache || hitTransform.IsChildOf(transformCache))
				{
					continue;
				}

				if (Vector3.Dot(hit.normal, up) < minGroundDot)
				{
					continue;
				}

				return true;
			}

			return false;
		}

		private static Vector3 GetBottomSphereCenter(CharacterController controller, float radius)
		{
			var transformCache = controller.transform;
			var absScale = Abs(transformCache.lossyScale);
			var height = Mathf.Max(controller.height * absScale.y, radius * 2f);
			var worldCenter = transformCache.TransformPoint(controller.center);
			return worldCenter - transformCache.up * (height * 0.5f - radius);
		}

		private static float GetScaledRadius(CharacterController controller)
		{
			var transformCache = controller.transform;
			var absScale = Abs(transformCache.lossyScale);
			var scale = Mathf.Max(absScale.x, absScale.z);
			var radius = controller.radius * scale;
			var skinWidth = controller.skinWidth * scale;
			return Mathf.Max(radius - skinWidth, 0.01f);
		}

		private static Vector3 Abs(Vector3 value)
		{
			return new Vector3(Mathf.Abs(value.x), Mathf.Abs(value.y), Mathf.Abs(value.z));
		}

		protected override string TrueSummary => "{_characterController} is falling";
		protected override string FalseSummary => "{_characterController} is not falling";
	}
}
