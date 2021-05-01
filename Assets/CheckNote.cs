using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckNote : MonoBehaviour
{
    public GameObject[] onCheckingObjects;
    public GameObject preReadingText;

    GameManager gm;
    Level3Manager l3m;

    private void Start()
    {
        l3m = GameObject.FindWithTag("Player").GetComponent<Level3Manager>();
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
                l3m.readingObjects.SetActive(true);

            }
            else if (Input.GetKeyDown(KeyCode.E) && gm.reading)
            {
                //print("No reading");
                l3m.readingObjects.SetActive(false);
                if (!l3m.hasRead)
                {
                    l3m.hasRead = true;
                }
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
