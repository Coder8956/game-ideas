
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Gizmos)]
	[ActionDescription("Sets the Matrix4x4 that the Unity Editor uses to draw Gizmos.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Gizmos-matrix.html")]
	public sealed class GizmosSetMatrix : BaseAction
	{
		
		[Tooltip("Set Gizmos Matrix")]
		[SerializeField]
		private Matrix4x4Var _setMatrix;
		
		public override bool CanExecute() => CheckParameters(_setMatrix);

#if UNITY_EDITOR
		
		public override bool HasGizmos => true;
		
		public override void OnDrawGizmosSelected() => Gizmos.matrix = _setMatrix.Value;
#endif
		
		public override string GetSummary() => "Set Gizmos Matrix to {_setMatrix}";
	}
}
