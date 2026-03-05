using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttonpressscript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject cam;
    public void onPressMainMenu()
    {
        Transition.Instance.StartTransition();
        Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(cam);
        SceneManager.LoadScene(1);
    }
}
