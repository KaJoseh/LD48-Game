using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractiveCrosshair : MonoBehaviour
{
    public Material eyelessMaterial;
    public Material pyramidEyeMaterial;
    public TextMeshProUGUI interactiveText;
    public GameObject itemEye;
    public Camera cam;

    bool inrange;
    bool eyeTaken;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Eye") && hit.collider.isTrigger && inrange && !eyeTaken)
            {
                interactiveText.SetText("take Eye");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    eyeTaken = true;
                    hit.collider.gameObject.GetComponent<MeshRenderer>().material = eyelessMaterial;
                    //hit.collider.gameObject.GetComponent<AudioSource>().Play();
                    itemEye.SetActive(true);
                }
            }
            else if(hit.collider.CompareTag("PyramidEye") && hit.collider.isTrigger && inrange && eyeTaken)
            {
                interactiveText.SetText("put Eye");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //eyeTaken = false;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CloseToInteract")) 
        {
            inrange = true; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CloseToInteract"))
        {
            inrange = false;
        }
    }
}
