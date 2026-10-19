
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputSettings)]
	[ActionDescription("Does the user have an IME keyboard input source selected?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Input-imeIsSelected.html")]
	public sealed class InputGetImeIsSelected : BaseAction
	{
		
		[Tooltip("Get Input Ime Is Selected")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getImeIsSelected;
		
		public override bool CanExecute() => CheckParameters(_getImeIsSelected);

		public override void Execute() => _getImeIsSelected.Value = Input.imeIsSelected;

		public override string GetSummary() => "Get IME IsSelected -> {_getImeIsSelected} ";
	}
}
