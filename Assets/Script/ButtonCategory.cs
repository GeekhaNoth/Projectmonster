using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Script
{
    public class ButtonCategory : MonoBehaviour, ISelectHandler
    { 
        public MenuManager.CategoryType category; 
        
        private MenuManager _menuManager;

        public ScriptableAssetModel[] _scriptableAssetModelsTypes;
        
        private void Start()
         {
             _menuManager = MenuManager.Instance;
         } 
        
        public void OnSelect(BaseEventData eventData)
        {
            _menuManager.DestroyButtons();
            _menuManager.ChangeGameObjectArmLegState(false);
            if (_scriptableAssetModelsTypes.Length == 0)
            {
                _scriptableAssetModelsTypes = _menuManager.scriptableAssetModelsArray.Where(x => x.category == category).ToArray();
            }
            _menuManager.InstantiateButtonsCategory(_scriptableAssetModelsTypes);
        }

        public void ButtonLeftRight(bool newState)
        {
            var aa = GetComponent<ButtonLeftRight>();
            transform.GetChild(0).gameObject.SetActive(newState);
        }
    }
}
