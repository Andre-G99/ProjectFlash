using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject knifeAsProjectile;
    private GameObject newKnife;
    private int ammoCount = 1;
    public float throwForce;
    public Transform shotPoint;

    Vector2 knifePos;
    Vector2 mousePos;
    Vector2 direction;

    //line renderer stuff
    private LineRenderer LR;
    private Renderer rnd;    
    private Vector2 gameObjPosition;

    // Start is called before the first frame update
    void Start()
    {
        LR = GetComponent<LineRenderer>();
        rnd = GetComponent<Renderer>();

        //set position of the gameobject
        gameObjPosition = new Vector2(shotPoint.position.x, shotPoint.position.y);
    }

    private void Update() {
        knifePos = transform.position;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePos - knifePos);
        transform.right = direction;

        gameObjPosition = this.transform.position;
        
        if (Input.GetButtonUp("Fire2") && (ammoCount != 0))
        {
            Throw();
            LR.enabled = false;
        }

        if(newKnife == null){
            ammoCount = 1;
        }

        if (Input.GetButton("Fire2") && ammoCount!= 0){
            LR.enabled = true;
            LR.SetPosition(0, gameObjPosition);
            LR.SetPosition(1, mousePos);
           rnd.material.mainTextureScale = new Vector2((int)Vector2.Distance(gameObjPosition, mousePos), 1);
        }

    }

    public void Throw(){
        newKnife = Instantiate(knifeAsProjectile, shotPoint.position, shotPoint.rotation);
        newKnife.GetComponent<Rigidbody2D>().velocity = transform.right * throwForce;
        ammoCount = 0;
    }

    Vector2 PointPosition(float time){
        Vector2 position = (Vector2)shotPoint.position + (direction.normalized * throwForce * time) + 0.5f * Physics2D.gravity * (time * time);
        return position;
    }
}
