using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootingSound : MonoBehaviour {
	float volumeController;
	void Start () {
		volumeController = 1.0f;
	}
	
	void OnGUI(){
		
		GUILayout.BeginArea (new Rect(0, Screen.height*0.1f , Screen.width, Screen.height));
		
		GUILayout.Box ("Wellcome to the TimeSaver SoundManager! \n\n Here you will find an example of some features that the project has, like: " +
			"\n -Play a sound" +
			"\n -Mute/Unmute a single SoundTrack" +
			"\n -Change the volume of all tracks or a single one" +
			"\n -Play random sounds, using the same sound name" +
			"\n -Swap SoundManager language in run-time to use the same sound name for multiple sounds but diferent languages");
		GUILayout.EndArea();
		GUILayout.BeginArea (new Rect((Screen.width/2)-250, (Screen.height/2) , 500, 300));
		if(GUILayout.Button("Mute/Unmute Background Sound Track")){
			
			SoundManager.Mute(!SoundManager.bkgMuted, track.BackgroundSound);
			//IF YOU WOULD LIKE TO STOP A SINGLE SOUND, DO LIKE THIS
			//SoundManager.Mute(!SoundManager.GetSoundPlaying("background")[0].isMuted,"background");		
		}
		
		if(GUILayout.Button("- Volume (all tracks)")){
			
			volumeController -= 0.1f;
			if(volumeController < 0) volumeController = 0;
			SoundManager.Volume(volumeController,track.All);	
		}
		if(GUILayout.Button("+ Volume (all tracks)")){
			
			volumeController += 0.1f;
			if(volumeController > 1) volumeController = 1;
			SoundManager.Volume(volumeController,track.All);	
		}
	   
		if(GUILayout.Button("Press here to play a 'Erro' Sound, it will choose at random and play!")){
			SoundManager.Play("Erro");	
		}
		if(GUILayout.Button("Change Language, current language: "+SoundManager.language+"\n and play the 'banana' sound.\n Each banana sound has a different language, but same name. Check in inspector!",  GUILayout.Height(75))){
			
			SoundManager.language = (SoundManager.language == "Portuguese") ? "English" : "Portuguese";
			SoundManager.Play("banana");
		}
		 GUILayout.EndArea();
		
		
	}
}
