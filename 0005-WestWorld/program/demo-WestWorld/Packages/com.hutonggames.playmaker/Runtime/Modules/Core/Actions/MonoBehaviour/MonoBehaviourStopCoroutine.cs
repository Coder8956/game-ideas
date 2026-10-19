
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.MonoBehaviour)]
	[ActionDescription("Stops the first coroutine named methodName, or the coroutine stored in routine running on this behaviour.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/MonoBehaviour.StopCoroutine.html")]
	public sealed class MonoBehaviourStopCoroutine : BaseAction
	{
		
		[Tooltip("The MonoBehaviour.")]
		[SerializeField]
		private MonoBehaviourVar _monoBehaviour;
		
		[Tooltip("Name of coroutine.")]
		[SerializeField]
		private StringVar _methodName;
		
		public override bool CanExecute()
		{
			return CheckParameters(_monoBehaviour, _methodName);
		}
		
		public override void Execute()
		{
			//UnityEngine.MonoBehaviour.StopCoroutine(System.String);
			_monoBehaviour.Value.StopCoroutine(_methodName.Value);
		}
		
		public override string GetSummary()
		{
			return "Stop coroutine {_methodName} on {_monoBehaviour}";
		}
	}
}
