using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCharacterController : MonoBehaviour
{
    public float speed = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var frontBack = Input.GetAxis("Vertical");
        var leftRight = Input.GetAxis("Horizontal");

        transform.position += transform.forward * frontBack * speed * Time.deltaTime;
        transform.position += transform.right * leftRight * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = transform.position + new Vector3(0, 1, 0);
        }
    }
}
