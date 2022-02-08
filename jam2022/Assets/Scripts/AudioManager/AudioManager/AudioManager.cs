using UnityEngine.Audio;
using System;
using UnityEngine;

using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{

	public static AudioManager instance;

	public AudioMixerGroup mixerGroup;


	public bool cambiar;

	Scene currentScene; 
	public Sound[] sounds;
	void Start() 
	{
		currentScene = SceneManager.GetActiveScene();
		Debug.Log(currentScene.name);
		if (currentScene.name == "MenuInicio")
		{
			Play("Menu");
		}
		
	}
	void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;

			s.source.outputAudioMixerGroup = mixerGroup;
		}
	}

	public void Play(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = s.volume; //* (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch;//* (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

		s.source.Play();

		Debug.Log("Musica " + sound + " iniciada");
	}

	public void StopPlaying(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

		s.source.Stop();

		//Debug.Log("Musica " + sound + " parada");
	}
	private void Update()
	{
		if (cambiar)
		{
			currentScene = SceneManager.GetActiveScene();
			Debug.Log(cambiar);
			Debug.Log(currentScene.name);
			cambiar = false;
			if (currentScene.name == "tuto1")
			{
				StopPlaying("Menu");
				Play("Tutorial");
			}
			else if (currentScene.name == "lvl3")
			{
				StopPlaying("Tutorial");
				Play("Facil");
			}
			else if (currentScene.name == "nivelJordan")
			{
				StopPlaying("Facil");
				Play("Dificil");
			}
			else if (currentScene.name == "Ending")
			{
				StopPlaying("Dificil");
				Play("Final");
			}
		}
	}
}
