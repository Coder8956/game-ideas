
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ConvertibleGroup("Vector2Operator")]
	[ActionDescription("Adds two vectors.\n\nAdds corresponding components together.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2-operator_add.html")]
	public sealed class Vector2Add : BaseAction
	{
		
		[Tooltip("Vector2 to add to.")]
		[SerializeField, WriteOnly, FormerlySerializedAs("_a")]
		private Vector2Ref _vector2;
		
		[Tooltip("Vector2 to add." + Strings.PerSecondNote)]
		[SerializeField, FormerlySerializedAs("_b")]
		private Vector2Var _add;
		
		public override bool CanUsePerSecond => true;
		
		public override bool CanExecute() => CheckParameters(_vector2, _add);

		public override void Execute() => _vector2.Value += _add.Value * PerSecond;

		public override string GetSummary() => "Add {_add} to {_vector2} {PerSecond}";
	}
}
