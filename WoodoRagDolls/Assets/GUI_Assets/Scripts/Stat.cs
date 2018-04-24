﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Stat  {

	[SerializeField]
	private BarScript bar;

	[SerializeField]
	private float maxVal;

	[SerializeField]
	private float currentVal;



	public float MaxVal{

		get { 

			return maxVal;
		}

		set { 			
			this.maxVal = value;
			bar.MaxValue = maxVal;
		}
	}



	public float CurrentVal{

		get { 
		
			return currentVal;
		}

		set { 
			
			this.currentVal = Mathf.Clamp(value, 0, MaxVal);  // gör så den inte går under 0 eller över max värdet
			bar.Value = currentVal;
		
		}
	}

	public void Initialize(){
	
		this.MaxVal = maxVal;
		this.CurrentVal = currentVal;
	
	}

}
