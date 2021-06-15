using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TMP_Text _timerGUI;
    [SerializeField] private TMP_Text _pointsGUI;
    [SerializeField] private TMP_Text _bestPointsGUI;
    [SerializeField] private CanvasGroup _panel;

    public void SetGUI()
    {
        var timer = PlayerPrefs.GetFloat("timer");
        var points = PlayerPrefs.GetFloat("points");
        var bestPoints = PlayerPrefs.GetFloat("bestPoints");

        _timerGUI.text = "Time: " + GameManager.timerString(timer);
        _pointsGUI.text = "Points: " + points.ToString();
        _bestPointsGUI.text = "Best Points: " + bestPoints.ToString();
    }

    public void SetActive(bool active)
    {
        if (active)
        {
            _panel.alpha = 1;
        } else
        {
            _panel.alpha = 0;
        }
    }
}
