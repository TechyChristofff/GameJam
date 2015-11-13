using UnityEngine;
using System.Collections;

public class Torch : MonoBehaviour {

    Light torch;

    public float intensity;
    public float batteryMax;
    public float battery;
    bool allowOn;
	// Use this for initialization
	void Start () {
        torch = this.GetComponent<Light>();
        torch.enabled = false;
        allowOn = true;
        battery = batteryMax;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void FixedUpdate()
    {

        if (Input.GetMouseButton(1) && allowOn)
        {
            torch.enabled = true;
            battery--;
            if (battery <= 0)
                allowOn = false;
        }

        if(!Input.GetMouseButton(1))
        {
            torch.enabled = false;
            battery++;
            if (battery > batteryMax)
            {
                battery = batteryMax;
                allowOn = true;
            }
        }

        if (battery < (batteryMax / 2))
        {
            torch.intensity = intensity * (((battery * 2) / batteryMax));
        }
        else
        {
            torch.intensity = intensity;
        }

        Debug.Log((battery / batteryMax).ToString());
        
    }
}
