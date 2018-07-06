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

	// Check if input keys have been pressed and call methods accordingly.
	void Update() {
		// Play or pause the video.
		if (Input.GetKeyDown("space")) {
			PlayPause();
		}
	}

	public void PlayPause() {
		if (videoPlayer.isPlaying) {
			videoPlayer.Pause();
		} else {
			videoPlayer.Play();
		}
	}

	void Play() {
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
