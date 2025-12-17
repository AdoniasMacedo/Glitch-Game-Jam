using UnityEngine;

public class BargainManager : MonoBehaviour
{
    private static BargainManager _instance;
    public static BargainManager Instance => _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void TriggerBargain(Bargain bargain, GameObject target)
    {
        // Placeholder for bargain logic
    }
}

public class Bargain : ScriptableObject
{
    // Placeholder for bargain data
}
