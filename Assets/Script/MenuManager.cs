using System.Collections.Generic;
using UnityEngine;
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

        private void Awake()
        { 
            if (_instance is null) _instance = this;
        }
    }
}
