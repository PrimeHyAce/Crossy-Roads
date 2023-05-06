using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    [SerializeField] int value = 1;

    public int Value { get => value; }

    public void Collected()
    {
        GetComponent<Collider>().enabled = false;
        this.transform.DOJump(
            this.transform.position,
            1.5f,
            1,
            0.6f
        ).onComplete = SelfDestruct;
    }

    private void Update() {
        transform.Rotate(Vector3.up * 100 * Time.deltaTime);
    }
    
    private void SelfDestruct()
    {
        Destroy(this.gameObject);
    }
}
