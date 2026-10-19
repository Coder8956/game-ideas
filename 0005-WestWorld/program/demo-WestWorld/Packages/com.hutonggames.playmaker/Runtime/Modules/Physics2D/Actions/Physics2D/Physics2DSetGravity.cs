
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Physics2D)]
	[ActionDescription("Acceleration due to gravity.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics2D-gravity.html")]
	public sealed class Physics2DSetGravity : BaseAction
	{
		
		[Tooltip("Set Physics2D Gravity")]
		[SerializeField]
		private Vector2Var _setGravity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_setGravity);
		}
		
		public override void Execute()
		{
			Physics2D.gravity = _setGravity.Value;
		}
		
		public override string GetSummary()
		{
			return "Set Physics2D Gravity to {_setGravity}";
		}
	}
}
