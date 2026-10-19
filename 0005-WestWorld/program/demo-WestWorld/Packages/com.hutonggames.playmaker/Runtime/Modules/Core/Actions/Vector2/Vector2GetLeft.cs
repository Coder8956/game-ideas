/* Use constant
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ActionDescription("Shorthand for writing Vector2(-1, 0).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2-left.html")]
	public sealed class Vector2GetLeft : BaseAction
	{
		
		[Tooltip("Get Vector2 Left")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getLeft;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getLeft);
		}
		
		public override void Execute()
		{
			_getLeft.Value = Vector2.left;
		}
		
		public override string GetSummary()
		{
			return "Get Vector2 left -> {_getLeft} ";
		}
	}
}
*/