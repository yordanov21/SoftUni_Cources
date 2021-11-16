using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {

    }


    private void FixedUpdate()
    {
        //movemnt of the player
        var x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        var y = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
        transform.Translate(new Vector3(x, 0, y));
    }
}
