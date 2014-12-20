using UnityEngine;
using System.Collections;

public class InputManager {
	
	public bool Up(){
		return Input.GetKey(KeyCode.UpArrow);
	}
	
	public bool Down(){
		return Input.GetKey(KeyCode.DownArrow);
	}
	
	public bool Left(){
		return Input.GetKey(KeyCode.LeftArrow);
	}
	
	public bool Right(){
		return Input.GetKey(KeyCode.RightArrow);
	}
	
	public bool Shot(){
		return Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Space);
	}
}
