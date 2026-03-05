using UnityEngine;

public class Duoton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance;

    private void Awake()
    {
        Instance = this as T;
    }
}

