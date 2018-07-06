using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class InstructionsController : MonoBehaviour {

	public GameObject media;
	public GameObject creditPanel, instructionsPanel, welcomePanel;
	public GameObject backButton, creditButton, goCloseButton;
	public GameObject snow, river;

	public void Next() {
		// Disable the welcome panel
		welcomePanel.SetActive(false);
		// Enable instructions panel
		instructionsPanel.SetActive(true);
	}
	
	public void StartVideo() {
		// Play the video
		VideoControl videoController = (VideoControl) media.GetComponent(typeof(VideoControl));
		videoController.Play();
		river.GetComponent<GvrAudioSource> ().Play();
		// Disable panel
		instructionsPanel.SetActive(false);
		creditButton.SetActive(false);
		snow.SetActive(false);
		// Enable the back button
		backButton.SetActive(true);
		goCloseButton.SetActive(true);
	}

	public void Back() {
		// Pause the video
		VideoControl videoController = (VideoControl) media.GetComponent(typeof(VideoControl));
		videoController.PlayPause();
		river.GetComponent<GvrAudioSource> ().Pause();
		// Enable the welcome panel
		welcomePanel.SetActive(true);
		creditButton.SetActive(true);
		snow.SetActive(true);
		// Disable instructions panel and back button
		instructionsPanel.SetActive(false);
		backButton.SetActive(false);
		goCloseButton.SetActive(false);
	}

	public void StartTajMahalCloseVideo() {
		VideoPlayer videoPlayer = media.GetComponent<VideoPlayer> ();
		videoPlayer.source = VideoSource.Url;
		videoPlayer.url = "https://bitbucket.org/chaitanya_agrawal/story_teller_videos/raw/a871168c23f33f08a75bc320986a6679ab4f0365/Exports/Taj_Mahal_Close.mp4";
		videoPlayer.Prepare();
		videoPlayer.Play();
		// Disable go close button
		goCloseButton.SetActive(false);
	}

	public void DisplayCredits() {
		creditPanel.SetActive(true);
		creditButton.SetActive(false);
	}
	
	public void StopCredits() {
		creditPanel.SetActive(false);
		creditButton.SetActive(true);
	}

	public void Exit() {
		Application.Quit();
	}
}
