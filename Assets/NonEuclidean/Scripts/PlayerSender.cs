using System;
using UnityEngine;

public class PlayerSender : MonoBehaviour
{
    public GameObject player;
    public GameObject destination;
    public bool turnPlayer = false;

    private float prevDot = 0;
    private bool playerOverlapping = false;
    CharacterController cc;

    private void Start()
    {
        cc = player.GetComponent<CharacterController>();
    }

    void Update()
    {
        if (playerOverlapping) {
            var currentDot = Vector3.Dot(transform.up, player.transform.position - transform.position);

            if (currentDot < 0)
            {
                float rotDiff = -Quaternion.Angle(transform.rotation, destination.transform.rotation);
                if (turnPlayer)
                {
                    rotDiff += 180;
                    player.transform.Rotate(Vector3.up, rotDiff);
                }
                
                Vector3 positionOffset = player.transform.position - transform.position;
                positionOffset = Quaternion.Euler(0, rotDiff, 0) * positionOffset;
                var newPosition = destination.transform.position + positionOffset;
                print("Teleporting player to position of: " + destination.name);
                cc.enabled = false;
                player.transform.position = newPosition;
                cc.enabled = true;
                playerOverlapping = false;
            }
               
            prevDot = currentDot;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOverlapping = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOverlapping = false;
        }
    }
}
