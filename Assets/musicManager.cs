using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManager : MonoBehaviour
{
    public GameObject[] musicObject;

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
                for(int i = 0; i < musicObject.Length; i++)
                {
                    if(i != 0)
                    {
                        musicObject[i].SetActive(false);
                    }
                    else
                        musicObject[i].SetActive(true);
                }
                break;
            case GameManager.Rooms.room2:
                for (int i = 0; i < musicObject.Length; i++)
                {
                    if (i != 1)
                    {
                        musicObject[i].SetActive(false);
                    }
                    else
                        musicObject[i].SetActive(true);
                }
                break;
            case GameManager.Rooms.room3:
                for (int i = 0; i < musicObject.Length; i++)
                {
                    if (i != 2)
                    {
                        musicObject[i].SetActive(false);
                    }
                    else
                        musicObject[i].SetActive(true);
                }
                break;
            case GameManager.Rooms.room4:
                break;
            case GameManager.Rooms.room5:
                break;
        }
    }
}
