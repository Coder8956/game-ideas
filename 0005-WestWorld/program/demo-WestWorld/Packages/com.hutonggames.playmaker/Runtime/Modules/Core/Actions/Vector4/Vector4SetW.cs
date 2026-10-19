
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector4)]
	[ActionDescription("W component of the vector.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector4-w.html")]
	public sealed class Vector4SetW : BaseAction
	{
		
		[Tooltip("The Vector4")]
		[SerializeField]
		private Vector4Ref _vector4;
		
		[Tooltip("Set Vector4 W")]
		[SerializeField]
		private FloatVar _setW;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector4, _setW);
		}
		
		public override void Execute()
		{
			var value = _vector4.Value;
			value.w = _setW.Value;
			_vector4.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_vector4} W to {_setW}";
		}
	}
}
