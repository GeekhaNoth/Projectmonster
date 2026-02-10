using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Script
{
    public class ButtonCategory : MonoBehaviour, ISelectHandler
    {
        public AssetAndModel[] assetAndModels;
        
        private MenuManager _menuManager;
        private void Start()
        {
            _menuManager = MenuManager.Instance;
        }

        public void OnSelect(BaseEventData eventData)
        {
            for (var i = 0; i < assetAndModels.Length; i++)
            {
                var imageButton = _menuManager.imageButtonTypeArray[i];
                imageButton.sprite = assetAndModels[i].sprite;
                imageButton.gameObject.SetActive(true);
                var index = Array.IndexOf(_menuManager.buttonCategoryArray, GetComponent<Button>());
                _menuManager.characterPart[index] = assetAndModels[i].model;
            }
            var imageButtonTypeArray = _menuManager.imageButtonTypeArray;
            for (var i = assetAndModels.Length; i < imageButtonTypeArray.Length; i++)
            {
                imageButtonTypeArray[i].gameObject.SetActive(false);
            }
        }
    }
}
