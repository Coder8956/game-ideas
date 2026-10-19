
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Gizmos)]
	[ActionDescription("Draw a wireframe box with center and size.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Gizmos.DrawWireCube.html")]
	public sealed class GizmosDrawWireCube : BaseAction
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
		
		public override void OnDrawGizmosSelected() => Gizmos.DrawWireCube(_center.Value, _size.Value);
#endif
		
		public override string GetSummary() => "Draw Wire Cube At: {_center} Size: {_size} ";
	}
}
