using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

    public GameTimer timer;
    public GameObject EnemyManagerPrefab;


	// Use this for initialization
	void Start () {
        GameObject obj = Instantiate(EnemyManagerPrefab) as GameObject;
        obj.transform.parent = this.transform;

        EnemyManager em = obj.GetComponent<EnemyManager>();
        em.main = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
