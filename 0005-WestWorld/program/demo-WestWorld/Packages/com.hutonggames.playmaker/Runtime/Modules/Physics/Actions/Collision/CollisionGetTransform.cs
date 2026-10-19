
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collision)]
	[ActionDescription("The Transform of the object we hit (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collision-transform.html")]
	public sealed class CollisionGetTransform : BaseAction
	{
		
		[Tooltip("The Collision")]
		[SerializeField]
		private CollisionRef _collision;
		
		[Tooltip("Get Collision Transform")]
		[SerializeField]
		[WriteOnly]
		private TransformRef _getTransform;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collision, _getTransform);
		}
		
		public override void Execute()
		{
			_getTransform.Value = _collision.Value.transform;
		}
		
		public override string GetSummary()
		{
			return "Get {_collision} transform -> {_getTransform}";
		}
	}
}
