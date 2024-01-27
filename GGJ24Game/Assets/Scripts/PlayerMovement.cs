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
        DialogueManager.Instance.ZoomInCam += LockPlayerMovement; 
        DialogueManager.Instance.ZoomOutCam += UnlockPlayerMovement;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) &&_canMove && Physics2D.OverlapCircle(feetPos.position, 0.1f, floorMask))
        {
            _rb2D.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && DialogueManager.Instance.isCinematicActive)
        {
            DialogueManager.Instance.CloseDialogueCinematic();
        }
    }

    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (_canMove)
        {
            _rb2D.velocity = new Vector2(horizontalInput * _playerMovementSpeed, _rb2D.velocity.y);
        }
    }

    private void LockPlayerMovement()
    {
        _canMove = false;
    }

    private void UnlockPlayerMovement()
    {
        _canMove = true;
    }
}
