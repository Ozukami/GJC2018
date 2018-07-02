﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return))
			SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1)
			                       % SceneManager.sceneCountInBuildSettings);
	}
}
