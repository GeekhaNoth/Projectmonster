using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Script
{
    public class MenuManager : MonoBehaviour
    {
        private static MenuManager _instance;

        public static MenuManager Instance => _instance;

        public Button[] buttonCategoryArray;
        public Image[] imageButtonTypeArray;
        public GameObject[] characterPart;

        [SerializeField] private Button buttonPrefab;
        [SerializeField] private GameObject gridLayoutGO;

        
        private void Awake()
        { 
            if (_instance is null) _instance = this;
        }

        private void Update()
        {
            if (Keyboard.current.pKey.wasPressedThisFrame) InstantiateButtonTypeCategory();
        }

        private void InstantiateButtonTypeCategory()
        {
            Instantiate(buttonPrefab, gridLayoutGO.transform);
        }
    }
}
