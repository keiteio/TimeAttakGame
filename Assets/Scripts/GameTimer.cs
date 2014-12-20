using UnityEngine;
using System.Collections;

public class GameTimer : MonoBehaviour{

    public float Seconds { get; set; }

    void Start()
    {
        Seconds = 60;
    }
}
