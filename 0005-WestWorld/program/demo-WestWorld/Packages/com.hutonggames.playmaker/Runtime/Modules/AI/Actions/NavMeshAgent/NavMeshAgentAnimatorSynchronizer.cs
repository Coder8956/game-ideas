
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Synchronize a NavMesh Agent velocity and rotation with the animator process.")]
	[HelpURL("actions/ai-actions/nav-mesh/nav-mesh-agent-animator-synchronizer")]
	public sealed class NavMeshAgentAnimatorSynchronizer : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

		[Tooltip("The NavMeshAgent to synchronize.")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("The Animator to synchronize with.")]
		[SerializeField]
		private AnimatorVar _animator;
		
		public override bool CanExecute() => CheckParameters(_navMeshAgent, _animator);

		public override void Execute()
		{
			var agent = _navMeshAgent.Value;
			var trans = agent.transform;
			var animator = _animator.Value;
			
			agent.velocity = animator.deltaPosition / Time.deltaTime;
			trans.rotation = animator.rootRotation;
		}
		
		public override string GetSummary() => "Sync {_navMeshAgent} to {_animator} ";
	}
}
