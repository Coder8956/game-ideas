
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ActionDescription("Returns the length of this vector (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2-magnitude.html")]
	public sealed class Vector2GetMagnitude : BaseAction
	{
		
		[Tooltip("The Vector2")]
		[SerializeField]
		private Vector2Ref _vector2;
		
		[Tooltip("Get Vector2 Magnitude")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getMagnitude;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector2, _getMagnitude);
		}
		
		public override void Execute()
		{
			_getMagnitude.Value = _vector2.Value.magnitude;
		}
		
		public override string GetSummary()
		{
			return "Get {_vector2} magnitude -> {_getMagnitude}";
		}
	}
}
