
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Set the value of a Camera variable.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.html")]
	public sealed class CameraSetValue : BaseAction
	{
		
		[DefaultName("Camera")]
		[Tooltip("The Camera variable to set.")]
		[SerializeField]
		[WriteOnly]
		private CameraRef _variable;
		
		[Tooltip("Set Camera value.")]
		[SerializeField]
		private CameraVar _setValue;
		
		public override bool CanExecute() => !_variable.IsNone;
		
		public override void Execute()
		{
			_variable.Value = _setValue.Value;
		}
		
		public override string GetSummary() => "Set {_variable} to {_setValue}";
	}
}
