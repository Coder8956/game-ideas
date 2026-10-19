/* Use constant
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ActionDescription("Shorthand for writing Vector2(1, 1).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2-one.html")]
	public sealed class Vector2GetOne : BaseAction
	{
		
		[Tooltip("Get Vector2 One")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getOne;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getOne);
		}
		
		public override void Execute()
		{
			_getOne.Value = Vector2.one;
		}
		
		public override string GetSummary()
		{
			return "Get Vector2 one -> {_getOne} ";
		}
	}
}
*/