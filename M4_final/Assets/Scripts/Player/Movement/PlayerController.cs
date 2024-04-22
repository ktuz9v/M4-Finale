using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator Animator;
    public float gravity = 9.8f;
    public float jumpForce;
    public float speed;

    Vector3 _moveVector;
    float _fallVelocity = 0;
    bool _isCrouching;
    bool _isRunning;

    CharacterController _characterController;

    void Start()
    {
        ComponentAdd();
    }
    private void ComponentAdd()
    {
        _characterController = GetComponent<CharacterController>();
    }


    void Update()
    {
        MovementForseAdd();
        Jump();
        Run();
        Crouch();
    }
    private void Crouch()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            _characterController.height = 1;
            _characterController.center = new Vector3(0, 1.2f, 0);
            speed = 1f;
            _isCrouching = true;
        }
        else
        {
            _characterController.height = 1.7f;
            _characterController.center = new Vector3(0, 0.85f, 0);
            if (_isRunning == false)
                speed = 3f;
            else
                speed = 6;
            _isCrouching = false;
        }
    }
    private void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift) && _isCrouching == false)
        {
            speed = 6;
            _isRunning = true;
        }    
        else
        {
            speed = 3;
            _isRunning = false;
        }
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -jumpForce;
            Animator.SetTrigger("Jump");
        }
    }
    private void MovementForseAdd()
    {
        _moveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
            Animator.SetFloat("FrontSpeed", 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
            Animator.SetFloat("FrontSpeed", -1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
            Animator.SetFloat("SideSpeed", -1);
            Animator.SetFloat("FrontSpeed", 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
            Animator.SetFloat("SideSpeed", 1);
            Animator.SetFloat("FrontSpeed", 0);
        }

        if (_moveVector == Vector3.zero)
        {
            Animator.SetFloat("FrontSpeed", 0);
            Animator.SetFloat("SideSpeed", 0);
        }
    } //_moveVector change according to WASD


    void FixedUpdate()
    {
        AplyingMovement();
        AplyingGravity();

        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;
        } //Grounded check
    }
    private void AplyingGravity()
    {
        _fallVelocity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);
    }
    private void AplyingMovement()
    {
        _characterController.Move(_moveVector * speed * Time.fixedDeltaTime);
    }
}