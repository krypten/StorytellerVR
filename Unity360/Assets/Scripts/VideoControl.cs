using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class VideoControl : MonoBehaviour {

	private AudioSource audioSource;
	private VideoPlayer videoPlayer;

	void Start() {
		videoPlayer = GetComponent<VideoPlayer> ();
		AudioSource audioSource = GetComponent<AudioSource>();

		//Set Audio Output to AudioSource
		videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
		//Assign the Audio from Video to AudioSource to be played
		videoPlayer.EnableAudioTrack(0, true);
		videoPlayer.SetTargetAudioSource(0, audioSource);
	}

	public void PlayPause() {
		if (videoPlayer.isPlaying) {
			videoPlayer.Pause();
		} else {
			videoPlayer.Play();
		}
	}

	public void Pause() {
		if (videoPlayer.isPlaying) {
			videoPlayer.Pause();
		}
	}
	
	public void Restart() {
		videoPlayer.Pause();
		videoPlayer.Stop();
		videoPlayer.time = 0;
		videoPlayer.Prepare();
		videoPlayer.Play();
	}

	public void Play() {
		Application.runInBackground = true;
		StartCoroutine(PlayVideo());
	}

	IEnumerator PlayVideo() {
		// Set video To Play then prepare Audio to prevent Buffering
		videoPlayer.Prepare();
		
		// Wait until Movie is prepared
		WaitForSeconds waitTime = new WaitForSeconds(1);
		while (!videoPlayer.isPrepared) {
			Debug.Log("Preparing Movie");
			yield return waitTime;
			break;
		}
		// Play Movie 
		videoPlayer.Play();	
	}
}
