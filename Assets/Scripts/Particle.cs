using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Particle : EventTrigger {
	
	Force[] forces = null;
	protected Dictionary<string, Force> ForceMap;
	
	public float Lifespan;
	
	// Use this for initialization
	public virtual void Start () {
		forces = this.GetComponents<Force>();
		if(forces.Length > 0){
			ForceMap = new Dictionary<string, Force>();
			foreach(Force f in forces){
				ForceMap.Add(f.Name, f);
			}
		}
		if(Lifespan > 0){
			Destroy(this.gameObject, Lifespan);
		}
	}
	
	// Update is called once per frame
	public virtual void Update () {
		Vector3 velocity = new Vector3(0,0,0);
		if(forces != null){
			foreach(Force f in forces){
				if(f.Activation){
					float dir = f.Direction / 360.0f * Mathf.PI * 2;
					float x = f.Value * Mathf.Cos(dir) * Time.deltaTime;
					float y = f.Value * Mathf.Sin(dir) * Time.deltaTime;
					Vector3 v = new Vector3(x,y,0);
					
					velocity += v;
				}
			}
		}
		this.X += velocity.x;
		this.Y += velocity.y;
	}
	
	void SwitchAllForceActivation(bool activation){
		if(forces != null){
			foreach(Force f in forces){
				f.Activation = activation;
			}
		}
	}
	
	public void ActivateAllForce(){
		SwitchAllForceActivation(true);
	}
	
	public void DeactivateAllForce(){
		SwitchAllForceActivation(false);
	}
	
	public float X{
		get{ return this.transform.position.x; }
		set{
			Vector3 pos = this.transform.position;
			pos.x = value;
			this.transform.position = pos;
		}
	}
	
	public float Y{
		get{ return this.transform.position.y; }
		set{
			Vector3 pos = this.transform.position;
			pos.y = value;
			this.transform.position = pos;
		}
	}
	
	public float Z{
		get{ return this.transform.position.z; }
		set{
			Vector3 pos = this.transform.position;
			pos.z = value;
		}
	}
}
