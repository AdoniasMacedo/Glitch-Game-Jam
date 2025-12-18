using System.Collections.Generic;
using UnityEngine;

public class CreatureRegistry : MonoBehaviour
{
    private static CreatureRegistry _instance;
    public static CreatureRegistry Instance => _instance;

    private static List<Creature> _activeCreatures = new List<Creature>();
    public IReadOnlyList<Creature> ActiveCreatures => _activeCreatures;

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

    public static void Register(Creature creature)
    {
        if (!_activeCreatures.Contains(creature))
        {
            _activeCreatures.Add(creature);
        }
    }

    public static void Unregister(Creature creature)
    {
        if (_activeCreatures.Contains(creature))
        {
            _activeCreatures.Remove(creature);
        }
    }
}
