
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector4)]
	[ActionDescription("X component of the vector.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector4-x.html")]
	public sealed class Vector4SetX : BaseAction
	{
		
		[Tooltip("The Vector4")]
		[SerializeField]
		private Vector4Ref _vector4;
		
		[Tooltip("Set Vector4 X")]
		[SerializeField]
		private FloatVar _setX;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector4, _setX);
		}
		
		public override void Execute()
		{
			var value = _vector4.Value;
			value.x = _setX.Value;
			_vector4.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_vector4} X to {_setX}";
		}
	}
}
