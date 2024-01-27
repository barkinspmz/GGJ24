using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool _canMove = true;
    [SerializeField] private float _playerMovementSpeed = 5f;

    private Rigidbody2D _rb2D;

    public float horizontalInput;
    
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        if (_canMove)
        _rb2D.velocity = new Vector2(horizontalInput*_playerMovementSpeed, _rb2D.velocity.y);
    }
}
