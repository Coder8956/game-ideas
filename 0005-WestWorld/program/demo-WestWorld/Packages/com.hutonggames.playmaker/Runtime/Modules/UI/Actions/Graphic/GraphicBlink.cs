
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Graphic)]
	[ActionDescription("Turns a Graphic on and off in a blink pattern.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Graphic.html")]
	public sealed class GraphicBlink : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
		public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;
		
		[Tooltip("The Graphic")]
		[SerializeField]
		private GraphicVar _graphic;
		
		[DefaultValue(0.5f)]
		[Tooltip("How long the renderer is off in seconds.")]
		[SerializeField]
		private FloatVar _onDuration;

		[DefaultValue(0.5f)]
		[Tooltip("How long the renderer is on in seconds.")]
		[SerializeField]
		private FloatVar _offDuration;

		[Tooltip("Use unscaled realtime.")]
		[SerializeField]
        [FormerlySerializedAs("_ignoreTimeScale")]
		private BoolVar _useRealtime;
		
		public override bool CanExecute() => CheckParameters(_graphic, _onDuration, _offDuration, _useRealtime);

		private float _nextTime;
		private bool _on = true;

		public override void OnStart()
		{
			_nextTime = _onDuration.Value;
			_on = true;
			_graphic.Value.enabled = _on;
		}

		public override void Execute()
		{
			_nextTime -= _useRealtime.Value ? Time.unscaledDeltaTime : Time.deltaTime;
			
			if (_nextTime < 0)
			{
				_on = !_on;
				_nextTime += _on ? _onDuration.Value : _offDuration.Value;
				_graphic.Value.enabled = _on;
			}
		}
		
		public override string GetSummary() => "Blink {_graphic} on {_onDuration} off {_offDuration} {_useRealtime:option}";

	}
}
