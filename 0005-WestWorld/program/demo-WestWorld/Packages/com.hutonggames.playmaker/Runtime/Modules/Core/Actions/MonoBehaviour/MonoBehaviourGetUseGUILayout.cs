
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.MonoBehaviour)]
	[ActionDescription("Disabling this lets you skip the GUI layout phase.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/MonoBehaviour-useGUILayout.html")]
	public sealed class MonoBehaviourGetUseGUILayout : BaseAction
	{
		
		[Tooltip("The MonoBehaviour")]
		[SerializeField]
		private MonoBehaviourVar _monoBehaviour;
		
		[Tooltip("Get MonoBehaviour Use GUI Layout")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getUseGUILayout;
		
		public override bool CanExecute()
		{
			return CheckParameters(_monoBehaviour, _getUseGUILayout);
		}
		
		public override void Execute()
		{
			_getUseGUILayout.Value = _monoBehaviour.Value.useGUILayout;
		}
		
		public override string GetSummary()
		{
			return "Get {_monoBehaviour} use GUI layout -> {_getUseGUILayout}";
		}
	}
}
