using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private TMP_Text highScoreText;

    private void Start()
    {
        //DataManager.Instance.LoadScore();
        highScoreText.text = DataManager.Instance.bestPlayer == null
            ? ""
            : $"Best Score : {DataManager.Instance.bestPlayer} - {DataManager.Instance.highScore}";
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void SetPlayerName()
    {
        DataManager.Instance.playerName = nameInputField.text;
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}