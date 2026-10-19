using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.String)]
    [ActionDescription("Types out a string one character at a time with a customizable delay between characters. " +
                       "Use the output string to set text in a Text component or other text display.")]
    public class StringTypewriter : BaseAction
    {
        [Tooltip("The text to type out character by character.")]
        [SerializeField] 
        private StringVar _inputText;

        [Tooltip("The string variable to store the current typed text.")]
        [SerializeField, WriteOnly] 
        private StringRef _outputText;

        [Tooltip("Delay between each character in seconds. Default is 0.1 seconds.")]
        [SerializeField, DefaultValue(0.1f)] 
        private FloatVar _characterDelay;

        [Tooltip("Use unscaled realtime for character timing. When enabled, typing is not affected by Time.timeScale.")]
        [SerializeField, DefaultValue(false)]
        private BoolVar _useRealtime;

        [Tooltip("Event to send after each character is typed.")]
        [SerializeField, OptionalField] 
        private EventRef _characterTypedEvent;

        [SerializeField, OptionalField]
        [Tooltip("Event to send when typing is complete.")]
        private EventRef _finishedEvent;
        
        [Tooltip("Reset to beginning when the action starts. " +
                 "Set this to false if the action is in a state loop.")]
        [SerializeField]
        private bool _resetOnStart = true;

        private int _currentCharacterIndex;
        private float _nextCharacterTime;
        private string _fullText;

        public override bool CanExecute() => CheckParameters(_inputText, _outputText, _characterDelay, _useRealtime);

        public override UpdateMode DefaultUpdateMode => UpdateMode.Update | UpdateMode.EveryFrame;

        public override bool CanFinish => true;

        public override void OnStart()
        {
            _fullText = _inputText.Value ?? string.Empty;
            // If text is empty, finish immediately
            if (string.IsNullOrEmpty(_fullText))
            {
                SendFinishedEvent();
                return;
            }

            if (_resetOnStart)
            {
                _currentCharacterIndex = 0;
                _outputText.Value = string.Empty;
            }

            // Set default delay if not specified
            if (_characterDelay.IsNull || _characterDelay.Value <= 0)
            {
                _characterDelay.Value = 0.05f;
            }

            _nextCharacterTime = GetCurrentTime() + _characterDelay.Value;
        }

        public override void Execute()
        {
            // Check if we're done
            if (_currentCharacterIndex > _fullText.Length)
            {
                _outputText.Value = _fullText;
                SendFinishedEvent();
                return;
            }
            
            // Check if it's time for the next character
            if (GetCurrentTime() < _nextCharacterTime) return;
            
            _outputText.Value = _fullText[.._currentCharacterIndex];
            _currentCharacterIndex++;
            
            // Set time for next character
            _nextCharacterTime = GetCurrentTime() + _characterDelay.Value;
            
            // Send this last because it could exit this state
            SendEvent(_characterTypedEvent);
        }
        
        private void SendFinishedEvent()
        {
            _currentCharacterIndex = 0;
            SendEvent(_finishedEvent);
            Finish();
        }

        private float GetCurrentTime() => _useRealtime.Value ? Time.unscaledTime : Time.time;


        public override string GetSummary() => "Type {_inputText} to {_outputText} with {_characterDelay}s delay {_useRealtime:option}";
    }
}
