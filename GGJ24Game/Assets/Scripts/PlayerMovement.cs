using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _playerMovementSpeed = 5f;
    [SerializeField] private float jumpForce = 30f;

    private Rigidbody2D _rb2D;

    private float horizontalInput;

    [SerializeField] private Transform feetPos = null;
    [SerializeField] private LayerMask floorMask;

    private bool _canMove = true;
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) &&_canMove && Physics2D.OverlapCircle(feetPos.position, 0.3f, floorMask))
        {
            _rb2D.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        if (_canMove)
        {
            _rb2D.velocity = new Vector2(horizontalInput * _playerMovementSpeed, _rb2D.velocity.y);
        }
    }
}
