using UnityEngine;
using UnityEngine.InputSystem;

namespace Script
{
    public class CharaRotation : MonoBehaviour
    {
        private GlobalInput _inputs;
        private GlobalInput.UI_ControlActions _uiControl;
    
        private float _rotation;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Awake()
        {
            _inputs = new GlobalInput();
            _uiControl = _inputs.UI_Control;
            SubInputs();
            _inputs.Enable();
        }

        void SubInputs()
        {
            _uiControl.Rotation.performed += GetRotation;
            _uiControl.Rotation.canceled += GetRotation;
        }
    
        void GetRotation(InputAction.CallbackContext ctx)
        {
            _rotation = ctx.ReadValue<float>();
        }

        void UnsubInputs()
        {
            _uiControl.Rotation.performed -= GetRotation;
            _uiControl.Rotation.canceled -= GetRotation;
        }
        // Update is called once per frame
        private void Update()
        {
            MoveCharacter();
        }

        private void MoveCharacter()
        {
            var actualRotation = transform.rotation.eulerAngles;
            actualRotation.y -= _rotation;
            transform.rotation =  Quaternion.Euler(actualRotation);
        }
    }
}
