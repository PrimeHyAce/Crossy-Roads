using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [SerializeField, Range(0,1)] float moveDuration = 0.1f;
    [SerializeField, Range(0,1)] float jumpHeight = 0.5f;
    [SerializeField] int leftMoveLimit;
    [SerializeField] int rightMoveLimit;
    [SerializeField] int backMoveLimit;
    public UnityEvent<Vector3> OnJumpEnd;
    public UnityEvent<int> OnGetCoin;
    public UnityEvent OnDie;
    private bool isMoveable = false;
    private void Update() {
        if(isMoveable == false) return;

        if(DOTween.IsTweening(transform)) return;

        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W) 
            || Input.GetKey(KeyCode.UpArrow)){
            direction += Vector3.forward;
            } 
        
        else if (Input.GetKey(KeyCode.S) 
            || Input.GetKey(KeyCode.DownArrow)){
            direction += Vector3.back;
            } 
        
        else if (Input.GetKey(KeyCode.A) 
            || Input.GetKey(KeyCode.LeftArrow)){
            direction += Vector3.left;
            } 
        
        else if (Input.GetKey(KeyCode.D) 
            || Input.GetKey(KeyCode.RightArrow)){
            direction += Vector3.right;
            }

        if (direction == Vector3.zero)  return;

        Move(direction);
        
    }

    public void Move(Vector3 direction)
    {
        var targetPosition = transform.position + direction;
        
        // check if the target position is valid
        if  (targetPosition.x < leftMoveLimit || 
            targetPosition.x > rightMoveLimit || 
            targetPosition.z < backMoveLimit ||
            Tree.AllPositions.Contains(targetPosition))
        { 
            targetPosition = transform.position;
        }

        transform.DOJump(
        targetPosition,
        jumpHeight,
        1, 
        moveDuration)
        .onComplete = BroadcastPositionOnJumpEnd;

        transform.forward = direction;
    }

    public void SetMoveable(bool value)
    {
        isMoveable = value;
    }

    public void UpdateMoveLimit(int horizontalSize, int backLimit)
    {
        leftMoveLimit = -horizontalSize / 2;
        rightMoveLimit = horizontalSize / 2;
        backMoveLimit = backLimit;
    }

    private void BroadcastPositionOnJumpEnd()
    {
        OnJumpEnd.Invoke(transform.position);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Car"))
        {
            if (transform.localScale.y == 0.1f) return;
            
            transform.DOScale(new Vector3(1.5f, 0.1f, 1.5f), 0.2f);
            
            isMoveable = false;
            Invoke("Die", 3);
        }

        else if (other.CompareTag("Coin"))
        {
            var coin = other.GetComponent<Coin>();
            OnGetCoin.Invoke(coin.Value);
            coin.Collected();         
        }

        else if (other.CompareTag("Eagle"))
        {
            if (this.transform != other.transform)
            {
                this.transform.SetParent(other.transform);
                Invoke("Die", 3);
            }
        }
    }

    private void Die()
    {
        OnDie.Invoke();
    }
    
}
