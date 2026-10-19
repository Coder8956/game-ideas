
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ActionDescription("Has the transform changed since the last time the flag was set to \'false\'?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform-hasChanged.html")]
	public sealed class TransformSetHasChanged : BaseAction
	{
		[OwnerDefaultValue]
		[Tooltip("The Transform")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("Set Transform Has Changed")]
		[SerializeField]
		private BoolVar _setHasChanged;
		
		public override bool CanExecute()
		{
			return CheckParameters(_transform, _setHasChanged);
		}
		
		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			transform.hasChanged = _setHasChanged.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_transform} Has Changed to {_setHasChanged}";
		}
	}
}
