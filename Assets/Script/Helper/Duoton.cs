using UnityEngine;

public class Duoton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance;

    private void Awake() // Makes references to other classes easier - Alexander
    {
        Instance = this as T;
    }
}

