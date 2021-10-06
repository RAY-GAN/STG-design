using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playButton;
    public GameObject playerShip;
    public GameObject EnemySpawner;
    public GameObject GameOverGO;
    public GameObject scoreUITextGO;

    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver,
    }

    GameManagerState GMState;

    // Start is called before the first frame update
    void Start()
    {
        GMState = GameManagerState.Opening;
    }

    void UpdatreGameManagerState()
    {
        switch(GMState)
        {
            case GameManagerState.Opening:

                GameOverGO.SetActive(false);

                playButton.SetActive(true);

                break;

            case GameManagerState.Gameplay:

                scoreUITextGO.GetComponent<GameScore>().Score = 0;

                playButton.SetActive(false);

                playerShip.GetComponent<PlayerControl>().Init();

                playerShip.GetComponent<PlayerControl>().speed = 2.5f;

                EnemySpawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();

                break;

            case GameManagerState.GameOver:

                EnemySpawner.GetComponent<EnemySpawner>().UnscheduleEnemySpawner();

                GameOverGO.SetActive(true);

                Invoke("ChangeToOpeningState", 8f);

                break;
        }
    }
    
    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdatreGameManagerState();
    }

    public void StartGamePlay()
    {
        GMState = GameManagerState.Gameplay;
        UpdatreGameManagerState();
    }

    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }
}
