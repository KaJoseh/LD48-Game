using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractiveCrosshair : MonoBehaviour
{

    public GameObject lockingWall;
    public float raycastDistance;
    public Material eyelessMaterial;
    public Material pyramidEyeMaterial;
    public TextMeshProUGUI interactiveText;
    public GameObject itemEye;
    public Camera cam;

    bool eyeTaken;
    bool completed;

    // Start is called before the first frame update
    void Start()
    {
        interactiveText.SetText("");
    }

    // Update is called once per frame
    void Update()
    {
        if (completed)
        {
            StartCoroutine(wait(1));
        }

        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            Debug.DrawLine(ray.origin, hit.point);
            if (hit.collider.CompareTag("Eye") && hit.collider.isTrigger && !eyeTaken && !completed)
            {
                interactiveText.SetText("take Eye");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    eyeTaken = true;
                    hit.collider.gameObject.GetComponent<MeshRenderer>().material = eyelessMaterial;
                    hit.collider.gameObject.GetComponent<AudioSource>().Play();
                    itemEye.SetActive(true);
                }
            }
            else if(hit.collider.CompareTag("PyramidEye") && hit.collider.isTrigger && eyeTaken && !completed)
            {
                interactiveText.SetText("put Eye");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    completed = true;
                    hit.collider.gameObject.GetComponent<MeshRenderer>().material = pyramidEyeMaterial;
                    itemEye.SetActive(false);
                    
                }
            }
            else
            {
                interactiveText.SetText("");
            }
        }
    }

    IEnumerator wait (float time)
    {
        yield return new WaitForSeconds(time);
        lockingWall.transform.position = new Vector3(lockingWall.transform.position.x, 4.0f, lockingWall.transform.position.z);
    }
}
