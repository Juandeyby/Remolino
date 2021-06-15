using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputKeyboard : MonoBehaviour
{
    [HideInInspector] private GameObject _ball;
    [HideInInspector] private Rigidbody _rbBall;

    void Start()
    {
        _ball = FindObjectOfType<GameManager>().ball;
        _rbBall = _ball.GetComponent<Rigidbody>();
    }

    void Update()
    {
        GetKeySpace();
        GetKeyR();
    }

    private void GetKeySpace()
    {
        if (_ball)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rbBall.AddForce(Vector3.up * 200, ForceMode.Acceleration);
            }
        }
    }

    private void GetKeyR()
    {
        var gameManager = FindObjectOfType<GameManager>();
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!gameManager.loading)
            {
                gameManager.loading = true;
                string currentSceneName = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(currentSceneName);
            }
        }
    }
}
