
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Function to push the updated vertex data into the mesh and renderer.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextUpdateVertexData__Flags : BaseAction
	{
		
		[Tooltip("The TMP_Text.")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Flags.")]
		[SerializeField]
		private TMP_VertexDataUpdateFlagsVar _flags;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _flags);
		}
		
		public override void Execute()
		{
			//TMPro.TMP_Text.UpdateVertexData(TMPro.TMP_VertexDataUpdateFlags);
			_tMP_Text.Value.UpdateVertexData(_flags.Value);
		}
		
		public override string GetSummary()
		{
			return "Update {_tMP_Text} vertex data {_flags}";
		}
	}
}
