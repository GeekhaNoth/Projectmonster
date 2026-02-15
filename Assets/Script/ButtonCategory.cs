using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Script
{
    public class ButtonCategory : MonoBehaviour, ISelectHandler
    { 
        public MenuManager.CategoryType category; 
        
        private MenuManager _menuManager;

        private ScriptableAssetModel[] _scriptableAssetModelsTypes;
        private void Start()
         {
             _menuManager = MenuManager.Instance;
         } 
        
        public void OnSelect(BaseEventData eventData)
        {
            if (_scriptableAssetModelsTypes.Length != 0)
            {
                _menuManager.InstantiateButtonsCategory(_scriptableAssetModelsTypes);
            }
            _scriptableAssetModelsTypes = _menuManager.scriptableAssetModelsArray.Where(x => x.category == category).ToArray();
        }
    }
}
