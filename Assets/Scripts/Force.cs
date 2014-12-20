using UnityEngine;
using System.Collections;

public class Force : MonoBehaviour {
	
	/// <summary>
	/// このフォースの名前
	/// </summary>
	public string Name;
	
	/// <summary>
	/// このフォースが有効であるかどうか
	/// </summary>
	public bool Activation = false;
	
	/// <summary>
	/// 力の向き
	/// </summary>
	public float Direction;
	
	/// <summary>
	/// 力の大きさ
	/// </summary>
	public float Value;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Activate(){
		Activation = true;
	}
	
	public void Deactivate(){
		Activation = false;
	}
}
