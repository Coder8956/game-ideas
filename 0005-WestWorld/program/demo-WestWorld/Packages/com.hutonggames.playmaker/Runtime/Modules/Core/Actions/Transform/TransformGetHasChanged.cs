
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ActionDescription("Has the transform changed since the last time the flag was set to \'false\'?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform-hasChanged.html")]
	public sealed class TransformGetHasChanged : BaseAction
	{
		
		[OwnerDefaultValue]
		[Tooltip("The Transform")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("Get Transform Has Changed")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getHasChanged;
		
		public override bool CanExecute()
		{
			return CheckParameters(_transform, _getHasChanged);
		}
		
		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			_getHasChanged.Value = transform.hasChanged;
		}
		
		public override string GetSummary()
		{
			return "Get {_transform} hasChanged -> {_getHasChanged}";
		}
	}
}
