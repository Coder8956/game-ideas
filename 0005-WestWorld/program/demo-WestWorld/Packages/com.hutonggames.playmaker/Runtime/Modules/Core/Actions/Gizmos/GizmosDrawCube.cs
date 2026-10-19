
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Gizmos)]
	[ActionDescription("Draw a solid box at center with size.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Gizmos.DrawCube.html")]
	public sealed class GizmosDrawCube : BaseAction
	{
		
		[Tooltip("Center.")]
		[SerializeField]
		private Vector3Var _center;
		
		[Tooltip("Size.")]
		[SerializeField, DefaultValue("Vector3.one")]
		private Vector3Var _size;
		
		public override bool CanExecute() => CheckParameters(_center, _size);

#if UNITY_EDITOR

		public override bool HasGizmos => true;

		public override void OnDrawGizmosSelected() => Gizmos.DrawCube(_center.Value, _size.Value);
#endif
		
		public override string GetSummary() => "Draw Cube: Center {_center} Size {_size} ";
	}
}
