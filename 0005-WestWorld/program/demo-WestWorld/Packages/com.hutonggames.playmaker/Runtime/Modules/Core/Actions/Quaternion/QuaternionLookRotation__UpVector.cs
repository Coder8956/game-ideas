
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Quaternion)]
	[ConvertibleGroup("QuaternionLookRotation")]
	[ActionDescription("Creates a rotation with the specified forward and upwards directions.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Quaternion.LookRotation.html")]
	public sealed class QuaternionLookRotation__UpVector : BaseAction
	{
		
		[Tooltip("The direction to look in.")]
		[SerializeField]
		private Vector3Var _forward;
		
		[DefaultValue("Vector3.up")]
		[Tooltip("The vector that defines in which direction up is.")]
		[SerializeField]
		private Vector3Var _upwards;
		
		[Tooltip("Store the result in Quaternion variable.")]
		[SerializeField]
		[WriteOnly]
		private QuaternionRef _result;
		
		public override bool CanExecute() => CheckParameters(_forward, _upwards, _result);

		public override void Execute()
		{
			//UnityEngine.Quaternion.LookRotation(UnityEngine.Vector3, UnityEngine.Vector3);
			_result.Value = Quaternion.LookRotation(_forward.Value, _upwards.Value);
		}
		
		public override string GetSummary() => "Look Rotation: {_forward} Up: {_upwards} -> {_result}";
	}
}
