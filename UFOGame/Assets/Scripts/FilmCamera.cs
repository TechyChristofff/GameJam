using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class FilmCamera : MonoBehaviour {

    NoiseAndGrain Film;
    int captureNum = 0;

    // Use this for initialization
    void Start () {
        Film = this.GetComponent<NoiseAndGrain>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Film.enabled = Input.GetMouseButton(0);

        if(Input.GetMouseButtonDown(0))
        {
            Application.CaptureScreenshot("Assets/ScreenCaptures/Shot" + captureNum.ToString() + ".png");
            captureNum++;
        }
    }

    
}
