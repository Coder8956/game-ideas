
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Gizmos)]
	[ActionDescription("The Matrix4x4 that the Unity Editor uses to draw Gizmos.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Gizmos-matrix.html")]
	public sealed class GizmosGetMatrix : BaseAction
	{
		
		[Tooltip("Get Gizmos Matrix")]
		[SerializeField]
		[WriteOnly]
		private Matrix4x4Ref _getMatrix;
		
		public override bool CanExecute() => CheckParameters(_getMatrix);

#if UNITY_EDITOR
		
		public override bool HasGizmos => true;
		
		public override void OnDrawGizmosSelected() => _getMatrix.Value = Gizmos.matrix;
#endif
		
		public override string GetSummary() => "Get Gizmos Matrix -> {_getMatrix} ";
	}
}
