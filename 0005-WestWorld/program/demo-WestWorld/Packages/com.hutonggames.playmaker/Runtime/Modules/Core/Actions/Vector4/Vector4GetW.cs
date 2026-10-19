
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
	public sealed class Vector4GetW : BaseAction
	{
		
		[Tooltip("The Vector4")]
		[SerializeField]
		private Vector4Ref _vector4;
		
		[Tooltip("Get Vector4 W")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getW;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector4, _getW);
		}
		
		public override void Execute()
		{
			_getW.Value = _vector4.Value.w;
		}
		
		public override string GetSummary()
		{
			return "Get {_vector4} w -> {_getW}";
		}
	}
}
