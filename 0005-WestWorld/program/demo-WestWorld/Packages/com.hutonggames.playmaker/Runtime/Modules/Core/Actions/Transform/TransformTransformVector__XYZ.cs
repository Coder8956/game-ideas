
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ConvertibleGroup("TransformTransform")]
	[ActionDescription("Transforms vector x, y, z from local space to world space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform.TransformVector.html")]
	public sealed class TransformTransformVector__XYZ : BaseAction
	{
		[OwnerDefaultValue]
		[Tooltip("The Transform.")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("X.")]
		[SerializeField]
		private FloatVar _x;
		
		[Tooltip("Y.")]
		[SerializeField]
		private FloatVar _y;
		
		[Tooltip("Z.")]
		[SerializeField]
		private FloatVar _z;
		
		[Tooltip("Store the result in Vector3 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_transform, _x, _y, _z, _result);
		}
		
		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			_result.Value = transform.TransformVector(_x.Value, _y.Value, _z.Value);
		}
		
		public override string GetSummary()
		{
			return " {_transform} Transform Vector {_x} {_y} {_z} -> {_result}";
		}
	}
}
