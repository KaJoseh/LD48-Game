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
        for (int i = 0; i < onCheckingObjects.Length; i++)
        {
            //print("leyendo");
            onCheckingObjects[i].SetActive(false);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Note"))
        {
            if (Input.GetKeyDown(KeyCode.E) && !gm.reading)
            {
                preReadingText.SetActive(false);

                gm.reading = true;
                //print("Reading");
                for (int i = 0; i < onCheckingObjects.Length; i++)
                {
                    print("leyendo");
                    onCheckingObjects[i].SetActive(true);
                }

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
        else if (other.CompareTag("CustomNote"))
        {
            
            if (Input.GetKeyDown(KeyCode.E) && !gm.reading)
            {
                preReadingText.SetActive(false);

                gm.reading = true;
                //print("Reading");
                other.transform.GetChild(0).gameObject.SetActive(true);

            }
            else if (Input.GetKeyDown(KeyCode.E) && gm.reading)
            {
                //print("No reading");
                other.transform.GetChild(0).gameObject.SetActive(false);

                gm.reading = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Note") || other.CompareTag("CustomNote") && !gm.reading)
        {
            preReadingText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Note") || other.CompareTag("CustomNote") && !gm.reading)
        {
            preReadingText.SetActive(false);
        }
    }
}
