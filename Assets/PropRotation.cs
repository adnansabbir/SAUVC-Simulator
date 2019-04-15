
using UnityEngine;

public class PropRotation : MonoBehaviour {


    public Transform prop1;
    public Transform prop2;
    public Transform prop3;
    public Transform prop4;

    public Movement movement;

    // Update is called once per frame
    void FixedUpdate () {
        prop3.transform.Rotate(0, (-movement.up*50) *Time.deltaTime, 0);
        prop4.transform.Rotate(0, (-movement.up * 50) * Time.deltaTime, 0);

        if (Input.GetKey("d") || Input.GetKey("a"))
        {
            prop1.transform.Rotate(0, (movement.side * 50) * Time.deltaTime, 0);
            prop2.transform.Rotate(0, (movement.side * 50) * Time.deltaTime, 0);
        }else if (Input.GetKey("s") || Input.GetKey("w"))
        {
            prop1.transform.Rotate(0, (movement.forward * 50) * Time.deltaTime, 0);
            prop2.transform.Rotate(0, (movement.forward * 50) * Time.deltaTime, 0);
        }
        Debug.Log(movement.up);
	}
}
