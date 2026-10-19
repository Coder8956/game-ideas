
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Selectable)]
	[ActionDescription("The SpriteState for this selectable object.\nRemarks:\nModifications will not be visible if transition is not SpriteSwap.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Selectable.html")]
	public sealed class SelectableSetSpriteState : BaseAction
	{
		
		[Tooltip("The Selectable")]
		[SerializeField]
		private SelectableVar _selectable;
		
		[Tooltip("Set Selectable Sprite State")]
		[SerializeField]
		private SpriteStateVar _setSpriteState;
		
		public override bool CanExecute()
		{
			return CheckParameters(_selectable, _setSpriteState);
		}
		
		public override void Execute()
		{
			_selectable.Value.spriteState = _setSpriteState.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_selectable} sprite state to {_setSpriteState}";
		}
	}
}
