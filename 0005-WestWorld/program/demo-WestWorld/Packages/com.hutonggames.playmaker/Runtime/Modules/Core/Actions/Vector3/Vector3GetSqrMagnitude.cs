
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("Returns the squared length of this vector (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3-sqrMagnitude.html")]
	public sealed class Vector3GetSqrMagnitude : BaseAction
	{
		
		[Tooltip("The Vector3")]
		[SerializeField]
		private Vector3Ref _vector3;
		
		[Tooltip("Get Vector3 Sqr Magnitude")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getSqrMagnitude;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector3, _getSqrMagnitude);
		}
		
		public override void Execute()
		{
			_getSqrMagnitude.Value = _vector3.Value.sqrMagnitude;
		}
		
		public override string GetSummary()
		{
			return "Get {_vector3} sqrMagnitude -> {_getSqrMagnitude}";
		}
	}
}
