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
		source.mute = true;
		while(!(Microphone.GetPosition(mic) > 0)){}//Busy wait
		source.Play();
	}
	
	// Update is called once per frame
	void Update () {
		timeElapsedSinceUpdate += Time.deltaTime;
		if (timeElapsedSinceUpdate >= refreshTime) {
			StopMic ();
			ProcessMicData();
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

	void ProcessMicData(){
		int numberOfBins = 1024;
		float[] spectrum = new float[numberOfBins];
		AudioListener.GetSpectrumData(spectrum, 1, FFTWindow.Hamming);
		int maxFreq = 1; //Nyquist freq is a thing
		for (int i = 1; i < spectrum.Length - 1; i++)
		{
			if (spectrum [i] > spectrum [maxFreq]) {
				maxFreq = i;
			}
			Debug.DrawLine(new Vector3(i - 1, spectrum[i] + 10, 0), new Vector3(i, spectrum[i + 1] + 10, 0), Color.red, Time.deltaTime, false);
			Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan);
			Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);
			//Cyan seems to be what to use
			Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.blue);
		}
		Debug.Log (maxFreq);
	}
}
