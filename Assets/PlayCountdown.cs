using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class PlayCountdown : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text tmpText;
    public UnityEvent OnStart;
    public UnityEvent OnEnd;

    private void Start() {
        StartCountdown();
    }

    public void StartCountdown()
    {
        OnStart.Invoke();
        var sequence = DOTween.Sequence();
        tmpText.transform.localScale = Vector3.zero;
        tmpText.text = "3";
        sequence.Append(tmpText.transform.DOScale(
            Vector3.one,
            1).OnComplete(() => 
            {
                tmpText.transform.localScale = Vector3.zero;
                tmpText.text = "2";
            }));

        sequence.Append(tmpText.transform.DOScale(
            Vector3.one,
            1).OnComplete(() => 
            {
                tmpText.transform.localScale = Vector3.zero;
                tmpText.text = "1";
            }));

        sequence.Append(tmpText.transform.DOScale(
            Vector3.one,
            1).OnComplete(() => 
            {
                tmpText.transform.localScale = Vector3.zero;
                tmpText.text = "GO!";
            }));

        sequence.Append(tmpText.transform.DOScale(
            Vector3.one,
            1).OnComplete(() => 
            {
                tmpText.transform.localScale = Vector3.zero;
                tmpText.text = "";
                OnEnd.Invoke();
            }));
    }

}
