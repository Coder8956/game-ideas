
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Quaternion)]
	[ActionDescription("Returns this quaternion with a magnitude of 1 (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Quaternion-normalized.html")]
	public sealed class QuaternionGetNormalized : BaseAction
	{
		
		[Tooltip("The Quaternion")]
		[SerializeField]
		private QuaternionRef _quaternion;
		
		[Tooltip("Get Quaternion Normalized")]
		[SerializeField]
		[WriteOnly]
		private QuaternionRef _getNormalized;
		
		public override bool CanExecute()
		{
			return CheckParameters(_quaternion, _getNormalized);
		}
		
		public override void Execute()
		{
			_getNormalized.Value = _quaternion.Value.normalized;
		}
		
		public override string GetSummary()
		{
			return "Get {_quaternion} normalized -> {_getNormalized}";
		}
	}
}
