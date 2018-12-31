//----------------------------------------------
//            TSSM: TimeSaver SoundManager
// 		   Created by: Murillo Pugliesi Lopes
//----------------------------------------------

using UnityEngine;
using System.Collections;

/// <summary>
/// Used to hold all Sound information, such as name, clip and all stuff. Also has a isMuted variable to check if the sound is muted or not.
/// </summary>

[System.Serializable]
public enum soundTrack {
	BackgroundSound = 0,
	EffectSound = 1,
	VoiceSound =2
}
public enum track{
	BackgroundSound = 0,
	EffectSound = 1,
	VoiceSound = 2,
	All = 3
}
public enum soundEventType{
	OnStart = 0,
	OnEnd = 1
}

[System.Serializable]
public class Sound : ScriptableObject{
	
	[SerializeField]
	public AudioClip clip;
	[SerializeField]
	public new string name;
	[SerializeField]
	public soundTrack track;
	[SerializeField]
	public bool loop;
	[SerializeField]
	public bool fadeIn;
	[SerializeField]
	public float timeToFadeIn;
	[SerializeField]
	public float controllerFadeIn;
	[SerializeField]
	public bool fadeOut;
	[SerializeField]
	public float timeToFadeOut;
	[SerializeField]
	public bool _3D;
	[SerializeField]
	public Vector3 v3Target;
	[SerializeField]
	public GameObject tTarget;
	[SerializeField]
	public bool followObject;
	[SerializeField]
	public bool trigger;
	[SerializeField]
	public bool stream;
	[SerializeField]
	public GameObject targetForTrigger;
	[SerializeField]
	public string functionForTrigger;
	[SerializeField]
	public float timeToTrigger;
	[SerializeField]
	public float timeInEditor;
	[SerializeField]
	public bool isP;
	[SerializeField]
	public string language;
	[SerializeField]
	public string[] allLenguages;
	[SerializeField]
	public int languageIndexHolder;
	[SerializeField]
	public string URL;
	[SerializeField]
	public string nameInResourceFolder;
	[SerializeField]
	public bool isStreamSound;
	[SerializeField]
	public bool isResourceSound;
	[SerializeField]
	public AudioSource currentSource;

	public bool isPreviwing, pauseEffect, showCarac, canShootEvent;
    public float stopAt, controllerFadeOut, fadeOutTimer, delayToPlay;

    public void Stop(){
		if(this.currentSource)
			this.currentSource.Stop();	
	}

	public void Pause(bool value){
		this.currentSource.Pause();
	}

	public Sound SetEventTrigger(soundEventType type, string func, GameObject target){
		float time = 0;

		switch(type){
		case soundEventType.OnEnd:
			time = clip.length;
			break;
		case soundEventType.OnStart:
			time = 0;
			break;
		}
		SetEventTriggerCustom(func, target, time);
		return this;
	}
	public Sound SetEventTriggerCustom(string func, GameObject target, float secondsToTriggerEvent){
		canShootEvent = true;
		timeToTrigger = secondsToTriggerEvent;
		targetForTrigger = target;
		functionForTrigger = func;
		return this;
	}
}
