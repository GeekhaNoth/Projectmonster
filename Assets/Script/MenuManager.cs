using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Script
{
    public class MenuManager : MonoBehaviour
    {
        public enum CategoryType
        {
            Head,
            LeftArm,
            RightArm,
            LeftLeg,
            RightLeg,
            Tail,
            Wings
        }

        public static MenuManager Instance { get; private set; }

        public Button[] buttonCategoryArray;
        private Dictionary<CategoryType, GameObject> _monsterBodyParts;

        [SerializeField] private Button buttonPrefab;
        [SerializeField] private GameObject gridLayoutGo;

        public ScriptableAssetModel[] scriptableAssetModelsArray;



        [SerializeField] private GameObject testObjetdebase;
        [SerializeField] private GameObject testObjetamettre;
        private void Awake()
        {
            Instance = this;
            scriptableAssetModelsArray = Resources.LoadAll<ScriptableAssetModel>("");
        }

        private void Update()
        {
            if (Keyboard.current.pKey.wasPressedThisFrame)
            {
                //InstantiateButtonTest();
                testObjetdebase.GetComponent<MeshFilter>().mesh = testObjetamettre.GetComponent<MeshFilter>().sharedMesh;
            }
        }

        public void InstantiateButtonsCategory(ScriptableAssetModel[] scriptableAssetModels)
        {
            foreach (var scriptable in scriptableAssetModels)
            {
                var buttonInstantiate = Instantiate(buttonPrefab, gridLayoutGo.transform);
                buttonInstantiate.GetComponent<Image>().sprite = scriptable.sprite;
                buttonInstantiate.onClick.AddListener(delegate {ChangeModel(scriptable.model, scriptable.category); });
            }
        }

        private void InstantiateButtonTest()
        {
            Instantiate(buttonPrefab, gridLayoutGo.transform);
        }

        private void ChangeModel(GameObject go, CategoryType category)
        {
            var bodyPart = _monsterBodyParts[category];
            bodyPart.GetComponent<MeshFilter>().mesh = go.GetComponent<MeshFilter>().mesh;
        }
    }
}
