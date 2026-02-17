using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
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
            Body,
            LeftArm,
            RightArm,
            LeftLeg,
            RightLeg,
            Tail,
            Wings
        }

        public static MenuManager Instance { get; private set; }

        [SerializedDictionary("Category", "Game Object")]
        public SerializedDictionary<CategoryType, GameObject> monsterBodyParts;
        

        [SerializeField] private Button buttonPrefab;
        [SerializeField] private GameObject gridLayoutGo;

        public ScriptableAssetModel[] scriptableAssetModelsArray;

        public List<Button> buttonsInstantiated;

        [SerializeField] private GameObject testObjetdebase;
        [SerializeField] private GameObject testObjetamettre;
        
        public GameObject arms;
        public GameObject legs;
        private void Awake()
        {
            Instance = this;
            scriptableAssetModelsArray = Resources.LoadAll<ScriptableAssetModel>("");
        }

        private void Update()
        {
            if (Keyboard.current.pKey.wasPressedThisFrame)
            {
                InstantiateButtonTest();
                //testObjetdebase.GetComponent<MeshFilter>().mesh = testObjetamettre.GetComponent<MeshFilter>().sharedMesh;
            }
        }

        public void InstantiateButtonsCategory(ScriptableAssetModel[] scriptableAssetModels)
        {
            foreach (var scriptable in scriptableAssetModels)
            {
                var buttonInstantiate = Instantiate(buttonPrefab, gridLayoutGo.transform);
                buttonsInstantiated.Add(buttonInstantiate);
                if (scriptable.sprite is not null) buttonInstantiate.GetComponent<Image>().sprite = scriptable.sprite;
                buttonInstantiate.onClick.AddListener(delegate {ChangeModel(scriptable.model, scriptable.category); });
            }
        }

        private void InstantiateButtonTest()
        {
            Instantiate(buttonPrefab, gridLayoutGo.transform);
        }

        public void DestroyButtons()
        {
            foreach (var button in buttonsInstantiated)
            {
                Destroy(button.gameObject);
            }
            buttonsInstantiated.Clear();
        }

        private void ChangeModel(GameObject go, CategoryType category)
        {
            var bodyPartGo = monsterBodyParts[category];
            bodyPartGo.GetComponent<MeshFilter>().mesh = go.GetComponent<MeshFilter>().sharedMesh;
        }

        public void ChangeGameObjectArmLegState(bool newState)
        {
            arms.gameObject.SetActive(newState);
            legs.gameObject.SetActive(newState);
        }
    }
}
