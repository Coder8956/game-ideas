
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Gizmos)]
	[ActionDescription("Draws lines through a list of target GameObjects.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Gizmos.DrawLine.html")]
	public sealed class GizmosDrawLinesThroughTargets : BaseAction
	{
		[Tooltip("Targets.")]
		[SerializeField]
		private GameObjectListVar _targets;
		
		public override bool CanExecute() => CheckParameters(_targets) && _targets.Length > 1;

#if UNITY_EDITOR	
		
		public override bool HasGizmos => true;
		
		public override void OnDrawGizmosSelected()
		{
			var targets = _targets.Value.Where(x => x!=null).Select(x => x.transform).ToList();
			if (targets.Count < 2) return;
			targets.Add(targets[0]); // make a loop
			
			var start = targets[0].position;
			for (var i = 1; i < targets.Count; i++)
			{
				var end = targets[i].transform.position;
				Gizmos.DrawLine(start, end);
				start = end;
			}
		}
#endif	
		
		public override string GetSummary() => "Draw Lines: {_targets}";
	}
}
