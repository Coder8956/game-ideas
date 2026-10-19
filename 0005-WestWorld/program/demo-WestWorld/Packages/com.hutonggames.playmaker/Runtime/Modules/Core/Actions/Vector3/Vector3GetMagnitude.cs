
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("Returns the length of this vector (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3-magnitude.html")]
	public sealed class Vector3GetMagnitude : BaseAction
	{
		
		[Tooltip("The Vector3")]
		[SerializeField]
		private Vector3Ref _vector3;
		
		[Tooltip("Get Vector3 Magnitude")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getMagnitude;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector3, _getMagnitude);
		}
		
		public override void Execute()
		{
			_getMagnitude.Value = _vector3.Value.magnitude;
		}
		
		public override string GetSummary()
		{
			return "Get {_vector3} magnitude -> {_getMagnitude}";
		}
	}
}
