
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Quaternion)]
	[ActionDescription("Creates a rotation with the specified forward direction.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Quaternion.SetLookRotation.html")]
	public sealed class QuaternionSetLookRotation : BaseAction
	{
		
		[Tooltip("The Quaternion.")]
		[SerializeField]
		private QuaternionRef _quaternion;
		
		[Tooltip("The direction to look in.")]
		[SerializeField]
		private Vector3Var _view;
		
		public override bool CanExecute() => CheckParameters(_quaternion, _view);

		public override void Execute()
		{
			//UnityEngine.Quaternion.SetLookRotation(UnityEngine.Vector3);
			_quaternion.Value.SetLookRotation(_view.Value);
		}
		
		public override string GetSummary() => "Set Look Rotation {_quaternion} {_view} ";
	}
}
