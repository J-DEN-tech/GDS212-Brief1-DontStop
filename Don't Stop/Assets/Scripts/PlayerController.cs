using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionReference moveActionRef;
    [SerializeField] private InputActionReference jumpActionRef;

    // Start is called before the first frame update
    void Start()
    {
        moveActionRef.action.performed += OnMove;
        jumpActionRef.action.performed += OnJump;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        
    }

    private void OnJump(InputAction.CallbackContext context)
    {

    }
}
