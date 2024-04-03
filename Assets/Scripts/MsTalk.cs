using System;
using System.Collections;
using UnityEngine;
using SpeechLib;
using UniRx;
using UnityEngine.UI;

public class MSTalk : MonoBehaviour
{
	SpVoice voice;
	public Button promptButton;
	public Slider rateSlider; 

	void Start()
	{
		InitializeSpVoice(); // Initialize SpVoice instance

		// Subscribe to button clicks
		promptButton.OnClickAsObservable()
			.Do(_ => Debug.Log("Button clicked, starting speech synthesis..."))
			.Subscribe(_ => Speak("The Microsoft Speech API is working!", GetSpeechFlags()))
			.AddTo(this); // AddTo ensures proper disposal

		// Subscribe to rate slider value changes
		rateSlider.onValueChanged.AddListener(OnRateChanged);

		// Fetch and log data asynchronously when button is clicked
		promptButton.OnClickAsObservable()
			.SelectMany(_ => FetchDataAsync())
			.Subscribe(data => Debug.Log("Fetched data: " + data));
	}

	void OnDestroy()
	{
		// Unsubscribe from rate slider value changes
		rateSlider.onValueChanged.RemoveListener(OnRateChanged);
	}

	void InitializeSpVoice()
	{
		// Initialize SpVoice instance
		voice = new SpVoice();
		SetDefaultRate(); // Set default rate
	}

	void Speak(string message, SpeechVoiceSpeakFlags flags)
	{
		// Speak the message using the SpVoice instance
		voice.Speak(message, flags);
	}

	void OnRateChanged(float pitchValue)
	{
		// Adjust rate based on slider value
		float minPitch = -8.0f; // Minimum rate value
		float maxPitch = 8.0f; // Maximum rate value

		// Map slider value to rate range
		float rate = Mathf.Lerp(minPitch, maxPitch, pitchValue);

		// Set the rate
		voice.Rate = Convert.ToInt32(rate); // Rate property controls the rate (1 = normal rate)

		Debug.Log("Pitch changed to: " + rate);
	}

	void SetDefaultRate()
	{
		// Set default rate value
		rateSlider.value = 0.5f; // Default rate value (normal rate)
	}

	SpeechVoiceSpeakFlags GetSpeechFlags()
	{
		// Get Speech flags
		return SpeechVoiceSpeakFlags.SVSFlagsAsync;
	}

	IObservable<string> FetchDataAsync()
	{
		return Observable.FromCoroutine<string>(observer => FetchDataCoroutine(observer));
	}

	// Coroutine to simulate fetching data with a delay
	IEnumerator FetchDataCoroutine(IObserver<string> observer)
	{
		// Simulate network delay (3 seconds)
		yield return new WaitForSeconds(3f);

		// Dummy data
		string data = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";

		// Emit the fetched data
		observer.OnNext(data);
		observer.OnCompleted();
	}
}
