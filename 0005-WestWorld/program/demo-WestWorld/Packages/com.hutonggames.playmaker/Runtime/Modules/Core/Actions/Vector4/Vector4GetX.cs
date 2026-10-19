
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
	public sealed class Vector4GetX : BaseAction
	{
		
		[Tooltip("The Vector4")]
		[SerializeField]
		private Vector4Ref _vector4;
		
		[Tooltip("Get Vector4 X")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getX;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector4, _getX);
		}
		
		public override void Execute()
		{
			_getX.Value = _vector4.Value.x;
		}
		
		public override string GetSummary()
		{
			return "Get {_vector4} x -> {_getX}";
		}
	}
}
