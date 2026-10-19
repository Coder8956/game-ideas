
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Quaternion)]
	[ActionDescription("Align a Quaternion to the specified Direction.")]
	public sealed class QuaternionAlignToDirection : BaseAction
	{
		[Tooltip("The Quaternion to align.")]
		[SerializeField]
		private QuaternionRef _quaternion;
		
		[Tooltip("Axis to align to direction.")]
		[SerializeField]
		private AxisDirectionVar _alignAxis;
		
		[Tooltip("Direction to align to.")]
		[SerializeField, DefaultValue("Vector3.right")]
		private Vector3Var _direction;
		
		public override bool CanExecute() => CheckParameters(_quaternion, _direction, _alignAxis);

		public override void Execute()
		{
			var fromDirection = _alignAxis.Value.GetDirection();
			_quaternion.Value = Quaternion.FromToRotation(fromDirection, _direction.Value);
		}

		public override string GetSummary() => "Align {_quaternion}  {_alignAxis} To Direction {_direction}";
	}
}
