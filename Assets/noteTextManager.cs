using UnityEngine;
using TMPro;

public class noteTextManager : MonoBehaviour
{
    public TextMeshProUGUI noteText;

    [TextArea]
    public string text1, text2, text3, text4, text5;

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
                noteText.SetText(text1);
                break;
            case GameManager.Rooms.room2:
                noteText.SetText(text2);
                break;
            case GameManager.Rooms.room3:
                noteText.SetText(text3);
                break;
            case GameManager.Rooms.room4:
                break;
            case GameManager.Rooms.room5:
                break;
        }
    }
}
