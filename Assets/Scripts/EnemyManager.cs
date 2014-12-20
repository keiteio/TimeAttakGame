using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    public int EncounterSec;

    public GameObject EnemyPrefab;

    public Main main;

    private int enemies;

    float lastInitiation = 0;

	// Use this for initialization
	void Start () {
        enemies = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (enemies < 3 && Time.time - lastInitiation > EncounterSec)
        {
            InitiateEnemy();
        }
    }

    public void InitiateEnemy()
    {
        GameObject obj = Instantiate(EnemyPrefab) as GameObject;
        obj.transform.parent = transform;

        Enemy e = obj.GetComponent<Enemy>();
        e.manager = this;
        e.timer = this.main.timer;
        Vector3 pos = e.transform.localPosition;
        pos.y = -1.6f + 1.6f * enemies;
        e.transform.localPosition = pos;

        enemies += 1;

        lastInitiation = Time.time;
    }

    public void OnEnemyDead()
    {
        enemies = Mathf.Max(0, enemies -1);
    }

}
