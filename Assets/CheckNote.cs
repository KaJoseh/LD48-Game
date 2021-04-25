using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckNote : MonoBehaviour
{
    public GameObject[] onCheckingObjects;
    public GameObject preReadingText;

    GameManager gm;

    private void Start()
    {
        gm = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Note"))
        {
            if (Input.GetKeyDown(KeyCode.E) && !gm.reading)
            {
                preReadingText.SetActive(false);
                //print("Reading");
                for(int i = 0; i < onCheckingObjects.Length; i++)
                {
                    onCheckingObjects[i].SetActive(true);
                }

                gm.reading = true;
            }
            else if(Input.GetKeyDown(KeyCode.E) && gm.reading)
            {
                //print("No reading");
                for (int i = 0; i < onCheckingObjects.Length; i++)
                {
                    onCheckingObjects[i].SetActive(false);
                }

                gm.reading = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Note") && !gm.reading)
        {
            preReadingText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Note") && !gm.reading)
        {
            preReadingText.SetActive(false);
        }
    }
}