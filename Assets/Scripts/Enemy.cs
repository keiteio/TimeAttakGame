using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public int HitPointMax;

    public int AttackSeconds;

    public int RecoverySeconds;
    
    public int WaitSecForAttack;

    public GameTimer timer;

    public int HitPoint { get; private set; }

    public bool IsDead {get; private set;}

    public EnemyManager manager;

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
            StartCoroutine(Wait(3));

            if (!IsDead)
            {
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
            Wait(1);
            manager.OnEnemyDead();
        }
    }

    public void Attack(){
        timer.Seconds -= AttackSeconds;
    }

    private IEnumerator Wait(int sec)
    {
        yield return new WaitForSeconds(sec);
    }
}
