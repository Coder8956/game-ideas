
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Quaternion)]
	[ActionDescription("Creates a rotation from fromDirection to toDirection.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Quaternion.FromToRotation.html")]
	public sealed class QuaternionFromToRotation : BaseAction
	{
		
		[Tooltip("A non-unit or unit vector representing a direction axis to rotate.")]
		[SerializeField]
		private Vector3Var _fromDirection;
		
		[Tooltip("A non-unit or unit vector representing the target direction axis.")]
		[SerializeField]
		private Vector3Var _toDirection;
		
		[Tooltip("Store the result in Quaternion variable.")]
		[SerializeField]
		[WriteOnly]
		private QuaternionRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_fromDirection, _toDirection, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Quaternion.FromToRotation(UnityEngine.Vector3, UnityEngine.Vector3);
			_result.Value = Quaternion.FromToRotation(_fromDirection.Value, _toDirection.Value);
		}
		
		public override string GetSummary()
		{
			return "Quaternion From To Rotation: {_fromDirection} {_toDirection} -> {_result}";
		}
	}
}
