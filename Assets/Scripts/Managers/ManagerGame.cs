using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerGame : MonoBehaviour
{
    [SerializeField] GameObject Panel = null;

    void Start()
    {
        ManagerEvents.Instance.GameStart += GameStart;
        ManagerEvents.Instance.GameLost += GameLost;
    }

    void Update()
    {
        
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }

    public void GameStart()
    {
        Panel.SetActive(false);
    }

    public void GameLost()
    {
        Panel.SetActive(true);
    }
}
