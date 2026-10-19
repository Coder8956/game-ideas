
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ActionDescription("Matrix that transforms a point from world space into local space (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform-worldToLocalMatrix.html")]
	public sealed class TransformGetWorldToLocalMatrix : BaseAction
	{
		[OwnerDefaultValue]
		[Tooltip("The Transform")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("Get Transform World To Local Matrix")]
		[SerializeField]
		[WriteOnly]
		private Matrix4x4Ref _getWorldToLocalMatrix;
		
		public override bool CanExecute()
		{
			return CheckParameters(_transform, _getWorldToLocalMatrix);
		}
		
		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			_getWorldToLocalMatrix.Value = transform.worldToLocalMatrix;
		}
		
		public override string GetSummary()
		{
			return "Get {_transform} worldToLocalMatrix -> {_getWorldToLocalMatrix}";
		}
	}
}
