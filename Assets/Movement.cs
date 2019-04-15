using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{


    public Camera cam1;
    public Camera cam2;


    private Color _fogColorWater;
    public float fogDesity = 0.005f;

    public Transform waterPlane;


    public Rigidbody rb;
    // Use this for initialization
    public float up = 0f;
    public float side = 0f;
    public float forward = 0f;
    public float right = 0f;


    public float sideForce = 0;
    public float ForwardForce = 0;
    public float upForce = 0;
    public float rightForce = 0f;

    public float red = 0.0f;
    public float green = .25f;
    public float blue = .55f;

    private void Start()
    {
        
        _fogColorWater = new Color(red, green, blue, 0.5f);
        RenderSettings.fog = true;
        RenderSettings.fogColor = _fogColorWater;
        RenderSettings.fogDensity = fogDesity;
        RenderSettings.fogMode = FogMode.Exponential;

        cam1.enabled = false;
        cam2.enabled = true;
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        //Vector3 position = transform.position;
        //position.y = up;
        //transform.position = position;
        _fogColorWater = new Color(red, green, blue, 0.5f);
        RenderSettings.fogColor = _fogColorWater;
        RenderSettings.fogDensity = fogDesity;


        rb.AddForce(0, up * Time.deltaTime, 0);
        rb.AddRelativeForce(side * Time.deltaTime, 0, 0);
        rb.AddRelativeForce(0, 0, forward * Time.deltaTime);
        transform.Rotate(0, right * Time.deltaTime, 0);

        
;
        //Debug.Log(right);

        if (Input.GetKey("space"))
        {
            if (up > -upForce)
                up -= .1f;
        }
        else
        {
            if (transform.position.y < 18)
            {
                if (up < upForce)
                    up += .1f;
            }
            if (transform.position.y > waterPlane.position.y-5)
                up = 0;
        }

        if (Input.GetKey("d"))
        {
            if (side < sideForce)
                side += .1f;
        }
        else if (Input.GetKey("a"))
        {
            if (side > -sideForce)
                side -= .1f;
        }
        else
        {
            if (side > 0)
                side -= .1f;
            if (side < 0)
                side += .1f;
        }

        if (Input.GetKey("w"))
        {
            if (forward < ForwardForce)
                forward += .1f;
        }
        else if (Input.GetKey("s"))
        {
            if (forward > -ForwardForce)
                forward -= .1f;
        }
        else
        {
            if (forward > 0)
                forward -= .1f;
            if (forward < 0)
                forward += .1f;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (right < rightForce)
                right += .1f;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (right > -rightForce)
                right -= .1f;
        }
        else
        {
            if (right > 0)
                right -= .05f;
            if (right < 0)
                right += .05f;
        }

        if (Input.GetKeyDown("c"))
        {
            Debug.Log(cam1.enabled);
            if (cam1.enabled) {
                cam2.enabled = true;
                cam1.enabled = false;
            }else if (cam2.enabled)
            {
                cam1.enabled = true;
                cam2.enabled = false;
            }

        }

        

    }
}
