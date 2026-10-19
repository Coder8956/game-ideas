
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
#if UNITY_6000_7_OR_NEWER
using UnityEngine.UIElements;
#endif


namespace HutongGames.PlayMaker.Actions
{
	
	// NOTE: The typo in the name matches a Unity typo.
	// Unity might fix this typo at some point, breaking this action!
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.EventSystem)]
	[ActionDescription("Sets how UI Toolkit runtime panels receive events and handle selection when interacting with other objects that use the EventSystem, such as components from the Unity UI package. ")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EventSystems.EventSystem.SetUITookitEventSystemOverride.html")]
	public sealed class EventSystemSetUITookitEventSystemOverride : BaseAction
	{
		
		[Tooltip("The EventSystem used to override UI Toolkit panel events and selection. If activeEventSystem is null, UI Toolkit panels will use current enabled EventSystem or, if there is none, the default InputManager-based event system will be used.")]
		[SerializeField]
		private EventSystems.EventSystemVar _activeEventSystem;
		
		[Tooltip(" If true, UI Toolkit events will come from this EventSystem instead of the default InputManager-based event system.")]
		[SerializeField]
		private BoolVar _sendEvents;
		
		[Tooltip("If true, UI Toolkit panels' unassigned selectableGameObject will be automatically initialized with children GameObjects of this EventSystem on Start.")]
		[SerializeField]
		private BoolVar _createPanelGameObjectsOnStart;
		
		public override bool CanExecute()
		{
			return CheckParameters(_activeEventSystem, _sendEvents, _createPanelGameObjectsOnStart);
		}
		
		public override void Execute()
		{
#if UNITY_6000_7_OR_NEWER
			var eventSystem = _activeEventSystem.Value != null ? _activeEventSystem.Value : EventSystem.current;
			if (eventSystem != null && eventSystem.isActiveAndEnabled && EventSystem.current != eventSystem)
				EventSystem.current = eventSystem;

			var configuration = Object.FindFirstObjectByType<PanelInputConfiguration>();
			if (configuration == null)
			{
				var host = eventSystem != null ? eventSystem.gameObject : OwnerGameObject;
				configuration = host.GetComponent<PanelInputConfiguration>();
				if (configuration == null)
					configuration = host.AddComponent<PanelInputConfiguration>();
			}

			configuration.panelInputRedirection = _sendEvents.Value
				? PanelInputConfiguration.PanelInputRedirection.AutoSwitch
				: PanelInputConfiguration.PanelInputRedirection.Never;
			configuration.autoCreatePanelComponents = _createPanelGameObjectsOnStart.Value;
#else
#pragma warning disable CS0618
			EventSystem.SetUITookitEventSystemOverride(
				_activeEventSystem.Value,
				_sendEvents.Value,
				_createPanelGameObjectsOnStart.Value
			);
#pragma warning restore CS0618
#endif
		}
		
		public override string GetSummary()
		{
			return "Set UI Toolkit EventSystem override {_activeEventSystem} {_sendEvents} {_createPanelGameObjectsOnStart}";
		}
	}
}
