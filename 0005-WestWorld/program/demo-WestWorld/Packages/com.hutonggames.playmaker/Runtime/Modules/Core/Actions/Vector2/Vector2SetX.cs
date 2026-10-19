
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ActionDescription("X component of the vector.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2-x.html")]
	public sealed class Vector2SetX : BaseAction
	{
		
		[Tooltip("The Vector2")]
		[SerializeField]
		private Vector2Ref _vector2;
		
		[Tooltip("Set Vector2 X")]
		[SerializeField]
		private FloatVar _setX;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector2, _setX);
		}
		
		public override void Execute()
		{
			var value = _vector2.Value;
			value.x = _setX.Value;
			_vector2.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_vector2} X to {_setX}";
		}
	}
}
