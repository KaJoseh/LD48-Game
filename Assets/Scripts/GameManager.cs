using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public bool reading;
    [HideInInspector]
    public bool hasKey;
    [HideInInspector]
    public bool doorOpened;

    public enum Rooms
    {
        room1,
        room2,
        room3,
        room4,
        room5
    }

    public Rooms currentRoom;

    // Start is called before the first frame update
    void Start()
    {
        currentRoom = Rooms.room1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
