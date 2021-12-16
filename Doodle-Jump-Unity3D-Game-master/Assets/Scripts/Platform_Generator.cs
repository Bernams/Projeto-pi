using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Generator : MonoBehaviour {

    public GameObject Platform_Green;
    public GameObject Platform_Blue;
    public GameObject Platform_White;

    public GameObject Spring;
    public GameObject Trampoline;
    public GameObject Propeller;

    private GameObject Platform;
    private GameObject Random_Object;

    public float Current_Y = 0;
    float Offset;
    Vector3 Top_Left;
    
	// Use this for initialization
	void Start () 
    {
        // Initialize boundary
        Top_Left = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Offset = 1.2f;

        // Initialize platforms
        Generate_Platform(50);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public static float RandomGaussian(float minValue = -10f, float maxValue = 10f)
    {
        float u, v, S;
        do
        {
            u = 2.0f * UnityEngine.Random.value - 1.0f;
            v = 2.0f * UnityEngine.Random.value - 1.0f;
            S = u * u + v * v;
        }
        while (S >= 1.0f);
    
        // Standard Normal Distribution
        float std = u * Mathf.Sqrt(-2.0f * Mathf.Log(S) / S);
    
        // Normal Distribution centered between the min and max value
        // and clamped following the "three-sigma rule"
        float mean = (minValue + maxValue) / 2.0f;
        float sigma = (maxValue - mean) / 3.0f;
        return Mathf.Clamp(std * sigma + mean, minValue, maxValue);
    }
    public void Generate_Platform(int Num)
    {
        for (int i = 0; i < Num; i++)
        {
            float Dist_X = RandomGaussian();
            float Dist_Y = Random.Range(2f, 3f);

           // int Rand_BrownPlatform = Random.Range(1, 8);

            //if (Rand_BrownPlatform == 1)
            //{
           //     float Brown_DistX = Random.Range(Top_Left.x + Offset, -Top_Left.x - Offset);
            //    float Brown_DistY = Random.Range(Current_Y + 1, Current_Y + Dist_Y - 1);
            //    Vector3 BrownPlatform_Pos = new Vector3(Brown_DistX, Brown_DistY, 0);
            //
            //    Instantiate(Platform_Brown, BrownPlatform_Pos, Quaternion.identity);
           // }

            // Create other platform
            Current_Y += Dist_Y;
            Vector3 Platform_Pos = new Vector3(Dist_X, Current_Y, 0);
            int Rand_Platform = Random.Range(1, 10);

            if (Rand_Platform == 1 || Rand_Platform == 2) // Create blue platform
                Platform = Instantiate(Platform_Blue, Platform_Pos, Quaternion.identity);
            else if (Rand_Platform == 3) // Create white platform
                Platform = Instantiate(Platform_White, Platform_Pos, Quaternion.identity);
            else // Create green platform
                Platform = Instantiate(Platform_Green, Platform_Pos, Quaternion.identity);

            if (Rand_Platform != 2)
            {
                // Create random objects; like spring, trampoline and etc...
                int Rand_Object = Random.Range(1, 50);

                if (Rand_Object >= 1 && Rand_Object < 5) // Create spring
                {
                    Vector3 Spring_Pos = new Vector3(Platform_Pos.x + 0.5f, Platform_Pos.y + 0.27f, 0);
                    Random_Object = Instantiate(Spring, Spring_Pos, Quaternion.identity);
                    
                    // Set parent to object
                    Random_Object.transform.parent = Platform.transform;
                }
                else if (Rand_Object >= 5 && Rand_Object < 7) // Create trampoline
                {
                    Vector3 Trampoline_Pos = new Vector3(Platform_Pos.x + 0.13f, Platform_Pos.y + 0.25f, 0);
                    Random_Object = Instantiate(Trampoline, Trampoline_Pos, Quaternion.identity);

                    // Set parent to object
                    Random_Object.transform.parent = Platform.transform;
                }
                else if (Rand_Object == 7) // Create propeller
                {
                    Vector3 Propeller_Pos = new Vector3(Platform_Pos.x + 0.13f, Platform_Pos.y + 0.15f, 0);
                    Random_Object = Instantiate(Propeller, Propeller_Pos, Quaternion.identity);

                    // Set parent to object
                    Random_Object.transform.parent = Platform.transform;
                }
            }
        }
    }
}
