using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed, jumpSpeed;
    [SerializeField] private LayerMask ground;

    private PlayerControls _playerControls;
    private Rigidbody2D _body;
    private Collider2D _collider;
    private float _horizontal;
    private bool _isFacingRight = true;

    private void Awake()
    {
        _playerControls = new PlayerControls();
        _body = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }

    void Start()
    {
        _playerControls.Player.Jump.performed += _ => Jump();
        
    }

    void Update()
    {
        _body.velocity = new Vector2(_horizontal * speed, _body.velocity.y);
        if(!_isFacingRight && _horizontal > 0f)
        {
            Flip();
        }
        else if(_isFacingRight && _horizontal < 0f)
        {
            Flip();
        }
    }

    private void Jump()
    {
        if(IsGrounded())
        {
            _body.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        Vector2 topLeftPoint = transform.position;
        topLeftPoint.x -= _collider.bounds.extents.x;
        topLeftPoint.y += _collider.bounds.extents.y;

        Vector2 bottomRightPoint = transform.position;
        bottomRightPoint.x += _collider.bounds.extents.x;
        bottomRightPoint.y -= _collider.bounds.extents.y;

        return Physics2D.OverlapArea(topLeftPoint, bottomRightPoint, ground);
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        _horizontal = context.ReadValue<Vector2>().x;
    }
}