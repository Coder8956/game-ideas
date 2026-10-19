
using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable, PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ConvertibleGroup("Vector2Operator")]
	[ActionDescription("Add multiple Vector2 values to a Vector2 variable.\n\nAdds corresponding components together.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2-operator_add.html")]
	public sealed class Vector2AddMultiple : BaseAction
	{
		
		[Tooltip("Vector2 to add to.")]
		[SerializeField, WriteOnly]
		private Vector2Ref _vector2;
		
		[Tooltip("Vector2 values to add." + Strings.PerSecondNote)]
		[SerializeField]
		private List<Vector2Var> _add;
		
		public override bool CanUsePerSecond => true;
		
		public override bool CanExecute() => CheckParameters(_vector2, _add);

		public override void Execute()
		{
			foreach (var add in _add)
			{
				_vector2.Value += add.Value * PerSecond;
			}
		}

		public override string GetSummary() => "Add {_add} to {_vector2} {PerSecond}";
	}
}
