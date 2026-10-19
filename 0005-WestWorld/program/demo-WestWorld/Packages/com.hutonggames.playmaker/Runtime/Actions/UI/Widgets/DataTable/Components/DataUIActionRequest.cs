using UnityEngine;

namespace HutongGames.PlayMaker.UI
{
    public readonly struct DataUIActionRequest
    {
        public readonly SerializableGuid ItemId;
        public readonly string ItemKey;
        public readonly DataUICommand Command;
        
        public readonly int SourceIndex; 
        public readonly int IntArg;
        public readonly string StringArg;
        
        public readonly GameObject ItemGameObject;        // item instance
        public readonly GameObject InteractedGameObject;  // clicked region/button GO
        public readonly string Identifier;                // optional tag (Body/Delete/DragHandle)

        public readonly object Payload;
        public readonly object Sender;

        public DataUIActionRequest(
            SerializableGuid itemId,
            string itemKey,
            DataUICommand command,
            int sourceIndex = -1,
            int intArg = 0,
            string stringArg = null,
            GameObject itemGameObject = null,
            GameObject interactedGameObject = null,
            string identifier = null,
            object payload = null,
            object sender = null)
        {
            ItemId = itemId;
            ItemKey = itemKey;
            Command = command;
            SourceIndex = sourceIndex;
            IntArg = intArg;
            StringArg = stringArg;
            ItemGameObject = itemGameObject;
            InteractedGameObject = interactedGameObject;
            Identifier = identifier;
            Payload = payload;
            Sender = sender;
        }
    }
}