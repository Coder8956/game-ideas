
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.MonoBehaviour)]
	[ActionDescription("Disabling this lets you skip the GUI layout phase.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/MonoBehaviour-useGUILayout.html")]
	public sealed class MonoBehaviourSetUseGUILayout : BaseAction
	{
		
		[Tooltip("The MonoBehaviour")]
		[SerializeField]
		private MonoBehaviourVar _monoBehaviour;
		
		[Tooltip("Set MonoBehaviour Use GUI Layout")]
		[SerializeField]
		private BoolVar _setUseGUILayout;
		
		public override bool CanExecute()
		{
			return CheckParameters(_monoBehaviour, _setUseGUILayout);
		}
		
		public override void Execute()
		{
			_monoBehaviour.Value.useGUILayout = _setUseGUILayout.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_monoBehaviour} use GUI layout to {_setUseGUILayout}";
		}
	}
}
