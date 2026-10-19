using UnityEngine;

namespace HutongGames.PlayMaker.UI
{
    public interface IDataItemContext
    {
        SerializableGuid ItemId { get; }
        string ItemKey { get; }
        IDataItemActionHost Host { get; }

        // The item instance (usually the prefab root containing DataItemUI)
        GameObject ItemGameObject { get; }
    }
}