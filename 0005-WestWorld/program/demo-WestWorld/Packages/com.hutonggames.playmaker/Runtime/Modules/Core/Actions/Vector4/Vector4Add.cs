
using System;
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector4)]
	[ConvertibleGroup("Vector4Operator")]
	[ActionDescription("Adds two vectors.\n\nAdds corresponding components together.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector4-operator_add.html")]
	public sealed class Vector4Add : BaseAction
	{
		
		[Tooltip("A.")]
		[SerializeField, WriteOnly]
		private Vector4Ref _a;
		
		[Tooltip("B." + Strings.PerSecondNote)]
		[SerializeField]
		private Vector4Var _b;
		
		public override bool CanUsePerSecond => true;
		
		public override bool CanExecute() => CheckParameters(_a, _b);

		public override void Execute() => _a.Value += _b.Value * PerSecond;

		public override string GetSummary() => "Add {_b} to {_a} {PerSecond}";
	}
}
