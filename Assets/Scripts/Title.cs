using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {

    private float birthTime = 0;

	// Use this for initialization
	void Start () {
        birthTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - birthTime > 1.0)
        {
            Vector3 s = this.transform.localPosition;
            if (s.y < 50) {
                s.y = s.y + 0.2f;
                this.transform.localPosition = s;
            }
        }
	}
}
