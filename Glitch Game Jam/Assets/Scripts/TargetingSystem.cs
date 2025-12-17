using System;
using UnityEngine;

public class TargetingSystem : MonoBehaviour
{
    private static TargetingSystem _instance;
    public static TargetingSystem Instance => _instance;

    public event Action<Creature> OnTargetSelected;
    private bool _isTargeting;

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

    private void Update()
    {
        if (!_isTargeting) return;

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Creature creature = hit.collider.GetComponent<Creature>();
                if (creature != null)
                {
                    OnTargetSelected?.Invoke(creature);
                    _isTargeting = false;
                }
            }
        }
    }

    public void StartTargeting()
    {
        _isTargeting = true;
    }
}
