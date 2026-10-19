
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ActionDescription("Returns the squared length of this vector (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2-sqrMagnitude.html")]
	public sealed class Vector2GetSqrMagnitude : BaseAction
	{
		
		[Tooltip("The Vector2")]
		[SerializeField]
		private Vector2Ref _vector2;
		
		[Tooltip("Get Vector2 Sqr Magnitude")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getSqrMagnitude;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector2, _getSqrMagnitude);
		}
		
		public override void Execute()
		{
			_getSqrMagnitude.Value = _vector2.Value.sqrMagnitude;
		}
		
		public override string GetSummary()
		{
			return "Get {_vector2} sqrMagnitude -> {_getSqrMagnitude}";
		}
	}
}
