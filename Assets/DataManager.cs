using UnityEngine;
using System.Collections;

public class DataManager : MonoBehaviour {
	public static DataManager Instance;

	// Use this for initialization
	void Awake () {
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetHighScore(int Score) {
		PlayerPrefs.SetInt ("HighScore",Score);
	}

	public int GetHighScore() {
		return PlayerPrefs.GetInt ("HighScore",0);
	}

	public void SetTotalCoins(int Coins) {
		PlayerPrefs.SetInt ("HighScore",GetTotalCoins() + Coins);
	}

	public int GetTotalCoins() {
		return PlayerPrefs.GetInt ("TotalCoins",0);
	}
}
