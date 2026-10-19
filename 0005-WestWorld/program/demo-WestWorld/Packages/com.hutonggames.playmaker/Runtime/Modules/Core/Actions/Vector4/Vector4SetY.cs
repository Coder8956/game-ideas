
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector4)]
	[ActionDescription("Y component of the vector.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector4-y.html")]
	public sealed class Vector4SetY : BaseAction
	{
		
		[Tooltip("The Vector4")]
		[SerializeField]
		private Vector4Ref _vector4;
		
		[Tooltip("Set Vector4 Y")]
		[SerializeField]
		private FloatVar _setY;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector4, _setY);
		}
		
		public override void Execute()
		{
			var value = _vector4.Value;
			value.y = _setY.Value;
			_vector4.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_vector4} Y to {_setY}";
		}
	}
}
