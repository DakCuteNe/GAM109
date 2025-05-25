using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public static class GameStateManager
{
    public static int CurrentLevel { get; private set; }

    public static bool IsGamePaused { get; private set; }

    public static UnityEngine.Vector3? LastCheckpointPosition { get; private set; }

    public static void LoadLevel(int levelNumber)
    {
        CurrentLevel = levelNumber;
        Debug.Log($"[GameStateManager] Loading level {CurrentLevel}");
    }

    public static void PauseGame()
    {
        IsGamePaused = true;
        Debug.Log("[GameStateManager] Game paused");
    }

    public static void ResumeGame()
    {
        IsGamePaused = false;
        Debug.Log("[GameStateManager] Game resumed");
    }

    public static void ResetCheckpoint()
    {
        LastCheckpointPosition = null;
        Debug.Log("[GameStateManager] Checkpoint reset");
    }

    public static UnityEngine.Vector3 GetCheckPoint()
    {
        UnityEngine.Vector3 checkpoint = LastCheckpointPosition ?? UnityEngine.Vector3.zero;
        Debug.Log($"[GameStateManager] Checkpoint position: {checkpoint}");
        return checkpoint;
    }

    public static void SetCheckpoint(UnityEngine.Vector3 position)
    {
        LastCheckpointPosition = position;
        Debug.Log($"[GameStateManager] Checkpoint set to {position}");
    }
}
