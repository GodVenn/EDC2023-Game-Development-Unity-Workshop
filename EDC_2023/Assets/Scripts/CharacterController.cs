using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float Speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = transform.position + Vector3.up * 1;
        }

        float leftRight = Input.GetAxis("Horizontal");
        float forwardBackward = Input.GetAxis("Vertical");

        transform.position += new Vector3(leftRight, 0, forwardBackward) * Speed * Time.deltaTime;
    }
}
