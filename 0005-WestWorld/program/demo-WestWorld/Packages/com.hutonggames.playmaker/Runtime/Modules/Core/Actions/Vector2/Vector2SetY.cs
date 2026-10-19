
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ActionDescription("Y component of the vector.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2-y.html")]
	public sealed class Vector2SetY : BaseAction
	{
		
		[Tooltip("The Vector2")]
		[SerializeField]
		private Vector2Ref _vector2;
		
		[Tooltip("Set Vector2 Y")]
		[SerializeField]
		private FloatVar _setY;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector2, _setY);
		}
		
		public override void Execute()
		{
			var value = _vector2.Value;
			value.y = _setY.Value;
			_vector2.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_vector2} Y to {_setY}";
		}
	}
}
