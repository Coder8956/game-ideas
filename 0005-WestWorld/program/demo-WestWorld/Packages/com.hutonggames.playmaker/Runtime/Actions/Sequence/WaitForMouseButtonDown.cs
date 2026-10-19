using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Sequence)]
    [ActionDescription("Wait for a mouse button to be pressed.")]
    public class WaitForMouseButtonDown : BaseWaitAction
    {
        [Tooltip("The mouse button to wait for. \n\nLeft = 0, Right = 1, Middle = 2.")]
        [SerializeField] 
        private IntegerVar _mouseButton;
        
        [NonSerialized] private bool _finished;
        
        public override void OnStart()
        {
            _finished = false;
        }
        
        public override void Execute()
        {
            // Wait a frame so chained WaitForAnyKeyDown
            // actions don't all finish on the same frame
            
            if (_finished && CurrentUpdateMode == UpdateMode.Update)
            {
                Finish();
            }

            if (InputShim.GetMouseButtonDown(_mouseButton.Value))
            {
                _finished = true;
            }
        }
    }
}

