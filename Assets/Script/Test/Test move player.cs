using UnityEngine;

public class Testmoveplayer : MonoBehaviour
{
    KeyCode testButton = KeyCode.F;
    GameObject player;

    private void Start()
    {
       player = this.gameObject;   
    }
    private void Update()
    {
        if (Input.GetKeyUp(testButton))
            player.transform.position += new Vector3(20,0,0);
    }
}
