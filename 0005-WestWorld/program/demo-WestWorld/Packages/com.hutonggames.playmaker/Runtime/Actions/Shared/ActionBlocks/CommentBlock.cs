using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    public class CommentBlock : BaseActionBlock
    {
        [HideLabel, Multiline, OptionalField]
        public string Comment;

        [RightAlignedLabel]
        [Tooltip("Use the comment as the action title when collapsed.")]
        public bool UseAsTitleWhenCollapsed;
    }
}
