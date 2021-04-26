using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class noteTextManager : MonoBehaviour
{
    public TextMeshProUGUI noteText;

    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (gm.currentRoom)
        {
            case GameManager.Rooms.room1:
                noteText.SetText("Open the door");
                break;
            case GameManager.Rooms.room2:
                noteText.SetText("I have lost my eye, give it back to me");
                break;
            case GameManager.Rooms.room3:
                break;
            case GameManager.Rooms.room4:
                break;
            case GameManager.Rooms.room5:
                break;


        }
    }
}
