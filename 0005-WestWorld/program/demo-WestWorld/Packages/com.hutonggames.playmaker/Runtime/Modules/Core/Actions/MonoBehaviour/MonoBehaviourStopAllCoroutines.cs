
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.MonoBehaviour)]
	[ActionDescription("Stops all coroutines running on this behaviour.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/MonoBehaviour.StopAllCoroutines.html")]
	public sealed class MonoBehaviourStopAllCoroutines : BaseAction
	{
		
		[Tooltip("The MonoBehaviour.")]
		[SerializeField]
		private MonoBehaviourVar _monoBehaviour;
		
		public override bool CanExecute()
		{
			return CheckParameters(_monoBehaviour);
		}
		
		public override void Execute()
		{
			//UnityEngine.MonoBehaviour.StopAllCoroutines();
			_monoBehaviour.Value.StopAllCoroutines();
		}
		
		public override string GetSummary()
		{
			return "Stop all coroutines on {_monoBehaviour}";
		}
	}
}
