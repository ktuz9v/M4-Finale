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
    CapsuleCollider _capsuleCollider;

    public AudioSource WalkingAudio;
    bool _audioIsPlaying;

    public AudioSource RunningAudio;
    bool _isRunningAudio;

    public AudioSource CrouchingAudio;
    bool _isCrouchingAudio;

    public AudioSource JumpSound;

    float _timeAfterJump;
    void Start()
    {
        ComponentAdd();
        _timeAfterJump = 20;
    }
    private void ComponentAdd()
    {
        _characterController = GetComponent<CharacterController>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
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
        _timeAfterJump += Time.deltaTime;
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
            _capsuleCollider.height = 1;
            _capsuleCollider.center = new Vector3(0, 1.2f, 0);
            speed = 1f;
            _isCrouching = true;
            WalkingAudio.Stop();
            _audioIsPlaying = false;
            if (!_isCrouchingAudio)
            {
                _isCrouchingAudio = true;
                CrouchingAudio.Play();
            }
        }
        else
        {
            _characterController.height = 1.7f;
            _characterController.center = new Vector3(0, 0.85f, 0);
            _capsuleCollider.height = 1.7f;
            _capsuleCollider.center = new Vector3(0, 0.85f, 0);
            if (_isRunning == false)
                speed = 3f;
            else
                speed = 6;
            _isCrouching = false;
            _isCrouchingAudio = false;
            CrouchingAudio.Stop();
        }
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -jumpForce;
            Animator.SetTrigger("Jump");
            JumpSound.Play();
            WalkingAudio.Stop();
            RunningAudio.Stop();
            CrouchingAudio.Stop();
            _isCrouchingAudio = true;
            _isRunningAudio = true;
            _audioIsPlaying = true;
            _timeAfterJump = 0;
        }
        if (_characterController.isGrounded && _timeAfterJump < 1.5f)
        {
            _isRunningAudio = false;
            _isCrouchingAudio = false;
            _audioIsPlaying = false;
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
                WalkingAudio.Stop();
                _audioIsPlaying = false;
                if (!_isRunningAudio)
                {
                    RunningAudio.Play();
                    _isRunningAudio = true;
                }
            }
            else
            {
                speed = 3;
                _isRunning = false;
                Animator.SetBool("IsRunning", false);
                RunningAudio.Stop();
                _isRunningAudio = false;
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
            WalkingAudio.Stop();
            _audioIsPlaying = false;
        }
        else if (!_audioIsPlaying && !_isRunning && !_isCrouching)
        {
            WalkingAudio.Play();
            _audioIsPlaying = true;
        }

        if (!Input.GetKey(KeyCode.W) && _isRunning == true)
        {
            speed = 3;
            _isRunning = false;
            Animator.SetBool("IsRunning", false);
            RunningAudio.Stop();
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
            if (_fallVelocity > 6.5)
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