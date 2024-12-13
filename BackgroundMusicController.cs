using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusicController : MonoBehaviour
{
    [SerializeField] private Toggle musicToggle; // the toggle button
    private AudioSource audioSource;

    private void Start()
    {
        // find the AudioSource on this GameObject
        audioSource = GetComponent<AudioSource>();

        // initialize toggle state based on AudioSource
        if (audioSource != null)
        {
            musicToggle.isOn = !audioSource.mute; // toggle reflects if music is playing
        }

        // add listener for toggle changes
        musicToggle.onValueChanged.AddListener(OnMusicToggleChanged);
    }

    private void OnMusicToggleChanged(bool isOn)
    {
        // mute or unmute the music
        if (audioSource != null)
        {
            audioSource.mute = !isOn;
        }
    }
}
