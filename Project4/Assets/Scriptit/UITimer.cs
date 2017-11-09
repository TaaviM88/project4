using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UITimer : MonoBehaviour {
	private Text _text;
	// Use this for initialization
	void Awake () {
		_text = GetComponentInChildren<Text>(true);
	}

	// Update is called once per frame
	void Update () {
		float time = GameManager.Current.GetCurrentTime();
		int minutes = (int)time / 60;
		int seconds = (int)time % 60;
		_text.text = minutes.ToString("D2") + ":" + seconds.ToString("D2");
	}
}