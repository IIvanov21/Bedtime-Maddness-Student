using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    SOActorModel actorModel;//Reference to our player template
    GameObject playerObject;//Reference to our player object we will create

    [SerializeField]
    string selectedPlayerName;//Use it to specify which template to access

    private void Start()
    {
        CreatePlayer();
    }

    void CreatePlayer()
    {
        //Loaded our player information from the template
        actorModel = Object.Instantiate(Resources.Load(selectedPlayerName)) as SOActorModel ;
        //Create the player object using the information from the the template
        playerObject = GameObject.Instantiate(actorModel.actor) as GameObject;

        playerObject.transform.SetParent(this.transform);

        //Set the player properties
        playerObject.GetComponent<IActorTemplate>().ActorStats(actorModel);

        //Get scene's starting position
        GameObject startPos = GameObject.Find("Starting Position");
        playerObject.transform.position = startPos.transform.position;
        playerObject.transform.rotation = startPos.transform.rotation;
        //playerObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f); example for 0,0,0 rotation


    }

}
