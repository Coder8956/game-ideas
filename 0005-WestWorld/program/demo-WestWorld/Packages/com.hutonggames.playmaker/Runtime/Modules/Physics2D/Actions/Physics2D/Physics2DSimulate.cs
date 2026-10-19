
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Physics2DInternal)]
	[ActionDescription("Simulate physics in the Scene.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics2D.Simulate.html")]
	public sealed class Physics2DSimulate : BaseAction
	{
		
		[Tooltip("The time to advance physics by.")]
		[SerializeField]
		private FloatVar _step;
		
		[Tooltip("Whether the simulation was run or not. Running the simulation during physics callbacks will always fail.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _succeeded;
		
		public override bool CanExecute() => CheckParameters(_step, _succeeded);

		public override void Execute() => _succeeded.Value = Physics2D.Simulate(_step.Value);

		public override string GetSummary() => "Physics2D Simulate: {_step} -> {_succeeded}";
	}
}
