
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animation)]
	[ActionDescription("Synchronizes playback speed of all animations in the layer.","" +
		"When blending between two looping animations they often have different lengths. " +
		"For example a walk cycle often takes longer than a run cycle. When blending between them you need to " +
		"make sure that the foot placement of the walk and run cycle happens at the same time. In other word " +
		"playback speed of the animations must be adjusted so that the animations are synchronized. SyncLayer will " +
		"calculate the average normalized playback speed of all animations in the layer based on their blend weight. " +
		"Then it will apply that playback speed to all animations in the layer.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animation.html")]
	public sealed class AnimationSyncLayer : BaseAction
	{
		
		[Tooltip("The Animation component.")]
		[SerializeField]
		private AnimationVar _animation;
		
		[Tooltip("Layer.")]
		[SerializeField]
		private IntegerVar _layer;
		
		public override bool CanExecute() => CheckParameters(_animation, _layer);

		public override void Execute() => _animation.Value.SyncLayer(_layer.Value);

		public override string GetSummary() => "{_animation} Sync Layer {_layer} ";
	}
}

