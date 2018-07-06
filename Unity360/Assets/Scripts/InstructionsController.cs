using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsController : MonoBehaviour {

	public GameObject media;
	public GameObject welcomePanel, instructionsPanel;
	public GameObject backButton;

	public void Next() {
		// Disable the welcome panel
		welcomePanel.SetActive(false);
		// Enable instructions panel
		instructionsPanel.SetActive(true);
	}
	
	public void StartVideo() {
		// Play the video
		VideoControl videoController = (VideoControl) media.GetComponent(typeof(VideoControl));
		videoController.PlayPause();
		// Disable panel
		instructionsPanel.SetActive(false);
		// Enable the back button
		backButton.SetActive(true);
	}

	public void Back() {
		// Pause the video
		VideoControl videoController = (VideoControl) media.GetComponent(typeof(VideoControl));
		videoController.PlayPause();
		// Enable the welcome panel
		welcomePanel.SetActive(true);
		// Disable instructions panel and back button
		instructionsPanel.SetActive(false);
		backButton.SetActive(false);
	}

	public void Exit() {
		Application.Quit();
	}
}
