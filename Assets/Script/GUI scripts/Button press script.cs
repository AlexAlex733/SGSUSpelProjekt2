using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttonpressscript : MonoBehaviour
{
    [SerializeField] GameObject player;
    public void onPressMainMenu()
    {
        Transition.Instance.StartTransition();
        Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
        SceneManager.LoadScene(1);
    }
}
