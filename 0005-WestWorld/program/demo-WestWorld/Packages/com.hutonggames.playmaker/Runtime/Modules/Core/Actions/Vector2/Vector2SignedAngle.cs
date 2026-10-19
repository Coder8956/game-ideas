
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ActionDescription("Gets the signed angle in degrees between from and to.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2.SignedAngle.html")]
	public sealed class Vector2SignedAngle : BaseAction
	{
		
		[Tooltip("The vector from which the angular difference is measured.")]
		[SerializeField]
		private Vector2Var _from;
		
		[Tooltip("The vector to which the angular difference is measured.")]
		[SerializeField]
		private Vector2Var _to;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_from, _to, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Vector2.SignedAngle(UnityEngine.Vector2, UnityEngine.Vector2);
			_result.Value = Vector2.SignedAngle(_from.Value, _to.Value);
		}
		
		public override string GetSummary()
		{
			return "Vector2 Signed Angle: {_from} {_to} -> {_result}";
		}
	}
}
