
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ConvertibleGroup("Vector3Operator")]
	[ActionDescription("Adds two vectors.\n\nAdds corresponding components together.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3-operator_add.html")]
	public sealed class Vector3Add : BaseAction
	{
		
		[Tooltip("The Vector3 to add to.")]
		[SerializeField, WriteOnly, FormerlySerializedAs("_a")]
		private Vector3Ref _vector3;
		
		[ConvertibleName("operand")]
		[Tooltip("Vector3 to add." + Strings.PerSecondNote)]
		[SerializeField, FormerlySerializedAs("_b")]
		private Vector3Var _add;
		
		public override bool CanUsePerSecond => true;
		
		public override bool CanExecute() => CheckParameters(_vector3, _add);

		public override void Execute() => _vector3.Value += _add.Value * PerSecond;

		public override string GetSummary() => "Add {_add} to {_vector3} {PerSecond}";
	}
}
