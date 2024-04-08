# TtsUnityUniRx

# Editor Version Unity 2022.3.21f1

1. **Initialization**: The script initializes UniRx and sets up the necessary variables for handling reactive operations.

2. **Button Click Handling (UniRx)**: When the button is clicked, UniRx's `OnClickAsObservable` function is used to create an observable stream of button click events. This stream is then subscribed to using the `Subscribe` method. Inside the subscription, the `Speak` function is called to trigger text-to-speech synthesis. UniRx allows for a reactive approach to handling user interactions, decoupling the event handling logic from the UI.

3. **Slider Value Change Handling (UniRx)**: Similarly, UniRx's `OnValueChanged` function is used to create an observable stream of slider value changes. This stream is subscribed to, and the `OnRateChanged` function is called to adjust the pitch of the speech synthesis accordingly. UniRx enables reactive handling of UI element changes, making it easy to react to user input in real-time.

4. **Asynchronous Data Fetching (UniRx)**: Additionally, UniRx is used to handle asynchronous data fetching. When the button is clicked, UniRx's `SelectMany` function is used to chain the button click event stream with the asynchronous data fetching operation. This allows for a reactive approach to handling asynchronous tasks, ensuring that the UI remains responsive during data fetching.

Overall, the script leverages UniRx's reactive programming capabilities to handle user interactions, UI element changes, and asynchronous tasks in a clean and composable manner. This enables a more reactive and responsive user experience in the application.
