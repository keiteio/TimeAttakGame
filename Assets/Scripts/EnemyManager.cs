using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour {

    public int EncounterSec;

    public GameObject EnemyPrefab;

    public Main main;

    private Dictionary<LineType, Enemy> enemies;

    float lastInitiation = 0;

    bool initiationStopped = false;

	// Use this for initialization
	void Start () {
        enemies = new Dictionary<LineType,Enemy>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!initiationStopped)
        {
            if (enemies.Count < 3 && Time.time - lastInitiation > EncounterSec)
            {
                LineType line = EmptyLine();
                if (LineType.NONE != line)
                {
                    InitiateEnemy(line);
                }
            }
        }
        else
        {
            if (enemies.Count < 3)
            {
                initiationStopped = false;
                lastInitiation = Time.time;
            }
        }
        
    }

    public void InitiateEnemy(LineType line)
    {
        GameObject obj = Instantiate(EnemyPrefab) as GameObject;
        obj.transform.parent = transform;

        Enemy e = obj.GetComponent<Enemy>();
        e.manager = this;
        e.timer = this.main.timer;
        Vector3 pos = e.transform.localPosition;

        switch (line)
        {
            case LineType.UPPER: pos.y = 1.93f; break;
            case LineType.MIDDLE: pos.y = 0; break;
            case LineType.LOWER: pos.y = -1.93f; break;
        }

        pos.x = 4.2f;
        e.transform.localPosition = pos;
        e.Line = line;
        enemies[line] = e;

        lastInitiation = Time.time;

        if (enemies.Count >= 3)
        {
            initiationStopped = true;
        }
    }

    public void OnEnemyDead(LineType line)
    {
        Enemy enemy = enemies[line];
        main.timer.Seconds += enemy.RecoverySeconds;
        main.TotalScore += enemy.Score;

        GameObject.Destroy(enemies[line].gameObject);
        enemies.Remove(line);
    }

    public LineType EmptyLine()
    {
        bool upper = true;
        bool middle = true;
        bool lower = true;
        foreach (LineType l in enemies.Keys)
        {
            switch (l)
            {
                case LineType.UPPER: upper = false; break;
                case LineType.MIDDLE: middle = false; break;
                case LineType.LOWER: lower = false; break;
            }
        }


        List<LineType> empty = new List<LineType>();
        if (upper)
        {
            Debug.Log("UPPER");
            empty.Add(LineType.UPPER);
        }
        if (middle)
        {
            Debug.Log("MIDDLE");
            empty.Add(LineType.MIDDLE);
        }
        if (lower)
        {
            Debug.Log("LOWER");
            empty.Add(LineType.LOWER);
        }

        if (empty.Count == 0)
        {
            Debug.Log("NONE");
            return LineType.NONE;
        }
        else
        {
            return empty[(int)(Mathf.Floor(Random.value * empty.Count))];
        }
    }

}
