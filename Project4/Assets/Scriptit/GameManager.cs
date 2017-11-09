using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
	private static GameManager _current;
	public static GameManager Current
	{
		get { return _current; }
	}
	public float Maxtime = 60;
	//public int TargetScore = 100;
	private float _currentTime = 0;
	private bool _isRunning = false;
	// Use this for initialization
	private void Awake  () 
	{
		_current = this;	
	}
	void Start()
	{
		_currentTime = Maxtime;
		_isRunning = true;
	}   

	// Update is called once per frame
	void Update () 
	{
		if (_isRunning == false)
		{
			return;
		}
		_isRunning = UpdateTimer() == true;
		if (_isRunning == false)
		{
			GameOver();
		}
	}

	private void GameOver()
	{
		SceneManager.LoadScene("Player2Wins");
	}

	private bool UpdateTimer()
	{
		_currentTime -= Time.deltaTime;
		if (_currentTime <= 0)
		{
			return false;
		}
		return true;
	}

	public float GetCurrentTime()
	{
		return _currentTime;
	}
	public  void AddTime(int amount)
	{
		_currentTime += amount;
	}
}
