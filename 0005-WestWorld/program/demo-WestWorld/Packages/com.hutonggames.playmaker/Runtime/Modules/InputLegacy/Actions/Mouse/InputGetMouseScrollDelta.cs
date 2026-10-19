
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Mouse)]
	[ActionDescription("The current mouse scroll delta. (Read Only)" + Strings.SupportsBothInputSystems)]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Input-mouseScrollDelta.html")]
	public sealed class InputGetMouseScrollDelta : BaseAction
	{
		
		[Tooltip("Get Input Mouse Scroll Delta")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getMouseScrollDelta;
		
		public override bool CanExecute() => CheckParameters(_getMouseScrollDelta);

		public override void Execute() => _getMouseScrollDelta.Value = InputShim.GetScrollDelta();

		public override string GetSummary() => "Get Mouse ScrollDelta -> {_getMouseScrollDelta} ";
	}
}
