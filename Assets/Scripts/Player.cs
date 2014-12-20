using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private float previousVerticalPosition;

	InputManager input = new InputManager();
	private bool movingUp = false;
	private bool movingDown = false;
	
	/*
	private Emitter shot;
    private GameObject moveArea;
	*/

	// Use this for initialization
	new void Start() {
		/*
		base.Start();
        shot = GetComponent<Emitter>();
		moveArea = GameObject.Find("MoveArea");
		*/
	}

	
	// Update is called once per frame
	new void Update() {
		if (input.Up () && !atTop() && !(movingUp || movingDown)) {
			previousVerticalPosition = transform.localPosition.y;
			movingUp = true;
		}
		if (input.Down() && !atBottom() && !(movingUp || movingDown)) {
			previousVerticalPosition = transform.localPosition.y;
			movingDown = true;
		}

		if (movingUp) {
			if (transform.localPosition.y - previousVerticalPosition >= Const.Character.MovablePosition.Vertical.STEP) {
				movingUp = false;
			} else {
				transform.Translate(0, 0.1f, 0);
			}
		}
		if (movingDown) {
			if (
				previousVerticalPosition - transform.localPosition.y >= Const.Character.MovablePosition.Vertical.STEP) {
				movingDown = false;
			} else {
				transform.Translate(0, -0.1f, 0);
			}
		}
		/*
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
		
		*/
		//base.Update();
	}
	
	private bool atTop()
	{
		return transform.localPosition.y >= Const.Character.MovablePosition.Vertical.MAX;
	}

	private bool atBottom()
	{
		return transform.localPosition.y <= Const.Character.MovablePosition.Vertical.MIN;
	}
	
	/*
	private void OnMoveUp()
	{
		other.renderer.material.color = Color.green;
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
    */
}
