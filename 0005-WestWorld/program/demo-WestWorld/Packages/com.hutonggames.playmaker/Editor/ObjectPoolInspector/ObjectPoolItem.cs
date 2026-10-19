using HutongGames.Editor;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.Editor
{
    public class ObjectPoolItem : VisualElement
    {
        private const string UxmlGuid = "8e89688fa0784369b207d899147588b1";
        
        private readonly ObjectPool _objectPool;
        
        // We cache these because the UI could get updated frequently
        
        private readonly Image _icon;
        private readonly Label _name;
        private readonly ObjectField _prefab;
        private readonly IntegerField _activeCount;
        private readonly IntegerField _maxSize;
        private readonly IntegerField _totalCount;
        private readonly IntegerField _inactiveCount;
        
        public ObjectPoolItem(ObjectPool objectPool)
        {
            var template = UITK.LoadVisualTree(UxmlGuid);
            template.CloneTree(this);
            
            _icon = this.Q<Image>("icon");
            _name = this.Q<Label>("name");
            _prefab = this.Q<ObjectField>("prefab");
            _activeCount = this.Q<IntegerField>("active-count");
            _maxSize = this.Q<IntegerField>("max-size");
            _totalCount = this.Q<IntegerField>("total-count");
            //_inactiveCount = this.Q<IntegerField>("inactive-count");
            
            _objectPool = objectPool;
            _objectPool.Changed += QueueUpdateUI;
            UpdateUI();
            
            RegisterCallback<DetachFromPanelEvent>(_ =>
            {
                _objectPool.Changed -= QueueUpdateUI;
                EditorApplication.delayCall -= UpdateUI;
                EditorApplication.delayCall -= GetAssetPreview;
            });
        }

        private void QueueUpdateUI()
        {
            // Queue an update to avoid updating UI many times in a single frame
            EditorApplication.delayCall -= UpdateUI;
            EditorApplication.delayCall += UpdateUI;
        }
        
        private void UpdateUI()
        {
            if (EditorApplication.isPlaying)
            {
                _objectPool.EnsureValid();
            }
            
            var displayPrefab = _objectPool.PoolPrefabInstance.IsUnityNull()
                ? _objectPool.SourcePrefab
                : _objectPool.PoolPrefabInstance;
            
            if (displayPrefab.IsUnityNull())
            {
                // We don't clear the UI because it can be useful
                // to see the last state of the object pool.
                return;
            }
            
            // Be careful not to call GetAssetPreview repeatedly,
            // it creates a preview scene every time!
            // We use delayCall because otherwise it creates
            // some kind of infinite loop within UIToolkit
            EditorApplication.delayCall -= GetAssetPreview;
            EditorApplication.delayCall += GetAssetPreview;
            _name.text = displayPrefab.name;
            _prefab.value = displayPrefab;
            _activeCount.value = _objectPool.ActiveCount;
            _maxSize.value = _objectPool.MaxSize;
            _totalCount.value = _objectPool.TotalCount;
            //_inactiveCount.value = _objectPool.InactiveCount;
        }

        private void GetAssetPreview()
        {
            var icon = PreviewUtility.GetPrefabPreview(_objectPool.SourcePrefab);
            if (icon == null)
            {
                schedule.Execute(_ => GetAssetPreview()).ExecuteLater(100);
            }
            else
            {
                _icon.image = icon;
            }
        }
    }
}
