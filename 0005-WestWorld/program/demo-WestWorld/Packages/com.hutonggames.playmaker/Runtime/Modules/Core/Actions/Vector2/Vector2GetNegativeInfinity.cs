/* use constant
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ActionDescription("Shorthand for writing Vector2(float.NegativeInfinity, float.NegativeInfinity).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2-negativeInfinity.html")]
	public sealed class Vector2GetNegativeInfinity : BaseAction
	{
		
		[Tooltip("Get Vector2 Negative Infinity")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getNegativeInfinity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getNegativeInfinity);
		}
		
		public override void Execute()
		{
			_getNegativeInfinity.Value = Vector2.negativeInfinity;
		}
		
		public override string GetSummary()
		{
			return "Get Vector2 negativeInfinity -> {_getNegativeInfinity} ";
		}
	}
}
*/