using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {
	private bool clickedFlg = false;

	public void onClick() {
		Debug.Log ("Start button clicked");
		if (!clickedFlg) {
			clickedFlg = true;
		}
	}

	public void swapScreenZIndex() {
		// FIXME implement
	}
}
