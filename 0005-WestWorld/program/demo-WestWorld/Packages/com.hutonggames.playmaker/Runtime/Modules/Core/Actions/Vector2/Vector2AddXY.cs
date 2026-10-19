
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ConvertibleGroup("Vector2Operator")]
	[ActionDescription("Adds two vectors.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2-operator_add.html")]
	public sealed class Vector2AddXY : BaseAction
	{
		
		[Tooltip("The Vector2 to add to.")]
		[SerializeField, WriteOnly]
		private Vector2Ref _vector2;
		
		[Tooltip("Add to x component." + Strings.PerSecondNote)]
		[SerializeField]
		private FloatVar _x;
		
		[Tooltip("Add to y component." + Strings.PerSecondNote)]
		[SerializeField]
		private FloatVar _y;
		
		public override bool CanUsePerSecond => true;
		
		public override bool CanExecute() => CheckParameters(_vector2, _x, _y);

		public override void Execute() => _vector2.Value += new Vector2(_x.Value, _y.Value) * PerSecond;

		public override string GetSummary() => "Add ({_x},{_y}) to {_vector2} {PerSecond}";
	}
}
