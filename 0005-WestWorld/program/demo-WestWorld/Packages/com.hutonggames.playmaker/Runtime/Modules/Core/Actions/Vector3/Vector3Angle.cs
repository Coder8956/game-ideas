
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("Calculates the angle between two vectors.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3.Angle.html")]
	public sealed class Vector3Angle : BaseAction
	{
		
		[Tooltip("The vector from which the angular difference is measured.")]
		[SerializeField]
		private Vector3Var _from;
		
		[Tooltip("The vector to which the angular difference is measured.")]
		[SerializeField]
		private Vector3Var _to;
		
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
			//UnityEngine.Vector3.Angle(UnityEngine.Vector3, UnityEngine.Vector3);
			_result.Value = Vector3.Angle(_from.Value, _to.Value);
		}
		
		public override string GetSummary()
		{
			return "Vector3 Angle: {_from} {_to} -> {_result}";
		}
	}
}
