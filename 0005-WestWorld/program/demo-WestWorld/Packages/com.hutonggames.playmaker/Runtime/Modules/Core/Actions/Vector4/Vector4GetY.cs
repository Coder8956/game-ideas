
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
	public sealed class Vector4GetY : BaseAction
	{
		
		[Tooltip("The Vector4")]
		[SerializeField]
		private Vector4Ref _vector4;
		
		[Tooltip("Get Vector4 Y")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getY;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector4, _getY);
		}
		
		public override void Execute()
		{
			_getY.Value = _vector4.Value.y;
		}
		
		public override string GetSummary()
		{
			return "Get {_vector4} y -> {_getY}";
		}
	}
}
