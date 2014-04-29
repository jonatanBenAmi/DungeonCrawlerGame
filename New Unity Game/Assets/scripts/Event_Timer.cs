using UnityEngine;
using System.Collections;

public class Event_Timer 
{

	private float timeToNextTick;
	private float timeTicking;
	protected bool timerIsOn;

	public Event_Timer(float newTime, bool isOn)
	{
		timeToNextTick = newTime;
		timeTicking = 0.0f;
		timerIsOn = isOn;

	}
	public bool eventTimer ()
	{
		if(timerIsOn)
		{
			timeTicking++;
			if(timeTicking == timeToNextTick)
			{
				timeTicking = 0;
				return true;
			}
			else 
			{
				return false;
			}
		}else{
			return false;
		}
	}

	public float TimeToNextTick
	{
		set {timeToNextTick = value;}
	}
	public float TimeTicking
	{
		get {return timeTicking;}
		set {timeTicking = value;}
	}
	public bool TimerIsOn
	{
		set {timerIsOn = value;}
	}
}
