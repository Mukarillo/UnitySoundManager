# UnitySoundManager
Simple, yet powerful, sound manager for Unity with 3 tracks, language system, pooling system, Fade in/out effects, EventTrigger system and more.

## Setup Project
![setup](https://raw.githubusercontent.com/Mukarillo/UnitySoundManager/master/Images/Screen%20Shot%202018-01-24%20at%2010.14.14%20PM.png)
To create an instance of SoundManager, click `Time Saver Tools>Sound Manager> Add SoundManager`. A GameObject will be created at root with SoundManager component.

# Sound Manager Properties
![properties](https://raw.githubusercontent.com/Mukarillo/UnitySoundManager/master/Images/Screen%20Shot%202018-01-24%20at%2011.36.54%20PM.png)

**Use this forever**: when checked, the GameObject won't be destroyed when changing scenes. Use this feature if you want to have only one instance of SoundManager through out the whole project.

 **Project FPS**: This is used to calculate events and Fade-in/out effects. If you don't know the project fps, leave it at 60.

**Use Pool Feature**: when checked, an array of GameObjects will be created at editor time, avoiding instantiating at run time. If not checked, it will create a GameObject every time `SoundManager.Play` is called.
- **Pool Quantity**: the quantity of game objects to be created. (Sound will only play if there is at least one available GameObject in the pool)

**Use Multi-Language Feature** : Use this if your project aims multi-language target. It will allow you to swap between languages while in run time. When creating the sounds, you can have multiple instances with the same `name` and different language, the Sound Manager will check the current language and use the right one.

## Editing Channel Tracks

![editingchannel](https://raw.githubusercontent.com/Mukarillo/UnitySoundManager/master/Images/Screen%20Shot%202018-01-24%20at%2011.40.02%20PM.png)

The Sound Manager has three channels: *background*, *Effects* and *Voice*. These are just their names and you can use them to whatever kind of sound you want.

**Volume**: You can setup the initial volume for the selected channel.

**Play at start**: This option is only available in the *Background Channel*. It allows you to setup the background music for each scene in your project (the scene must be added to `Build Settings > Scenes In Build`)

## Adding Sound Clips
![dragging](https://github.com/Mukarillo/UnitySoundManager/blob/master/Images/draganddrop.gif?raw=true)

You have two options to add `Sound Clip`, first one would be clicking `Add Sound` and than setting the name, dragging the `Sound Clip` and setting the other parameters. The second choice is to drag one (or more) `Sounds Clip` to the "Drag here" area, their names and clips will be filled. If you put these sounds under folders which have names like: *Background*, *Effects* or *Voice*, the `Track` will be filled automatically for you, do the same thing for `Language`. 

# Sound Configuration Panel

![conf1](https://github.com/Mukarillo/UnitySoundManager/blob/master/Images/Screen%20Shot%202018-01-24%20at%2011.40.20%20PM.png?raw=true)

**1**- Click the arrow to hide/show more options.<br />
**2**- Sound name.<br />
**3**- Click to preview the sound.<br />
**4**- Click to stop previewing the sound.<br />
**5**- The track that the sound belongs.<br />
**6**- Click to delete the sound.<br />

![conf2](https://github.com/Mukarillo/UnitySoundManager/blob/master/Images/confpanel1.jpg?raw=true)

**7**- The audio clip.<br />
**8**- Name (used to refer to this song in the source code).<br />
**9**- Volume.<br />
**10**- Loop toggle.<br />
**11**- Fade in/out effects toggle.<br />
**12**- Time to fade in/out.<br />

![conf3](https://github.com/Mukarillo/UnitySoundManager/blob/master/Images/confpanel2.jpg?raw=true)

**3DSound**: If the sound is not supposed to play 2d, check this toggle. Set the `Vector3` to make the sound play at a coordinate or set the `GameObject` to make the sound follow the object;
**Track**: Set the track this sound belongs. This will be useful to mute/un-mute groups of sounds.
**Language**: Set the language of the sound. If you call `SoundManager.Play` with the name of this sound and the `SoundManager.language` is not the same as set here, the sound will not play.

![conf4](https://github.com/Mukarillo/UnitySoundManager/blob/master/Images/confpanel3.jpg?raw=true)

**Trigger Event**: when checked, will try to call a function called `OnSoundTrigger` in all components attached in the `Target GameObject`. If `Time` is set to `-1`, the event will trigger at the end of the sound, if set to `0`, the event will be triggered at the start of the sound.

# Coding - Functions
 
**`SoundManager.AddSound`**
- *Description*:
Use this method to add sounds at run-time.

- *Parameters*:

|name  |type  |description  |
|--|--|--|
|`clip` |**AudioClip** |*The AudioClip of the sound*  |
|`name` |**String** |*The name of the sound, used to reference it*  |
|`soundTrack` |**Track** |*The track of the sound*  |
|`language` |**String** |*The language of the sound*  |
|`loop` |**Bool** |*If the sound loops or not*  |
|`fadeIn` |**Bool** |*If the sound have fade in*  |
|`timeToFadeIn` |**Float** |*Time for fade in*  |
|`fadeOut` |**Bool** |*If the sound have fade out*  |
|`timeToFadeOut` |**AudioClip** |*Time for fade out*  |
|`is3D` |**Bool** |*If the sound is 3D*  |
|`posFor3D` |**Vector3** |*Position coordinate for the sound*  |
|`isTrigger` |**bool** |*If the sound have event trigger*  |
|`triggerTime` |**float** |*Time to trigger the event (`-1` represents AudioClip.Length)*  |

##  
 **`SoundManager.Play`**

- *Description*:
Use this method to play an audio clip at run-time.

- *Parameters*:

|name  |type  |description  |
|--|--|--|
|`name` |**String** |*This string is a direct reference to the created sound name*  |
|`delay` |**Float** |*Set `0` if you want the sound to be played instantly, or set a delayed time*  |
|`playAt` |**Float** |*Set `0` if you want the sound to be played at its start, or set a time to be played (in seconds)*  |
|`stopAt` |**Float** |*Set `-1` if you want the sound to be stopped at its end, or set a time to be stopped (in seconds)*  |

## 

**`SoundManager.Mute`**

- *Description*:
Use this method to mute an audio clip or track at run-time.

- *Parameters*:

|name  |type  |description  |
|--|--|--|
|`mute` |**Bool** |*Set to `true` if you want to mute and to `false` if you want to un-mute*  |
|`clipName` |**String** |*The name of the audio clip that you want to mute/un-mute*  |

or

|name  |type  |description  |
|--|--|--|
|`mute` |**Bool** |*Set to `true` if you want to mute and to `false` if you want to un-mute*  |
|`compareTrack` |**Track** |*The track that you want to mute/un-mute*  |

## 

**`SoundManager.Stop`**

- *Description*:
Use this method to stop an audio at run-time. Use this method only if you don't want resume the audio clip.

- *Parameters*:

|name  |type  |description  |
|--|--|--|
|`name` |**String** |*The name of the clip that you want to stop*  |

## 

**`SoundManager.StopAllSounds`**

- *Description*:
Use this method to stop all audios at run-time. Use this method only if you don't want resume the audio clip.

- *Parameters*: `no parameters`

## 

**`SoundManager.Volume`**

- *Description*:
Use this method to change the volume of an audio clip or track at run-time.

- *Parameters*:

|name  |type  |description  |
|--|--|--|
|`volume` |**Float** |*The volume to change, `0` means no sound and `1` means full volume*  |
|`clipName` |**String** |*The name of the audio clip that you want to change volume*  |

or

|name  |type  |description  |
|--|--|--|
|`volume` |**Float** |*The volume to change, `0` means no sound and `1` means full volume*   |
|`compareTrack` |**Track** |*The track that you want to change volume*  |

# Coding - Variables

**`SoundManager.allMuted`**: returns true if all tracks are muted.

**`SoundManager.backgroundVolume`**: returns a float between 0 and 1 representing the *background track* volume. You can set the background volume in this variable also.

**`SoundManager.bkgMuted`**: returns true if *background track* is muted.

**`SoundManager.effectsVolume`**: returns a float between 0 and 1 representing the *effects track* volume. You can set the background volume in this variable also.

**`SoundManager.efxMuted`**: returns true if *effects track* is muted.

**`SoundManager.voiceVolume`**: returns a float between 0 and 1 representing the *voice track* volume. You can set the background volume in this variable also.

**`SoundManager.voiceMuted`**: returns true if *voice track* is muted.

**`SoundManager.fps`**: you can check or change the value of the manager fps.

**`SoundManager.language`**: you can check or change the value of the manager language.

# Credits
This asset was created by `Murillo Pugliesi Lopes`. For more information, please contact me at:
mukarillo@gmail.com<br />
Feel free to clone and mess around. If you feel that you want to contribute, please submit a merge request :)
