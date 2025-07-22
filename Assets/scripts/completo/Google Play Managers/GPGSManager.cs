using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class GPGSManager : MonoBehaviour
{
    public static GPGSManager Instance { get; private set; }
    private bool isAuthenticated = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeGPGS();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeGPGS()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        // PlayGamesPlatform.Activate();
        PlayGamesPlatform.Instance.Authenticate(OnSignInResult);
    }

    private void OnSignInResult(SignInStatus status)
    {
        if (status == SignInStatus.Success)
        {
            Debug.Log("Google Play Games sign-in successful.");
            isAuthenticated = true;
        }
        else
        {
            Debug.LogError("Google Play Games sign-in failed: " + status);
            isAuthenticated = false;
        }
    }

    public bool IsAuthenticated()
    {
        return isAuthenticated;
    }

    public void TryReconnect(System.Action<bool> onComplete = null)
    {
        Debug.Log("Attempting to reconnect to Google Play Games...");
        PlayGamesPlatform.Instance.Authenticate((SignInStatus status) =>
        {
            if (status == SignInStatus.Success)
            {
                Debug.Log("Google Play Games reconnection successful.");
                isAuthenticated = true;
                onComplete?.Invoke(true);
            }
            else
            {
                Debug.LogError("Google Play Games reconnection failed: " + status);
                isAuthenticated = false;
                onComplete?.Invoke(false);
            }
        });
    }
}