/* DisplayInfo not supported yet
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Screen)]
	[ActionDescription("Retrieves layout information about connected displays such as names, resolutions " +
		"and refresh rates.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Screen.GetDisplayLayout.html")]
	public sealed class ScreenGetDisplayLayout : BaseAction
	{
		
		[Tooltip("Connected display information.")]
		[SerializeField]
		private DisplayInfoListVar _displayLayout;
		
		public override bool CanExecute()
		{
			return CheckParameters(_displayLayout);
		}
		
		public override void Execute()
		{
			//UnityEngine.Screen.GetDisplayLayout(System.Collections.Generic.List`1[[UnityEngine.DisplayInfo, UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]);
			Screen.GetDisplayLayout(_displayLayout.Value);
		}
		
		public override string GetSummary()
		{
			return "Screen Get Display Layout: {_displayLayout} ";
		}
	}
}
*/