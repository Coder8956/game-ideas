
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	[Serializable]
	[ActionCategory(Category.Vector2)]
	[ActionDescription("Clamps the Vector2 to the bounds given by min and max.")]
	public sealed class Vector2Clamp : BaseAction
	{
		
		[Tooltip("The Vector2.")]
		[SerializeField]
		private Vector2Ref _vector2;
		
		[Tooltip("Min.")]
		[SerializeField]
		private Vector2Var _min;
		
		[Tooltip("Max.")]
		[SerializeField]
		private Vector2Var _max;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector2, _min, _max);
		}
		
		public override void Execute()
		{
			_vector2.Value = new Vector2(
				Mathf.Clamp(_vector2.Value.x, _min.Value.x, _max.Value.x),
				Mathf.Clamp(_vector2.Value.y, _min.Value.y, _max.Value.y)
			);
		}
		
		public override string GetSummary()
		{
			return "Clamp {_vector2} to {_min} {_max} ";
		}
	}
}
