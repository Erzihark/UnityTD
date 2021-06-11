using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LUI_ButtonSound : MonoBehaviour {

	public AudioClip sound;
	private Button button { get { return GetComponent<Button>(); } }

	public Button optionalButton;
	public Button optionalButton2;

	public float audioPitch;
	private AudioSource source { get { return GetComponent<AudioSource>(); } }

	void Start () {
		gameObject.AddComponent<AudioSource>();
		source.clip = sound;
		source.playOnAwake = false;
		source.volume = 0.3f;

		if (audioPitch == 0)
		{
			audioPitch = 1;
		}

		if (!optionalButton && !optionalButton2)
		{
			button.onClick.AddListener(() => PlaySound());
		}


		if (optionalButton != null)
		{
			optionalButton.GetComponent<Button>();
			optionalButton.onClick.AddListener(() => PlaySound());
		}

		if (optionalButton2 != null)
		{
			optionalButton2.GetComponent<Button>();			
			optionalButton2.onClick.AddListener(() => PlaySound2());

		}
	}
	
	void PlaySound () {
		source.pitch = audioPitch;
		source.PlayOneShot(sound);
	}

	void PlaySound2()
	{
		source.pitch = 1.1f;
		source.PlayOneShot(sound);

	}
}
