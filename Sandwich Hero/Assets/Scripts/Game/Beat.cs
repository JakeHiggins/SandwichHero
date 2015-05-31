using UnityEngine;
using System.Collections;

public class Beat {

	public AudioClip clip;
	public float startTime;
	public float waitTime;

	public Beat(AudioClip audio, float time) {
		clip = audio;
		startTime = time;
		waitTime = 0;
		Game.Music.PlaySound(clip);
	}
}
