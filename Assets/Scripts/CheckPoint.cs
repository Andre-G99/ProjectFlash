using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private Spawner _spawner;

    void Start(){
        _spawner = GameObject.FindGameObjectWithTag("spawner").GetComponent<Spawner>();
    }

    public bool activated = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            _spawner.lastCheckPoint = this;
        }
    }

}
