using UnityEngine;
using System.Collections;

public class Bullet : Particle {
	
	public int Iff;

    public float LifePoint;
    public float AtackPoint;
    public float DeffencePoint;

    public float DamageTo(Bullet other)
    {
        return Mathf.Max(this.AtackPoint - other.DeffencePoint, 0);
    }

	// Use this for initialization
	public virtual new void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	public virtual new void Update () {
        if (!this.IsDead)
        {
            base.Update();
        }
        else
        {
            Destroy(this.gameObject, 0);
        }
	}

    public bool IsDead
    {
        get { return LifePoint <= 0; }
    }

    private void OnTriggerEnter(Collider collider)
    {
        Bullet other = collider.GetComponent<Bullet>();
        if (other != null && other.Iff != this.Iff)
        {
            float damage = other.DamageTo(this);
            this.LifePoint = Mathf.Max(this.LifePoint - damage, 0);
        }
        Debug.Log(this.gameObject.name + " : HP : " + this.LifePoint);
    }
}
