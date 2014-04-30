using UnityEngine;
using System.Collections;

public class Event_Timer 
{

	private float timeToNextTick; //variable used to store how long time it should add 1, before stopping
	private float timeTicking; //the time counter variable
	protected bool timerIsOn; //used to evaluate is the timer is on, depending on true or false

	public Event_Timer(float newTime, bool isOn) //starting a new time
	{
		timeToNextTick = newTime; //the new time is set by this value
		timeTicking = 0.0f; //initial value
		timerIsOn = isOn;  //and the time is on

	}
	public bool eventTimer ()
	{
		if(timerIsOn) //if the time in on = true
		{
			timeTicking++; // add 1 to the timeTicking
			if(timeTicking == timeToNextTick) //this is eual
			{
				timeTicking = 0; //stop ticking
				return true;
			}
			else 
			{
				return false; //the time if off!!
			}
		}else{
			return false;
		}
	}

	public float TimeToNextTick  //getting and setting the time
	{
		get {return timeToNextTick;  }
		set {timeToNextTick = value;}
	}
	public float TimeTicking  //as well with the timeTicking
	{
		get {return timeTicking;}
		set {timeTicking = value;}
	}
	public bool TimerIsOn
	{
		set {timerIsOn = value;}
	}
}
