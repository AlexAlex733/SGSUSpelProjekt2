using UnityEngine;

public class Mouse : MonoBehaviour
{
    [SerializeField] Texture2D Curser;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.SetCursor(Curser, Vector2.zero, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
