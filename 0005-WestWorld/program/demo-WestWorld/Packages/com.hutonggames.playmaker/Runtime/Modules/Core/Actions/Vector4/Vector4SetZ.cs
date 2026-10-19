
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector4)]
	[ActionDescription("Z component of the vector.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector4-z.html")]
	public sealed class Vector4SetZ : BaseAction
	{
		
		[Tooltip("The Vector4")]
		[SerializeField]
		private Vector4Ref _vector4;
		
		[Tooltip("Set Vector4 Z")]
		[SerializeField]
		private FloatVar _setZ;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector4, _setZ);
		}
		
		public override void Execute()
		{
			var value = _vector4.Value;
			value.z = _setZ.Value;
			_vector4.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_vector4} Z to {_setZ}";
		}
	}
}
