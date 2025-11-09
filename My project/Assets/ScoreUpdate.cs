using UnityEngine;

public class ScoreUpdate : MonoBehaviour
{
    public StringEvent MessageReceived;

    private void OnEnable()
    {
        MessageReceived.OnEventRaised += OnMessageReceived;
    }
    
    private void OnDisable()
    {
        MessageReceived.OnEventRaised -= OnMessageReceived;
    }

    public void OnMessageReceived(string message)
    {
        Debug.Log(message);
    }
}
