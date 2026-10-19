
using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable, PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ConvertibleGroup("Vector3Operator")]
	[ActionDescription("Add multiple Vector3 values to a Vector3 variable.\n\nAdds corresponding components together.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3-operator_add.html")]
	public sealed class Vector3AddMultiple : BaseAction
	{
		
		[Tooltip("Vector3 to add to.")]
		[SerializeField, WriteOnly]
		private Vector3Ref _Vector3;
		
		[Tooltip("Vector3 values to add." + Strings.PerSecondNote)]
		[SerializeField]
		private List<Vector3Var> _add;
		
		public override bool CanUsePerSecond => true;
		
		public override bool CanExecute() => CheckParameters(_Vector3, _add);

		public override void Execute()
		{
			foreach (var add in _add)
			{
				_Vector3.Value += add.Value * PerSecond;
			}
		}

		public override string GetSummary() => "Add {_add} to {_Vector3} {PerSecond}";
	}
}
