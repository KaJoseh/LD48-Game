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
            //gm.currentRoom = GameManager.Rooms.room2;

            switch (gm.currentRoom)
            {
                case GameManager.Rooms.room1:
                    gm.currentRoom = GameManager.Rooms.room2;
                    break;
                case GameManager.Rooms.room2:
                    gm.currentRoom = GameManager.Rooms.room3;
                    break;
                case GameManager.Rooms.room3:
                    gm.currentRoom = GameManager.Rooms.room4;
                    break;
                case GameManager.Rooms.room4:
                    gm.currentRoom = GameManager.Rooms.room5;
                    break;
                case GameManager.Rooms.room5:
                    break;
            }

        }
    }
}
