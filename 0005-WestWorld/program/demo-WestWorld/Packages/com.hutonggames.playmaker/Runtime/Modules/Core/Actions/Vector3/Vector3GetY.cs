
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("Y component of the vector.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3-y.html")]
	public sealed class Vector3GetY : BaseAction
	{
		
		[Tooltip("The Vector3")]
		[SerializeField]
		private Vector3Ref _vector3;
		
		[Tooltip("Get Vector3 Y")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getY;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector3, _getY);
		}
		
		public override void Execute()
		{
			_getY.Value = _vector3.Value.y;
		}
		
		public override string GetSummary()
		{
			return "Get {_vector3} y -> {_getY}";
		}
	}
}
