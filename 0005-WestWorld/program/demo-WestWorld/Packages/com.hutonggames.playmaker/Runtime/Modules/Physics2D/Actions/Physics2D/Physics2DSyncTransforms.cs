
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Physics2DInternal)]
	[ActionDescription("Synchronizes.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics2D.SyncTransforms.html")]
	public sealed class Physics2DSyncTransforms : BaseAction
	{
		public override void Execute() => Physics2D.SyncTransforms();

		public override string GetSummary() => "Physics2D Sync Transforms";
	}
}
