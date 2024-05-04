using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator Animator;
    public float gravity = 9.8f;
    public float jumpForce;
    public float speed;
    public float RunningTimer = 3;
    public float FallDamage;

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
        Crouch();
        TimerUpdate();
    }

    private void TimerUpdate()
    {
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            RunningTimer += Time.deltaTime;
        }
        if (RunningTimer > 3)
            RunningTimer = 3;
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
            if (Input.GetKey(KeyCode.LeftShift) && _isCrouching == false && RunningTimer > 0)
            {
                Animator.SetBool("IsRunning", true);
                speed = 6;
                _isRunning = true;
                RunningTimer -= Time.deltaTime;
            }
            else
            {
                speed = 3;
                _isRunning = false;
                Animator.SetBool("IsRunning", false);
            }
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
            Animator.SetBool("IsRunning", false);
        }

        if (!Input.GetKey(KeyCode.W) && _isRunning == true)
        {
            speed = 3;
            _isRunning = false;
            Animator.SetBool("IsRunning", false);
        }

    } //_moveVector change according to WASD
    public void JumpAnomalyEffect(float Forse)
    {
        _fallVelocity = -Forse;
        Animator.SetTrigger("Jump");
    }


    void FixedUpdate()
    {
        AplyingMovement();
        AplyingGravity();

        if (_characterController.isGrounded)
        {
            if (_fallVelocity > 5)
                GetComponent<PlayerHealth>().DealDamageToPlayer(FallDamage);
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