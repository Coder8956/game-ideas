/* use constant
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ActionDescription("Shorthand for writing Vector2(0, 0).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2-zero.html")]
	public sealed class Vector2GetZero : BaseAction
	{
		
		[Tooltip("Get Vector2 Zero")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getZero;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getZero);
		}
		
		public override void Execute()
		{
			_getZero.Value = Vector2.zero;
		}
		
		public override string GetSummary()
		{
			return "Get Vector2 zero -> {_getZero} ";
		}
	}
}
*/