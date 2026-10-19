namespace HutongGames.PlayMaker
{
    // NOTE: We include all one-off mouse events in one proxy component.
    // Not sure if this is a lot more expensive, but seems okay for now.
    // We can separate these into different components if needed.
    public class OnMouseProxyComponent : BaseProxyEventComponent
    {
        private int _lastMouseDownFrame = -1;
        private int _lastMouseUpFrame = -1;
        private int _lastMouseUpAsButtonFrame = -1;
        private int _lastMouseEnterFrame = -1;
        private int _lastMouseExitFrame = -1;

        public void OnMouseDown()
        {
            if (!IsDuplicateFrameEvent(ref _lastMouseDownFrame))
            {
                SendEvent(OnMouseDownEvent.Instance);
            }
        }

        public void OnMouseUp()
        {
            if (!IsDuplicateFrameEvent(ref _lastMouseUpFrame))
            {
                SendEvent(OnMouseUpEvent.Instance);
            }
        }
        
        public void OnMouseUpAsButton()
        {
            if (!IsDuplicateFrameEvent(ref _lastMouseUpAsButtonFrame))
            {
                SendEvent(OnMouseUpAsButtonEvent.Instance);
            }
        }

        public void OnMouseEnter()
        {
            if (!IsDuplicateFrameEvent(ref _lastMouseEnterFrame))
            {
                SendEvent(OnMouseEnterEvent.Instance);
            }
        }
        
        public void OnMouseExit()
        {
            if (!IsDuplicateFrameEvent(ref _lastMouseExitFrame))
            {
                SendEvent(OnMouseExitEvent.Instance);
            }
        }
    }
}
