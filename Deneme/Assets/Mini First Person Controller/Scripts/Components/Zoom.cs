using UnityEngine;

[ExecuteInEditMode]
public class Zoom : MonoBehaviour
{
    new Camera camera;
    public float defaultFOV = 60;
    [Range(0, 1)]
    public float sensitivity = 1;


    void Awake()
    {
        // Get the camera on this gameObject and the defaultZoom.
        camera = GetComponent<Camera>();
        if (camera)
        {
            defaultFOV = camera.fieldOfView;
        }
    }

    void Update()
    {
        // Update the currentZoom and the camera's fieldOfView.
       
    }
}
