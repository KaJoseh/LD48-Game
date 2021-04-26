using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //print("Entramos");
        if (other.CompareTag("Player"))
        {
            //print("Cerrando");
            if (gm.doorOpened)
                gm.doorOpened = false;
            gm.currentRoom = GameManager.Rooms.room2;

        }
    }
}
