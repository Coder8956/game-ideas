
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Quaternion)]
	[ActionDescription("The identity rotation (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Quaternion-identity.html")]
	public sealed class QuaternionGetIdentity : BaseAction
	{
		
		[Tooltip("Get Quaternion Identity")]
		[SerializeField]
		[WriteOnly]
		private QuaternionRef _getIdentity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getIdentity);
		}
		
		public override void Execute()
		{
			_getIdentity.Value = Quaternion.identity;
		}
		
		public override string GetSummary()
		{
			return "Get Quaternion identity -> {_getIdentity} ";
		}
	}
}
