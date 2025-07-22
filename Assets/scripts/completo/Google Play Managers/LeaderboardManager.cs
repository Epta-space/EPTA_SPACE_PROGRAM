using UnityEngine;
using GooglePlayGames;

public class LeaderboardManager : MonoBehaviour
{
    public static LeaderboardManager Instance { get; private set; }

    [Header("Leaderboard ID from Google Play Console")]
    public string leaderboardID = "CgkIwZ7-nuUcEAIQAg";
    private const long minScore = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ReportScore(long score)
    {
        if (score < 0)
        {
            Debug.LogError("Score cannot be negative.");
            return;
        }

        if (string.IsNullOrEmpty(leaderboardID))
        {
            Debug.LogError("Leaderboard ID is not set.");
            return;
        }

        if (score < minScore)
        {
            Debug.LogWarning($"Score {score} is less than the minimum score of {minScore}. Not reporting.");
            return;
        }

        if (GPGSManager.Instance.IsAuthenticated())
        {
            ReportScoreInternal(score);
        }
        else
        {
            Debug.LogWarning("User is not authenticated. Attempting to reconnect...");
            GPGSManager.Instance.TryReconnect((bool success) =>
            {
                if (success)
                {
                    ReportScoreInternal(score);
                }
                else
                {
                    Debug.LogError("Cannot report score: Authentication failed.");
                }
            });
        }
    }

    private void ReportScoreInternal(long score)
    {
        PlayGamesPlatform.Instance.ReportScore(score, leaderboardID, (bool success) =>
        {
            if (success)
            {
                Debug.Log("Score reported successfully.");
            }
            else
            {
                Debug.LogError("Failed to report score.");
            }
        });
    }

    public void ShowLeaderboardUI()
    {
        if (GPGSManager.Instance.IsAuthenticated())
        {
            PlayGamesPlatform.Instance.ShowLeaderboardUI(leaderboardID);
        }
        else
        {
            Debug.LogWarning("User is not authenticated. Attempting to reconnect...");
            GPGSManager.Instance.TryReconnect((bool success) =>
            {
                if (success)
                {
                    PlayGamesPlatform.Instance.ShowLeaderboardUI(leaderboardID);
                }
                else
                {
                    Debug.LogError("Cannot show leaderboard UI: Authentication failed.");
                }
            });
        }
    }
}