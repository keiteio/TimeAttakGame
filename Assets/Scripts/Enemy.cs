using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum LineType
{
    UPPER,
    MIDDLE,
    LOWER,
    NONE,
}

public class Enemy : MonoBehaviour {

    public int HitPointMax;

    public int AttackSeconds;

    public int RecoverySeconds;
    
    public int WaitSecForAttack;

    public GameTimer timer;

    public int HitPoint { get; private set; }

    public bool IsDead {get; private set;}

    public EnemyManager manager;

    public LineType Line { get; set; }

    float lastAttack = 0;

	// Use this for initialization
	void Start () {
        HitPoint = HitPointMax;
        IsDead = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (HitPoint <= 0)
        {
            IsDead = true;
        }
        else
        {
            // 攻撃ウェイト
            
            if (!IsDead && Time.time - lastAttack > WaitSecForAttack)
            {
                Debug.Log("Attack!!!");
                Attack();
            }
        }
	}
    
    public void Damage(int point){
        HitPoint -= point;

        if (HitPoint <= 0)
        {
            IsDead = true;

            // 取り敢えず直ぐ壊す。
            GameObject.Destroy(this);
            manager.OnEnemyDead(Line);
        }
    }

    public void Attack(){
        //timer.Seconds -= AttackSeconds;
        lastAttack = Time.time;
    }
}
