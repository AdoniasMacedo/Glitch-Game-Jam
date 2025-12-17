using System.Collections.Generic;
using UnityEngine;

public class BlessingManager : MonoBehaviour
{
    private static BlessingManager _instance;
    public static BlessingManager Instance => _instance;

    private List<Blessing> _activeBlessings = new List<Blessing>();

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

    private void Start()
    {
        GameState.Instance.OnRoundStart += ApplyBlessingEffects;
    }

    private void OnDestroy()
    {
        GameState.Instance.OnRoundStart -= ApplyBlessingEffects;
    }

    public void AddBlessing(Blessing blessing, GameObject target)
    {
        var blessingInstance = Instantiate(blessing);
        _activeBlessings.Add(blessingInstance);
        blessingInstance.ApplyBlessing(target);
    }

    public void RemoveBlessing(Blessing blessing)
    {
        _activeBlessings.Remove(blessing);
        blessing.RemoveBlessing();
    }

    private void ApplyBlessingEffects()
    {
        for (int i = _activeBlessings.Count - 1; i >= 0; i--)
        {
            var blessing = _activeBlessings[i];
            blessing.UpdateBlessing();

            if (blessing.duration <= 0)
            {
                RemoveBlessing(blessing);
            }
        }
    }
}
