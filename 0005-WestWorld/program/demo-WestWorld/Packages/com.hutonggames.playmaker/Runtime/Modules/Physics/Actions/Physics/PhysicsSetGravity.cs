
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PhysicsSettings)]
	[ActionDescription("The gravity applied to all rigid bodies in the Scene.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics-gravity.html")]
	public sealed class PhysicsSetGravity : BaseAction
	{
		
		[Tooltip("Set Physics Gravity")]
		[SerializeField]
		private Vector3Var _setGravity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_setGravity);
		}
		
		public override void Execute()
		{
			Physics.gravity = _setGravity.Value;
		}
		
		public override string GetSummary()
		{
			return "Set Physics Gravity to {_setGravity}";
		}
	}
}
