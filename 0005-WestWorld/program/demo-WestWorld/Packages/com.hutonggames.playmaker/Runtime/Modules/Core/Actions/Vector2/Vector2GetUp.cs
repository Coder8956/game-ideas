/* Use constant
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ActionDescription("Shorthand for writing Vector2(0, 1).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2-up.html")]
	public sealed class Vector2GetUp : BaseAction
	{
		
		[Tooltip("Get Vector2 Up")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getUp;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getUp);
		}
		
		public override void Execute()
		{
			_getUp.Value = Vector2.up;
		}
		
		public override string GetSummary()
		{
			return "Get Vector2 up -> {_getUp} ";
		}
	}
}
*/