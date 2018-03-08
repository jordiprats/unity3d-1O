using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClockController : MonoBehaviour {

	protected float gameTime=0;
	protected int hora;
	protected int minut;
	public TextMeshProUGUI display_hora;
	// Use this for initialization
	void Start()
	{
		gameTime=0;
		hora=4;
		minut=33;
		display_hora = GetComponent<TextMeshProUGUI>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		gameTime+=Time.deltaTime;
		if(gameTime>10f)
		{
			minut++;
			gameTime=0;
		}
		if(minut>=60)
		{
			minut=0;
			hora++;
		}
		if(hora>=24)
		{
			hora=0;
			minut=0;
		}
		if(hora>10)
			if(minut>=10)
				display_hora.SetText("{0}:{1}",hora,minut);
			else
				display_hora.SetText("{0}:0{1}",hora,minut);
		else
			if(minut>=10)
				display_hora.SetText("0{0}:{1}",hora,minut);
			else
				display_hora.SetText("0{0}:0{1}",hora,minut);
	}
}
