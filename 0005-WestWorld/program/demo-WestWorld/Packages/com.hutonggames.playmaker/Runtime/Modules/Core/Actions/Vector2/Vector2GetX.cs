
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ActionDescription("X component of the vector.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2-x.html")]
	public sealed class Vector2GetX : BaseAction
	{
		
		[Tooltip("The Vector2")]
		[SerializeField]
		private Vector2Ref _vector2;
		
		[Tooltip("Get Vector2 X")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getX;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector2, _getX);
		}
		
		public override void Execute()
		{
			_getX.Value = _vector2.Value.x;
		}
		
		public override string GetSummary()
		{
			return "Get {_vector2} x -> {_getX}";
		}
	}
}
