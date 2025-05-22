using UnityEngine;

public class GameController: MonoBehaviour // done
{
    public GameObject gameOverScreen;


    public void OnEnable()
    {
        CowMove.onCowDeath += GameOver;
    }
    public void OnDisable()
    {
        CowMove.onCowDeath -= GameOver;
    }
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }


}
