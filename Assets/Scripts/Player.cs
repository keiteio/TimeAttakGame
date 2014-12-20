using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	InputManager input = new InputManager();
	private float previousVerticalPosition;
	private float movingSpeed = 0.2f;
	private bool movingUp = false;
	private bool movingDown = false;
	
    public GameTimer timer;

	private Emitter shot;

	// Use this for initialization
	new void Start() {
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

        if (input.Shot() && !isMoving())
        {
			shot.Emit();
		}
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
	
}
