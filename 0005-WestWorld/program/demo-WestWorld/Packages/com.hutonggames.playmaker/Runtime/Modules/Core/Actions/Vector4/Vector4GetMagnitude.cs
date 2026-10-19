
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector4)]
	[ActionDescription("Returns the length of this vector (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector4-magnitude.html")]
	public sealed class Vector4GetMagnitude : BaseAction
	{
		
		[Tooltip("The Vector4")]
		[SerializeField]
		private Vector4Ref _vector4;
		
		[Tooltip("Get Vector4 Magnitude")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getMagnitude;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector4, _getMagnitude);
		}
		
		public override void Execute()
		{
			_getMagnitude.Value = _vector4.Value.magnitude;
		}
		
		public override string GetSummary()
		{
			return "Get {_vector4} magnitude -> {_getMagnitude}";
		}
	}
}
