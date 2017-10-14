using UnityEngine;
using System.Collections;

public class AudioControls : MonoBehaviour {

	// Use this for initialization
	private AudioSource source;
	private int maxFreq = 44100;
	private int timeLength = 5;
	//MAY BE AN ISSUE FOR OTHER COMPUTERS!!!
	private string mic;
	public float refreshTime = 1f;
	private float timeElapsedSinceUpdate = 0f;
	void Start () {
		mic = Microphone.devices[0];//I'm assuming it will be this one
		source = GetComponent<AudioSource> ();
		/*for (int i = 0; i < Microphone.devices.Length; i++) {
			Debug.Log (Microphone.devices [i]);
		}*/
		source.clip = Microphone.Start (mic, true, timeLength, maxFreq); 
		//GetComponent<AudioSource>().loop = true;
		//audio.mute = true;
		while(!(Microphone.GetPosition(mic) > 0)){}//Busy wait
		source.Play();
	}
	
	// Update is called once per frame
	void Update () {
		timeElapsedSinceUpdate += Time.deltaTime;
		if (timeElapsedSinceUpdate >= refreshTime) {
			StopMic ();
			Debug.Log ("Processing Audio Segment");
			//TODO: process the Recorded Data
			StartMic ();
			timeElapsedSinceUpdate = 0f;
		}
		/*if (Microphone.IsRecording (mic)) {

			} else {
				Debug.Log ("Mic is Off");
			}*/
	}

	void StopMic(){
		source.Stop ();
		Microphone.End (mic);
	}

	void StartMic(){
		source.clip = Microphone.Start (mic, true, timeLength, maxFreq);
		while(!(Microphone.GetPosition(mic) > 0)){}//Busy wait
		source.Play(); 
	}
}
