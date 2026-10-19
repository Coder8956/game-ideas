
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ActionDescription("Returns the 2D vector perpendicular to this 2D vector. The result is always rotat" +
		"ed 90-degrees in a counter-clockwise direction for a 2D coordinate system where " +
		"the positive Y axis goes up.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2.Perpendicular.html")]
	public sealed class Vector2Perpendicular : BaseAction
	{
		
		[Tooltip("The input direction.")]
		[SerializeField]
		private Vector2Var _inDirection;
		
		[Tooltip("Store the result in Vector2 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inDirection, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Vector2.Perpendicular(UnityEngine.Vector2);
			_result.Value = Vector2.Perpendicular(_inDirection.Value);
		}
		
		public override string GetSummary()
		{
			return "Vector2 Perpendicular: {_inDirection} -> {_result}";
		}
	}
}
