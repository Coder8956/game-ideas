
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SpriteRenderer)]
	[ActionDescription("Defines a set of sprites to cycle to create an animation. Sometimes simpler than creating an Animator.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SpriteRenderer-sprite.html")]
	public sealed class SpriteRendererAnimate : BaseAction
	{
		public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;

		public override bool CanFinish => true;

		[Tooltip("The SpriteRenderer")]
		[SerializeField]
		private SpriteRendererVar _spriteRenderer;
		
		[Tooltip("Sprites to use for the animation.")]
		[SerializeField]
		private SpriteListVar _frames;

		[Tooltip("Delay between frames.")]
		[SerializeField, DefaultValue(0.2)]
		private FloatVar _delay;

		[Tooltip("Loop the animation.")]
		[SerializeField, DefaultValue(true)]
		private BoolVar _loop;

		private float _timer;
		private float _frameStartTime;
		private int _index;
		private int _frameCount;
		
		private float CurrentTime => InFixedUpdate ? Time.fixedTime : Time.time;
		
		public override bool CanExecute() => CheckParameters(_spriteRenderer, _frames, _delay);

		public override void OnStart()
		{
			_timer = 0;
			_frameStartTime = CurrentTime;
			_index = 0;
			_frameCount = _frames.Value.Count;
			if (_frameCount == 0)
			{
				Finish();
				return;
			}
			
			_spriteRenderer.Value.sprite = _frames.Value[0];
		}

		public override void Execute()
		{
			_timer = Mathf.Max(0f, CurrentTime - _frameStartTime);
			if (_timer < _delay.Value) return;
			
			_timer = 0;
			_frameStartTime = CurrentTime;
			_index++;
			
			if (_index >= _frameCount)
			{
				if (_loop.Value)
				{
					_index = 0;
				}
				else
				{
					Finish();
					return;
				}
			}
			
			_spriteRenderer.Value.sprite = _frames.Value[_index];
		}
		
		public override string GetSummary() => "Animate {_spriteRenderer} {_frames} every {_delay:seconds}";
	}
}
