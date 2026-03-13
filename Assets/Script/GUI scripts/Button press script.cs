using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttonpressscript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject cam;
    public void onPressMainMenu() // creates a new player when the start button is pressed and starts the game - Alexander
    {
        //Transition.Instance.StartTransition();
        Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
        try
        {
            Instantiate(cam);
        }
        catch {; }
        
        SceneManager.LoadScene(1);
    }
    public void onPressExitButton() //Exits the game- Alexander.
    {
        Application.Quit();
    }
    public void specificScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
