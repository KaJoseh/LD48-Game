using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysCollector : MonoBehaviour
{
    public GameObject gotKeyGUI;

    GameManager gm;


    void Start()
    {
        gm = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (gm.hasKey)
            gotKeyGUI.SetActive(true);
        else
            gotKeyGUI.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            gm.hasKey = true;
            Destroy(other.gameObject);
        }
    }
}
