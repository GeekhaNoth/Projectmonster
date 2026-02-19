using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Script
{
    public class ButtonLeftRight : MonoBehaviour, ISelectHandler
    {
        private MenuManager _menuManager;
        
        [SerializeField] private Image left;
        [SerializeField] private Image right;
        
        private GameObject _children;
        private void Start()
        {
            _menuManager = MenuManager.Instance;
            _children = transform.GetChild(0).gameObject;
            //GetComponent<Button>().onClick.AddListener(OnClick);
        }


        public void OnSelect(BaseEventData eventData)
        {
            _menuManager.DestroyButtons();
            _menuManager.ChangeGameObjectArmLegState(false);
            if (!_children.activeSelf) _children.SetActive(true);
        }
        
        /*public void OnClick()
        {
            _menuManager.DestroyButtons();
            _menuManager.ChangeGameObjectArmLegState(false);
            if (!_children.activeSelf) _children.SetActive(true);
        }*/
        
        
    }
}
