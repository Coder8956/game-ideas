
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Physics2D)]
	[ActionDescription("Get the acceleration due to gravity.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics2D-gravity.html")]
	public sealed class Physics2DGetGravity : BaseAction
	{
		
		[Tooltip("Get Physics2D Gravity")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getGravity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getGravity);
		}
		
		public override void Execute()
		{
			_getGravity.Value = Physics2D.gravity;
		}
		
		public override string GetSummary()
		{
			return "Get Physics2D gravity -> {_getGravity} ";
		}
	}
}
