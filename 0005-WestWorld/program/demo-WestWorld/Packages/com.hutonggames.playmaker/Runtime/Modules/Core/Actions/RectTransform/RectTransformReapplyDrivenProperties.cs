
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RectTransform)]
	[ActionDescription("Event that is invoked for RectTransforms that need to have their driven properties reapplied.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RectTransform-reapplyDrivenProperties.html")]
	public sealed class RectTransformReapplyDrivenProperties : BaseOnEventAction
	{
		
		[Tooltip("Event that is invoked for RectTransforms that need to have their driven properties reapplied.")]
		[SerializeField]
		private EventRef _reapplyDrivenProperties;
		
		public override void OnStart()
		{
			RectTransform.reapplyDrivenProperties += OnReapplyDrivenProperties;
		}
		
		public override void OnStop()
		{
			RectTransform.reapplyDrivenProperties -= OnReapplyDrivenProperties;
		}
		
		private void OnReapplyDrivenProperties(RectTransform driven)
		{
			SendEvent(_reapplyDrivenProperties);
		}

		public override string GetSummary() => "Send {_reapplyDrivenProperties} on reapply driven properties";
	}
}
