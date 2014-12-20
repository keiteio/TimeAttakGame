using UnityEngine;
using System.Collections;

public class Player : Bullet {
	static string FORCE_UP = "UP";
	static string FORCE_DOWN = "DOWN";
	static string FORCE_LEFT = "LEFT";
	static string FORCE_RIGHT = "RIGHT";
	
	InputManager input = new InputManager();
	
	private Emitter shot;

    private GameObject moveArea;

	// Use this for initialization
	new void Start () {
		base.Start();
		
		shot = GetComponent<Emitter>();
        moveArea = GameObject.Find("MoveArea");
	}
	
	// Update is called once per frame
	new void Update (){
		
		this.DeactivateAllForce();

        if (input.Up() && this.Y <= moveAreaTop())
        {
			ForceMap[FORCE_UP].Activate();
        }
        else if (input.Down() && this.Y >= moveAreaBottom())
        {
			ForceMap[FORCE_DOWN].Activate();
		}

        if (input.Left() && this.X >= moveAreaLeft())
        {
			ForceMap[FORCE_LEFT].Activate();
        }
        else if (input.Right() && this.X <= moveAreaRight())
        {
			ForceMap[FORCE_RIGHT].Activate();
		}
		
		if(input.Shot()){
			shot.Emit();
		}
		
		base.Update();
	}

    private void OnTriggerEnter(Collider other)
    {
        other.renderer.material.color = Color.green;
    }

    private void OnTriggerExit(Collider other)
    {
        other.renderer.material.color = Color.grey;
    }

    float moveAreaLeft()
    {
        return -moveArea.transform.localScale.x / 2;
    }

    float moveAreaRight()
    {
        return moveArea.transform.localScale.x / 2;
    }

    float moveAreaTop()
    {
        return moveArea.transform.localScale.y / 2;
    }

    float moveAreaBottom()
    {
        return -moveArea.transform.localScale.y / 2;
    }
}
