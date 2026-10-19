/* Use constant
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ActionDescription("Shorthand for writing Vector2(1, 0).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2-right.html")]
	public sealed class Vector2GetRight : BaseAction
	{
		
		[Tooltip("Get Vector2 Right")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getRight;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getRight);
		}
		
		public override void Execute()
		{
			_getRight.Value = Vector2.right;
		}
		
		public override string GetSummary()
		{
			return "Get Vector2 right -> {_getRight} ";
		}
	}
}
*/