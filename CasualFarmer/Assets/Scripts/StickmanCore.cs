using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

//using DG.Tweening;

public class StickmanCore : MonoBehaviour
{
    #region Variables
    //[Header("Core Settings")]

    public bool CanMove { get; private set; }
    public Status LifeStatus { get; private set; }
    public bool IsPlayer { get; protected set; }
    
    private CharacterController _myController;
    private Vector3 _velocity;
    private Vector3 _playerVelocityY;
    private float _gravityValue = -9.8f;
    
    protected Animator _myAnimator;
    #endregion

    #region UnityMethods
    public virtual void Awake()
    {
        _myAnimator = GetComponent<Animator>();
        _myController = GetComponent<CharacterController>();

        CanMove = true;
        LifeStatus = Status.Live;
        
    }
    
    #endregion

    #region Movement
    public void Move(Vector3 direction)
    {
        gravity();
        
        _myController.Move(direction * Time.deltaTime);
        _myController.Move(_playerVelocityY * Time.deltaTime);

        MoveAnimationSpeed(direction.magnitude);

        if (direction != Vector3.zero)
            transform.forward = Vector3.SmoothDamp(transform.forward, direction, ref _velocity, 1f * Time.deltaTime);
    }
    #endregion

    #region Logic

    #endregion

    #region Physics
    private void gravity()
    {
        if (!_myController.isGrounded)
        {
            _playerVelocityY.y += _gravityValue * Time.deltaTime;

        }
        else
        {
            _playerVelocityY.y = 0f;
        }
    }

    #endregion

    #region Animations
    public void MoveAnimationSpeed(float speed)
    {
        _myAnimator.SetFloat("Speed", speed);
    }

    /*private void PlayAnimation(AnimationType animation)
    {
        foreach (var item in System.Enum.GetNames(typeof(AnimationType)))
            _myAnimator.ResetTrigger(item);

        _myAnimator.Play(animation.ToString());
    }
    #endregion

    #region Enums
    public enum AnimationType
    {
        Move,
        Delivering
    }*/

    public enum Status
    {
        Live,
        DeliveringOrder
    }
    #endregion
}
