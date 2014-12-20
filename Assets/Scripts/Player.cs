using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	InputManager input = new InputManager();
	private float previousVerticalPosition;
	private float movingSpeed = 0.2f;
	private bool movingUp = false;
	private bool movingDown = false;
	
    public GameTimer timer;

	/*
    private GameObject moveArea;
	*/
	private Emitter shot;

	// Use this for initialization
	new void Start() {
		/*
		base.Start();
		moveArea = GameObject.Find("MoveArea");
		*/
		shot = GetComponent<Emitter>();
	}

	
	// Update is called once per frame
	new void Update() {
		if (input.Up () && !atTop() && !isMoving()) {
			previousVerticalPosition = transform.localPosition.y;
			movingUp = true;
		}
		if (input.Down() && !atBottom() && !isMoving()) {
			previousVerticalPosition = transform.localPosition.y;
			movingDown = true;
		}

		if (movingUp) {
			if (transform.localPosition.y - previousVerticalPosition >= Const.Character.MovablePosition.Vertical.STEP) {
				movingUp = false;
			} else {
				transform.Translate(0, movingSpeed, 0);
			}
		}
		if (movingDown) {
			if (
				previousVerticalPosition - transform.localPosition.y >= Const.Character.MovablePosition.Vertical.STEP) {
				movingDown = false;
			} else {
				transform.Translate(0, -movingSpeed, 0);
			}
		}
		
		if(input.Shot()){
			shot.Emit();
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
		*/
	}
	
	private bool isMoving()
	{
		return movingUp || movingDown;
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
