
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ActionDescription("Matrix that transforms a point from local space into world space (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform-localToWorldMatrix.html")]
	public sealed class TransformGetLocalToWorldMatrix : BaseAction
	{
		[OwnerDefaultValue]
		[Tooltip("The Transform")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("Get Transform Local To World Matrix")]
		[SerializeField]
		[WriteOnly]
		private Matrix4x4Ref _getLocalToWorldMatrix;
		
		public override bool CanExecute()
		{
			return CheckParameters(_transform, _getLocalToWorldMatrix);
		}
		
		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			_getLocalToWorldMatrix.Value = transform.localToWorldMatrix;
		}
		
		public override string GetSummary()
		{
			return "Get {_transform} localToWorldMatrix -> {_getLocalToWorldMatrix}";
		}
	}
}
