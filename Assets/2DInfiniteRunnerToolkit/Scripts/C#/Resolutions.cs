using UnityEngine;
using System.Collections;

public class Resolutions : MonoBehaviour {
	public float height;
	static float PerPixel;
	static float Unit;

	void Awake(){
		PerPixel = Screen.width/(Screen.height/height);
	}
	
	public static float GetWidth() {
		return  PerPixel;
	}
	

}
