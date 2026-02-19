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
             _scriptableAssetModelsTypes = _menuManager.scriptableAssetModelsArray.Where(x => x.category == category).ToArray();
         } 
        
        public void OnSelect(BaseEventData eventData)
        {
            _menuManager.DestroyButtons();
            _menuManager.ChangeGameObjectArmLegState(false);
            _menuManager.InstantiateButtonsCategory(_scriptableAssetModelsTypes);
        }
    }
}
