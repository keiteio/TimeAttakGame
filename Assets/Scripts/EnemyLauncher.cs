using UnityEngine;
using System.Collections;

public class EnemyLauncher : Emitter {

    /// <summary>
    /// 敵の移動方向変化リスト
    /// </summary>
    public float[] DirectionList;

    /// <summary>
    /// 敵の移動方向変化インターバル(秒)
    /// </summary>
    public float TurningInterval;

	// Use this for initialization
    void Start()
    {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
        base.Update();
	}

    GameObject InitiateEnemy(GameObject enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        e.DirectionList = this.DirectionList;
        e.TurningInterval = this.TurningInterval;
        return enemy;
    }
}
