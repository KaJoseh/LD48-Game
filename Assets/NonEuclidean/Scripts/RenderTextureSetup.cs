using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderTextureSetup : MonoBehaviour
{
    public Camera camera1;
    //public Camera camera2;

    public Material camera1Mat;
    //public Material camera2Mat;
    
    void Start()
    {
        if (camera1.targetTexture != null)
        {
            camera1.targetTexture.Release();
        }
        camera1.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        camera1Mat.mainTexture = camera1.targetTexture;

        /*if (camera2.targetTexture != null)
        {
            camera2.targetTexture.Release();
        }
        camera2.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        camera2Mat.mainTexture = camera2.targetTexture;
        */
    }
}
