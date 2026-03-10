using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class Interactionscript : Duoton<Interactionscript>
{
    [Header("References")]
    [SerializeField] private GameObject interactionMarker;
    [SerializeField] public GameObject player;

    private void Start()
    {
        try //Tries to get the components and the scripts for the code to work - Alexander
        {
            player = FindAnyObjectByType<PlayerMovement>().gameObject;
            interactionMarker = player.transform.GetChild(0).gameObject;
        }
        catch
        {
            Debug.Log("Reference has failed or image doesn't exist");
        }
    }

    private void OnTriggerEnter(Collider other) //Activates a marker when the player enter a collider - Alexander
    {
        MarkerInstantiate(true);
    }
    private void OnTriggerExit(Collider other) // Deactivates the marker when the collider area is left - Alexander
    {
        MarkerInstantiate(false);
    }

    public void MarkerInstantiate(bool enter) //The code for creating and destroying the marker - Alexander
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
}
