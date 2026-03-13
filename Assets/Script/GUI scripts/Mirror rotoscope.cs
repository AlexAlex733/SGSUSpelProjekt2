using UnityEngine;

public class Mirrorrotoscope : MonoBehaviour, IInteract
{
    [SerializeField] GameObject video;

    private void Awake()
    {
        video.SetActive(false);
    }

    public void OnInteract()
    {
        video.SetActive (true);
    }

}
