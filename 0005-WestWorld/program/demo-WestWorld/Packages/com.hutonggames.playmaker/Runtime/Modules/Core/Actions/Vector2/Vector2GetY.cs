
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ActionDescription("Y component of the vector.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2-y.html")]
	public sealed class Vector2GetY : BaseAction
	{
		
		[Tooltip("The Vector2")]
		[SerializeField]
		private Vector2Ref _vector2;
		
		[Tooltip("Get Vector2 Y")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getY;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector2, _getY);
		}
		
		public override void Execute()
		{
			_getY.Value = _vector2.Value.y;
		}
		
		public override string GetSummary()
		{
			return "Get {_vector2} y -> {_getY}";
		}
	}
}
