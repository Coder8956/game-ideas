
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("The additional layers that all Colliders attached to this Rigidbody should exclud" +
		"e when deciding if the Collider can come into contact with another Collider.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-excludeLayers.html")]
	public sealed class RigidbodyGetExcludeLayers : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Get Rigidbody Exclude Layers")]
		[SerializeField]
		[WriteOnly]
		private LayerMaskRef _getExcludeLayers;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _getExcludeLayers);
		}
		
		public override void Execute()
		{
			_getExcludeLayers.Value = _rigidbody.Value.excludeLayers;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody} exclude layers -> {_getExcludeLayers}";
		}
	}
}
