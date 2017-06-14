using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class dayLight : MonoBehaviour {
	public int speed;
	public int days;
	public float time;
	public float intensity;
	public TimeSpan currenttime;
	public Text timetext;
	public Light sun;
	public Transform sunTransform;
	public Color fogDay = Color.gray;
	public Color fogNight = Color.black;

	void Update () {
		ChangeTime ();
	}

	public void ChangeTime(){
		time += Time.deltaTime * speed;
		if (time > 86400) {
			days++;
			time = 0;
		}
		currenttime = TimeSpan.FromSeconds (time);
		string[] temptime = currenttime.ToString ().Split (":" [0]);
		timetext.text = temptime [0] + ":" + temptime [1];

		//transform.RotateAround (Vector3.zero, Vector3.right, (time - 21600) / 86400 * 360);
		sunTransform.rotation = Quaternion.Euler (new Vector3 ((time - 21600) / 86400 * 360, 0, 0));
		if (time < 43200)
			intensity = 1 - (43200 - time) / 43200;
		else
			intensity = 1 - ((43200 - time) / 43200 * -1);

		RenderSettings.fogColor = Color.Lerp (fogNight, fogDay, intensity * intensity);
		sun.intensity = intensity;
	}
}
