using UnityEngine;
using System.Collections;

public class Enemy : Bullet {

    public float[] DirectionList { get; set; }

    public float TurningInterval { get; set; }

    private int DirectionIndex = 0;

    private float LastTurned = -1;

	// Use this for initialization
	void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
        if (DirectionList != null)
        {
            if (Time.time - LastTurned > TurningInterval)
            {
                DirectionIndex = (DirectionIndex + 1) % DirectionList.Length;
            }
            Force f = this.GetComponent<Force>();
            f.Direction = DirectionList[DirectionIndex];
        }

        base.Update();
	}
}
