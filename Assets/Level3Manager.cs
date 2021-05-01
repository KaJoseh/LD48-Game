using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Level3Manager : MonoBehaviour
{
    public Transform newPosition;
    public GameObject falseGoals;
    public GameObject jumpScare;
    public GameObject readingObjects;
    [Space]
    public float speed;
    public PostProcessVolume volume;
    [Space]
    public bool hasRead;

    GameManager gm;


    //private postprocess
    bool completed;
    private void Start()
    {
        gm = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        //volume = gameObject.GetComponent<Volume>();
    }
    // Update is called once per frame
    void Update()
    {
        if (hasRead)
        {
            falseGoals.SetActive(true);
        }

        if (completed)
        {
            Bloom bloom;
            if (volume.profile.TryGetSettings<Bloom>(out bloom) && gm.currentRoom == GameManager.Rooms.room3)
            {
                if (bloom.intensity.value <= 26f)
                {
                    bloom.intensity.value += Time.deltaTime * speed;
                }
                else
                {
                    jumpScare.SetActive(false);
                    falseGoals.SetActive(false);
                    bloom.intensity.value = 0.2f;

                    gameObject.transform.position = newPosition.position;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EventTrigger") && hasRead)
        {
            jumpScare.SetActive(true);
            completed = true;
        }
    }
}
