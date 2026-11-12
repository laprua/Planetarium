using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    float speed = 100;
    float speed_rota = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
            
        if (Input.GetAxis("Horizontal")!=0) {
            transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift)){
            speed *= 100;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)){
            speed /= 100;
        }
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(Vector3.up * speed_rota * mouseX);
        transform.Rotate(Vector3.left * speed_rota * mouseY);
        if(Input.GetKeyDown(KeyCode.Q))
        transform.Rotate(Vector3.forward * speed_rota);
        if (Input.GetKeyDown(KeyCode.E))
            transform.Rotate(Vector3.back * speed_rota);
          

          //  transform.Rotate(Vector3.left /** speed_rota*/);
        //}
    }
}
