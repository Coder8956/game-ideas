
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collision2D)]
	[ActionDescription("The Transform of the incoming object involved in the collision.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collision2D-transform.html")]
	public sealed class Collision2DGetTransform : BaseAction
	{
		
		[Tooltip("The Collision2D")]
		[SerializeField]
		private Collision2DRef _collision2D;
		
		[Tooltip("Get Collision2D Transform")]
		[SerializeField]
		[WriteOnly]
		private TransformRef _getTransform;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collision2D, _getTransform);
		}
		
		public override void Execute()
		{
			_getTransform.Value = _collision2D.Value.transform;
		}
		
		public override string GetSummary()
		{
			return "Get {_collision2D} transform -> {_getTransform}";
		}
	}
}
