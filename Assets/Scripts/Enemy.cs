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

    public int Score;

    public float WaitSecForAttack;

    public GameTimer timer;

    public int HitPoint { get; private set; }

    public bool IsDead {get; private set;}

    public EnemyManager manager;

    public Emitter emitter;

    public LineType Line { get; set; }

    float birthTime;

    void Awake()
    {
        birthTime = Time.time;
    }

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
            /*
            if (!emitter.Activation && Time.time - birthTime > WaitSecForAttack)
            {
                emitter.Activate();
            }
             * */
        }
	}
    
    public void Damage(int point){
        HitPoint -= point;

        if (HitPoint <= 0)
        {
            IsDead = true;

            // 取り敢えず直ぐ壊す。
            manager.OnEnemyDead(Line);
        }
    }
}
