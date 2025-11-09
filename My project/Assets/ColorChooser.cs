using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColorChooser : MonoBehaviour
{
    public List<ColorMapping> colorMappings;
    public Material Material;
    private Coroutine animationCoroutine;

    private string chosenColor;

    public StringEvent MessageTeamA;
    public StringEvent MessageTeamB;

    private int TeamAScore;
    private int TeamBScore;

    public TMP_Text teamAText;
    public TMP_Text teamBText;
    

    private void OnEnable()
    {
        MessageTeamA.OnEventRaised += TeamAMessageReceived;
        MessageTeamB.OnEventRaised += TeamBMessageReceived;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (animationCoroutine == null)
            {
                StartAnimateRandomColor();
            }
            else
            {
                StopAnimateColor();
            }
        }
    }

    public void TeamAMessageReceived(string msg)
    {
        if (msg == chosenColor)
        {
            Debug.Log("Team A wins!");
            TeamAScore++;
            teamAText.text = TeamAScore.ToString();
        }
    }

    public void TeamBMessageReceived(string msg)
    {
        if (msg == chosenColor)
        {
            Debug.Log("Team B wins!");
            TeamBScore++;
            teamBText.text = TeamBScore.ToString();
        }
    }

    public void SetRandomColor()
    {
        int randInt = Random.Range(0, colorMappings.Count);
        chosenColor = colorMappings[randInt].ColorName;
        Material.color = colorMappings[randInt].Color;
    }

    [ContextMenu("Start animate color")]
    public void StartAnimateRandomColor()
    {
        animationCoroutine = StartCoroutine(AnimateColor());
    }

    [ContextMenu("Stop animate color")]
    public void StopAnimateColor()
    {
        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
        }

        animationCoroutine = null;
    }

    public IEnumerator AnimateColor()
    {
        while (true)
        {
            SetRandomColor();
            yield return new WaitForSeconds(0.1f);
        }
    }
}