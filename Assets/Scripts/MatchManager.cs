using UnityEngine;
using System;

public class MatchManager : MonoBehaviour
{
    public MatchPhase Phase { get; private set; } = MatchPhase.Waiting;
    public int minimumPlayers = 2, countdownSeconds = 20; public int alivePlayers;
    public event Action<MatchPhase> PhaseChanged;
    float timer;
    public enum MatchPhase { Waiting, Starting, InProgress, Finished }
    void Update()
    {
        if (Phase == MatchPhase.Waiting && alivePlayers >= minimumPlayers) ChangePhase(MatchPhase.Starting);
        if (Phase == MatchPhase.Starting) { timer += Time.deltaTime; if (timer >= countdownSeconds) ChangePhase(MatchPhase.InProgress); }
        if (Phase == MatchPhase.InProgress && alivePlayers <= 1) ChangePhase(MatchPhase.Finished);
    }
    void ChangePhase(MatchPhase phase) { Phase = phase; timer = 0; PhaseChanged?.Invoke(phase); }
}
