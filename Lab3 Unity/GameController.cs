using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(RunGameStateTest());
    }

    private IEnumerator RunGameStateTest()
    {
        GameStateManager.LoadLevel(1);

        yield return new WaitForSeconds(1f);
        GameStateManager.PauseGame();

        yield return new WaitForSeconds(1f);
        GameStateManager.SetCheckpoint(new Vector3(0, 0, 0));

        yield return new WaitForSeconds(1f);
        GameStateManager.ResumeGame();

        yield return new WaitForSeconds(1f);
        GameStateManager.GetCheckPoint();

        yield return new WaitForSeconds(1f);
        GameStateManager.ResetCheckpoint();

        yield return new WaitForSeconds(1f);
        GameStateManager.GetCheckPoint();
    }
}
