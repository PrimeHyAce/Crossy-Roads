using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleSpawner : MonoBehaviour
{
    [SerializeField] Eagle eagle;
    [SerializeField] Astrounaut astrounaut;
    [SerializeField] float initialTimer =10;
    float timer;

    private void Start() {
        timer = initialTimer;
        eagle.gameObject.SetActive(false);
    }

    private void Update() {
        float fwDistance = FindObjectOfType<PlayManager>().travelDistance;

        //check if astronaut go back more than 4 tiles
        if(astrounaut.transform.position.z < fwDistance - 4 && eagle.gameObject.activeInHierarchy == false)
        {
            eagle.gameObject.SetActive(true);
            eagle.transform.position = astrounaut.transform.position + new Vector3(0, 1, 13);
            astrounaut.SetMoveable(false);
        } else if(timer <= 0 && eagle.gameObject.activeInHierarchy == false)
            {
                eagle.gameObject.SetActive(true);
                eagle.transform.position = astrounaut.transform.position + new Vector3(0, 1, 13);
                astrounaut.SetMoveable(false);
            }

        timer -= Time.deltaTime;

        
    }

    public void ResetTimer()
    {
        timer = initialTimer;
    }

}
