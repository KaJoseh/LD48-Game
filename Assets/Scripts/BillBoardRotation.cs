using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoardRotation : MonoBehaviour
{
    GameObject _Player;
    // Start is called before the first frame update
    void Start()
    {
        _Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_Player.transform);
    }
}
