﻿using System;
using UnityEngine;

public class _Rotate : RobotBehaviourScript {

	[ShowInRobot]
	public Vector3 Step = new Vector3(.5f,.5f,.5f);

	[ShowInRobot]
	public Vector3 Total = new Vector3(0,0,30f);

	public Vector3 Current = new Vector3(0,0,0);
	
	void Update () {
		if (Enabled)
		{
			transform.eulerAngles = transform.eulerAngles + Step * Time.deltaTime;


			//todo : make sure this works for all directions
			Current += Step * Time.deltaTime;
			if (Current.x >= Total.x && Current.y >=Total.y && Current.z >=Total.z)
			{
				Current = new Vector3();
				Done();
			}
		}
	}
	
	public override void Copy<T>(ref T copyO)
	{
		base.Copy(ref copyO);
		
		var copy = copyO as _Rotate;
		if (copy != null)
		{
			copy.Step = Step;			
			copy.Enabled = Enabled;
		}
		else
		{
			throw new NotImplementedException("Somthing went horribly wrong");
		}
	}
}
