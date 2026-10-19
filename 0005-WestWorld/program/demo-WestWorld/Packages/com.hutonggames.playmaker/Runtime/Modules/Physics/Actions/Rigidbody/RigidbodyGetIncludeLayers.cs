
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("The additional layers that all Colliders attached to this Rigidbody should includ" +
		"e when deciding if the Collider can come into contact with another Collider.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-includeLayers.html")]
	public sealed class RigidbodyGetIncludeLayers : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Get Rigidbody Include Layers")]
		[SerializeField]
		[WriteOnly]
		private LayerMaskRef _getIncludeLayers;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _getIncludeLayers);
		}
		
		public override void Execute()
		{
			_getIncludeLayers.Value = _rigidbody.Value.includeLayers;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody} include layers -> {_getIncludeLayers}";
		}
	}
}
