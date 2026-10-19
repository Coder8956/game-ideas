
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector4)]
	[ActionDescription("Returns the squared length of this vector (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector4-sqrMagnitude.html")]
	public sealed class Vector4GetSqrMagnitude : BaseAction
	{
		
		[Tooltip("The Vector4")]
		[SerializeField]
		private Vector4Ref _vector4;
		
		[Tooltip("Get Vector4 Sqr Magnitude")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getSqrMagnitude;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector4, _getSqrMagnitude);
		}
		
		public override void Execute()
		{
			_getSqrMagnitude.Value = _vector4.Value.sqrMagnitude;
		}
		
		public override string GetSummary()
		{
			return "Get {_vector4} sqrMagnitude -> {_getSqrMagnitude}";
		}
	}
}
