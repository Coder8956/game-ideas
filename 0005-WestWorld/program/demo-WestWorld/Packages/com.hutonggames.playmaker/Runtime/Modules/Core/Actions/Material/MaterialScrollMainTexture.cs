
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Material)]
	[ActionDescription("Animate the offset of the main texture to scroll in a direction.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Material-mainTextureOffset.html")]
	public sealed class MaterialScrollMainTexture : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

		[Tooltip("The Material. Select Owner to use its material.")]
		[SerializeField]
		private MaterialVar _material;
		
		[Tooltip("Direction to scroll the texture per second.")]
		[SerializeField]
		private Vector2Var _offset;
		
		[Tooltip("Use unscaled realtime. Useful if the game is paused.")]
		[SerializeField]
        [FormerlySerializedAs("_ignoreTimeScale")]
		private BoolVar _useRealtime;
		
		public override bool CanExecute()
		{
			return CheckParameters(_material, _offset);
		}
		
		public override void Execute()
		{
			_material.Value.mainTextureOffset += _offset.Value * (_useRealtime.Value ? Time.unscaledDeltaTime : Time.deltaTime);
		}
		
		public override string GetSummary()
		{
			return "Scroll {_material} Main Texture {_offset}/s {_useRealtime:option}";
		}
	}
}
