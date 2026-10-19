
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ConvertibleGroup("Vector3Operator")]
	[ActionDescription("Subtracts one vector from another.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3-operator_add.html")]
	public sealed class Vector3SubtractXYZ : BaseAction
	{
		
		[Tooltip("The Vector3 to subtract from.")]
		[SerializeField, WriteOnly]
		private Vector3Ref _vector3;
		
		[Tooltip("Subtract from x component." + Strings.PerSecondNote)]
		[SerializeField]
		private FloatVar _x;
		
		[Tooltip("Subtract from y component." + Strings.PerSecondNote)]
		[SerializeField]
		private FloatVar _y;
		
		[Tooltip("Subtract from z component." + Strings.PerSecondNote)]
		[SerializeField]
		private FloatVar _z;
		
		public override bool CanUsePerSecond => true;
		
		public override bool CanExecute() => CheckParameters(_vector3, _x, _y, _z);

		public override void Execute() => _vector3.Value -= new Vector3(_x.Value, _y.Value, _z.Value) * PerSecond;

		public override string GetSummary() => "Subtract ({_x},{_y},{_z}) to {_vector3} {PerSecond}";
	}
}
