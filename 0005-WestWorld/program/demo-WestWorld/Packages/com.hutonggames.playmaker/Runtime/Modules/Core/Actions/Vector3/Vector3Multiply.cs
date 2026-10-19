
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ConvertibleGroup("Vector3Operator")]
	[ActionDescription("Multiplies a Vector3 by a float value.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3-operator_multiply.html")]
	public sealed class Vector3Multiply : BaseAction
	{
		
		[Tooltip("The Vector3 to multiply.")]
		[SerializeField, WriteOnly, FormerlySerializedAs("_a")]
		private Vector3Ref _vector3;
		
		[ConvertibleName("operand")]
		[Tooltip("Multiply by this float.")]
		[SerializeField, FormerlySerializedAs("_b")]
		private FloatVar _multiply;
		
		public override bool CanExecute() => CheckParameters(_vector3, _multiply);

		public override void Execute() => _vector3.Value *= _multiply.Value;

		public override string GetSummary() => "Multiply {_vector3} by {_multiply}";
	}
}
