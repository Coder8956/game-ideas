/* use constant
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ActionDescription("Shorthand for writing Vector2(float.PositiveInfinity, float.PositiveInfinity).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2-positiveInfinity.html")]
	public sealed class Vector2GetPositiveInfinity : BaseAction
	{
		
		[Tooltip("Get Vector2 Positive Infinity")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getPositiveInfinity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getPositiveInfinity);
		}
		
		public override void Execute()
		{
			_getPositiveInfinity.Value = Vector2.positiveInfinity;
		}
		
		public override string GetSummary()
		{
			return "Get Vector2 positiveInfinity -> {_getPositiveInfinity} ";
		}
	}
}
*/