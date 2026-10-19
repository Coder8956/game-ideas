
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Quaternion)]
	[ActionDescription("Returns or sets the euler angle representation of the rotation in degrees.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Quaternion-eulerAngles.html")]
	public sealed class QuaternionGetEulerAngles : BaseAction
	{
		
		[Tooltip("The Quaternion")]
		[SerializeField]
		private QuaternionRef _quaternion;
		
		[Tooltip("Get Quaternion Euler Angles")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getEulerAngles;
		
		public override bool CanExecute()
		{
			return CheckParameters(_quaternion, _getEulerAngles);
		}
		
		public override void Execute()
		{
			_getEulerAngles.Value = _quaternion.Value.eulerAngles;
		}
		
		public override string GetSummary()
		{
			return "Get {_quaternion} eulerAngles -> {_getEulerAngles}";
		}
	}
}
