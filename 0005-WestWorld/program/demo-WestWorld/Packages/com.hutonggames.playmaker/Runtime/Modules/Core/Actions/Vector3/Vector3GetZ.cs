
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("Z component of the vector.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3-z.html")]
	public sealed class Vector3GetZ : BaseAction
	{
		
		[Tooltip("The Vector3")]
		[SerializeField]
		private Vector3Ref _vector3;
		
		[Tooltip("Get Vector3 Z")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getZ;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector3, _getZ);
		}
		
		public override void Execute()
		{
			_getZ.Value = _vector3.Value.z;
		}
		
		public override string GetSummary()
		{
			return "Get {_vector3} z -> {_getZ}";
		}
	}
}
