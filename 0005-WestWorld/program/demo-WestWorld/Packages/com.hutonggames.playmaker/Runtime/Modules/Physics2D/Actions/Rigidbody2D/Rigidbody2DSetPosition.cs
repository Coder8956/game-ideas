
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("The position of the rigidbody.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-position.html")]
	public sealed class Rigidbody2DSetPosition : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Set Rigidbody2D Position")]
		[SerializeField]
		private Vector2Var _setPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _setPosition);
		}
		
		public override void Execute()
		{
			_rigidbody2D.Value.position = _setPosition.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody2D} position to {_setPosition}";
		}
	}
}
