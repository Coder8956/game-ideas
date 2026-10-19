
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
	public sealed class Vector4GetZ : BaseAction
	{
		
		[Tooltip("The Vector4")]
		[SerializeField]
		private Vector4Ref _vector4;
		
		[Tooltip("Get Vector4 Z")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getZ;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector4, _getZ);
		}
		
		public override void Execute()
		{
			_getZ.Value = _vector4.Value.z;
		}
		
		public override string GetSummary()
		{
			return "Get {_vector4} z -> {_getZ}";
		}
	}
}
