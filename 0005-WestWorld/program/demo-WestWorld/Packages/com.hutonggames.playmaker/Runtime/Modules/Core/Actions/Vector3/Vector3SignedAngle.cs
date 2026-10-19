
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("Calculates the signed angle between vectors from and to in relation to axis.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3.SignedAngle.html")]
	public sealed class Vector3SignedAngle : BaseAction
	{
		
		[Tooltip("The vector from which the angular difference is measured.")]
		[SerializeField]
		private Vector3Var _from;
		
		[Tooltip("The vector to which the angular difference is measured.")]
		[SerializeField]
		private Vector3Var _to;
		
		[Tooltip("A vector around which the other vectors are rotated.")]
		[SerializeField]
		private Vector3Var _axis;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_from, _to, _axis, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Vector3.SignedAngle(UnityEngine.Vector3, UnityEngine.Vector3, UnityEngine.Vector3);
			_result.Value = Vector3.SignedAngle(_from.Value, _to.Value, _axis.Value);
		}
		
		public override string GetSummary()
		{
			return "Vector3 Signed Angle: {_from} {_to} {_axis} -> {_result}";
		}
	}
}
