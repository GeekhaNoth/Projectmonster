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

        private List<Button> _buttonsInstantiated;
        
        [SerializeField] private GameObject arms;
        [SerializeField] private GameObject legs;
        private void Awake()
        {
            Instance = this;
            scriptableAssetModelsArray = Resources.LoadAll<ScriptableAssetModel>("");
            _buttonsInstantiated = new List<Button>();
        }

        public void InstantiateButtonsCategory(ScriptableAssetModel[] scriptableAssetModels)
        {
            foreach (var scriptable in scriptableAssetModels)
            {
                var buttonInstantiate = Instantiate(buttonPrefab, gridLayoutGo.transform);
                _buttonsInstantiated.Add(buttonInstantiate);
                if (scriptable.sprite is not null) buttonInstantiate.GetComponent<Image>().sprite = scriptable.sprite;
                buttonInstantiate.onClick.AddListener(delegate {ChangeModel(scriptable.model, scriptable.category); });
            }
        }

        public void DestroyButtons()
        {
            foreach (var button in _buttonsInstantiated)
            {
                Destroy(button.gameObject);
            }

            _buttonsInstantiated.Clear();
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
