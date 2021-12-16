using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Blue : MonoBehaviour
{

    // For moving platforms
    private bool To_Right = true;
    private float Offset = 1.2f;
    
    
   // float r=  Random.Range(0f, 1f); // assume this is between 0 and 1  
  //  float ra= Mathf.Exp(-0.1f)-1;
    //float rb= Mathf.Exp(-0.3f)-1;

    
    void FixedUpdate()
    {
       // float rbound=ra+(rb-ra)*r;
        //float gang = Mathf.Log(1 - r);
        // Move the platform
        Vector3 Top_Left = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));

        if (To_Right) // Move to right
        {
            if (transform.position.x < -Top_Left.x - Offset)
                transform.position += new Vector3(0.1f, 0, 0);
            else
                To_Right = false;
        }
        else // Move to left
        {
            if (transform.position.x > Top_Left.x + Offset)
                transform.position -= new Vector3(0.1f, 0, 0);
            else
                To_Right = true;
        }
    }
}
