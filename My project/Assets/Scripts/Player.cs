using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Color Color;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //ColorPlatform platform = hit.gameObject.GetComponent<ColorPlatform>();
        //if (platform is not null)
        //{
        //    platform.SetColor(Color);
        //}

        if (hit.gameObject.CompareTag("Platform"))
        {
            ColorPlatform platform = hit.gameObject.GetComponent<ColorPlatform>();
            platform.SetColor(Color);
        }
    }
}
