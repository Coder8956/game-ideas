
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Quaternion)]
	[ConvertibleGroup("QuaternionLookRotation")]
	[ActionDescription("Creates a rotation with the specified forward direction.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Quaternion.LookRotation.html")]
	public sealed class QuaternionLookRotation : BaseAction
	{
		
		[Tooltip("The direction to look in.")]
		[SerializeField]
		private Vector3Var _forward;
		
		[Tooltip("Store the result in Quaternion variable.")]
		[SerializeField]
		[WriteOnly]
		private QuaternionRef _result;
		
		public override bool CanExecute() => CheckParameters(_forward, _result);

		public override void Execute()
		{
			//UnityEngine.Quaternion.LookRotation(UnityEngine.Vector3);
			_result.Value = Quaternion.LookRotation(_forward.Value);
		}
		
		public override string GetSummary() => "Look Rotation: {_forward} -> {_result}";
	}
}
