using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyitemManager : MonoBehaviour
{
    public Sprite[] keySprite;
    public GameObject keyItem;
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
                keyItem.GetComponent<Image>().sprite = keySprite[0];
                break;
            case GameManager.Rooms.room2:
                keyItem.GetComponent<Image>().sprite = keySprite[1];
                break;
            case GameManager.Rooms.room3:
                keyItem.GetComponent<Image>().sprite = keySprite[2];
                break;
            case GameManager.Rooms.room4:
                keyItem.GetComponent<Image>().sprite = keySprite[3];
                break;
            case GameManager.Rooms.room5:
                keyItem.GetComponent<Image>().sprite = keySprite[4];
                break;
        }
    }
}
