using UnityEngine;

namespace Script
{
    [CreateAssetMenu(fileName = "ScriptableAssetModel", menuName = "Scriptable Objects/ScriptableAssetModel")]
    public class ScriptableAssetModel : ScriptableObject
    {
        
        
        public MenuManager.CategoryType category;
        public Sprite sprite;
        public GameObject model;
    }
}
