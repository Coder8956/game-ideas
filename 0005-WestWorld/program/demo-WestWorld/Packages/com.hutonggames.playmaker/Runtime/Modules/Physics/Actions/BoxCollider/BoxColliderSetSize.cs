
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.BoxCollider)]
	[ActionDescription("The size of the box, measured in the object\'s local space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/BoxCollider-size.html")]
	public sealed class BoxColliderSetSize : BaseAction
	{
		
		[Tooltip("The BoxCollider")]
		[SerializeField]
		private BoxColliderVar _boxCollider;
		
		[Tooltip("Set BoxCollider Size")]
		[SerializeField]
		private Vector3Var _setSize;
		
		public override bool CanExecute()
		{
			return CheckParameters(_boxCollider, _setSize);
		}
		
		public override void Execute()
		{
			_boxCollider.Value.size = _setSize.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_boxCollider} Size to {_setSize}";
		}
	}
}
