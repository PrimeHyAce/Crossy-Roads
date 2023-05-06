using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField, Range(0, 1)] private float moveDuration = 0.2f;
    void Start()
    {
        offset = this.transform.position;
    }

    public void UpdatePosition(Vector3 targetposition)
    {
        DOTween.Kill(this.transform);
        transform.DOMove(targetposition + offset, moveDuration);
    }
}
