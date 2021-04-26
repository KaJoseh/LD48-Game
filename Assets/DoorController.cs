using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject preInteractionText;
    public GameObject hasNotKeyText;

    [Space]

    public float maxYPosition, minYPosition;
    public float vel;

    GameManager gm;
    BoxCollider objBC;

    void Start()
    {
        gm = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        objBC = gameObject.GetComponent<BoxCollider>();
    }

    private void Update()
    {
        //print(gm.doorOpened);
        if (gm.doorOpened)
        {
            if(gameObject.transform.position.y <= maxYPosition)
            {
                gameObject.transform.Translate(Vector3.up * Time.deltaTime * vel);
            }
        }
        else
        {
            if (gameObject.transform.position.y >= minYPosition)
            {
                gameObject.transform.Translate(Vector3.down * Time.deltaTime * vel * 4f);
            }
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.CompareTag("Player") && !gm.hasKey)
            {
                preInteractionText.SetActive(false);
                hasNotKeyText.SetActive(true);
                StartCoroutine(waitToDisable(hasNotKeyText, 0.8f));
            }
            else if(other.CompareTag("Player") && gm.hasKey)
            {
                preInteractionText.SetActive(false);
                StartCoroutine(releaseTheDoor(1f));
                objBC.enabled = false;
                gm.hasKey = false;
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            preInteractionText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            preInteractionText.SetActive(false);
        }
    }

    IEnumerator waitToDisable(GameObject gameObject, float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }

    IEnumerator releaseTheDoor(float time)
    {
        yield return new WaitForSeconds(time);
        gm.doorOpened = true;
    }
}
