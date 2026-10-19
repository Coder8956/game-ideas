
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("X component of the vector.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3-x.html")]
	public sealed class Vector3GetX : BaseAction
	{
		
		[Tooltip("The Vector3")]
		[SerializeField]
		private Vector3Ref _vector3;
		
		[Tooltip("Get Vector3 X")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getX;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector3, _getX);
		}
		
		public override void Execute()
		{
			_getX.Value = _vector3.Value.x;
		}
		
		public override string GetSummary()
		{
			return "Get {_vector3} x -> {_getX}";
		}
	}
}
