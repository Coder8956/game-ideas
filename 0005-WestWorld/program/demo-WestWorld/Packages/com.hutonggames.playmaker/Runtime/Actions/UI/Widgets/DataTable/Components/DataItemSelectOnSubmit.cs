using HutongGames.PlayMaker.Actions;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.UI
{
    /// <summary>
    /// Sends Select when the currently focused row receives a Submit action
    /// (gamepad A / keyboard Enter / UI Submit).
    /// </summary>
    [AddComponentMenu("PlayMaker/Widgets/Data Item Select On Submit")]
    [Icon(Strings.EditorIconsPath + "DataRowSelectionIcon.png")]
    [HelpURL("https://hutonggames.com/playmaker/docs/guides/ui-widgets/data/data-item-selection/")]
    public sealed class DataItemSelectOnSubmit : DataItemActionBase, ISubmitHandler
    {
        public void OnSubmit(BaseEventData eventData)
        {
            TryRequest(DataUICommand.Select, eventData);
            eventData?.Use();
        }
    }
}
