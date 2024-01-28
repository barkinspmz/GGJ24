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

    private Animator _animator;
    [SerializeField] private GameObject _pressEKey;
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
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
        if (horizontalInput > 0 && _canMove)
        {
            transform.localScale = new Vector2(1,1);
            _pressEKey.transform.localScale = new Vector2(1, 1);
            _animator.SetBool("Move",true);
        }
        else if (horizontalInput < 0 && _canMove)
        {
            transform.localScale = new Vector2(-1, 1);
            _pressEKey.transform.localScale = new Vector2(-1, 1);
            _animator.SetBool("Move", true);
        }
        else
        {
            _animator.SetBool("Move", false);
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
