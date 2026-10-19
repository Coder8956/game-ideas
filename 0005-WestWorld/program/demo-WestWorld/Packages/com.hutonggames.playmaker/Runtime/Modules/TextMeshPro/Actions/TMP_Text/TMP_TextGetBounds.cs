
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Returns the bounds of the mesh of the text object in world space.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetBounds : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Bounds")]
		[SerializeField]
		[WriteOnly]
		private BoundsRef _getBounds;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getBounds);
		}
		
		public override void Execute()
		{
			_getBounds.Value = _tMP_Text.Value.bounds;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} bounds -> {_getBounds}";
		}
	}
}
