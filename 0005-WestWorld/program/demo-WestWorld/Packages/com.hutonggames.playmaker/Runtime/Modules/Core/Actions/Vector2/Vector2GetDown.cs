/* Use constant
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ActionDescription("Shorthand for writing Vector2(0, -1).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2-down.html")]
	public sealed class Vector2GetDown : BaseAction
	{
		
		[Tooltip("Get Vector2 Down")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getDown;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getDown);
		}
		
		public override void Execute()
		{
			_getDown.Value = Vector2.down;
		}
		
		public override string GetSummary()
		{
			return "Get Vector2 down -> {_getDown} ";
		}
	}
}
*/