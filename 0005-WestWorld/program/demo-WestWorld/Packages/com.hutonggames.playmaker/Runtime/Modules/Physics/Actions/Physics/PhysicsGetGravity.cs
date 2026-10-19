
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PhysicsSettings)]
	[ActionDescription("The gravity applied to all rigid bodies in the Scene.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics-gravity.html")]
	public sealed class PhysicsGetGravity : BaseAction
	{
		
		[Tooltip("Get Physics Gravity")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getGravity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getGravity);
		}
		
		public override void Execute()
		{
			_getGravity.Value = Physics.gravity;
		}
		
		public override string GetSummary()
		{
			return "Get Physics gravity -> {_getGravity} ";
		}
	}
}
