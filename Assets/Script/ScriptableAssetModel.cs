using UnityEngine;

namespace Script
{
    [CreateAssetMenu(fileName = "ScriptableAssetModel", menuName = "Scriptable Objects/ScriptableAssetModel")]
    public class ScriptableAssetModel : ScriptableObject
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
        
        public CategoryType category;
        public Sprite sprite;
        public GameObject model;
    }
}
