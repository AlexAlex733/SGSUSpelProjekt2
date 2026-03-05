using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class Interactionscript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject showImage;
    [SerializeField] private GameObject interactionMarker;
    [SerializeField] public GameObject player;

    [Header("Variables")]
    [SerializeField] private Vector3 offset = new Vector3(75f, 75f, 0);

    private void Start()
    {
        try
        {
            player = FindAnyObjectByType<PlayerMovement>().gameObject;
            interactionMarker = player.transform.GetChild(0).gameObject;
        }
        catch
        {
            Debug.Log("Reference has failed");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        MarkerInstantiate(true);
    }
    private void OnTriggerExit(Collider other)
    {
        MarkerInstantiate(false);
    }
    public void MarkerInstantiate(bool enter)
    {
        GameObject marker = null;
        if (enter)
        {
            marker = Instantiate(interactionMarker, this.transform.position + new Vector3(0,1,0), Quaternion.identity);
            marker.transform.localScale = player.transform.localScale * 1.1f;
            marker.name = "Current Selection";
            marker.tag = "MarkerTag";
        }
        else if (!enter)
        {
            Destroy(GameObject.FindWithTag("MarkerTag"), 0.00001f);
        }
    }

    private void Update()
    {

    }
}
