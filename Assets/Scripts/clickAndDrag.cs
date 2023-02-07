using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickAndDrag : MonoBehaviour
{
    // Script that manages particle interactions and controls
    
    private Vector3 dragOffset;
    private Camera cam;
    private SpriteRenderer sprite;
    public int sortingOrder = 0;
    [SerializeField] private float speed = 10f;
    //[SerializeField] public GameObject selectedParticle, reactionParticle, resultParticle;
    //public string selectedParticleName, reactionParticleName, resultParticleName;

    // camera is called when the scene is innitiated
    void Awake()
    {
        cam = Camera.main;
        sprite = GetComponent<SpriteRenderer>();
    }
    // calculate drag offset and ordering layer, then transform the particle to the mouse pos
    void OnMouseDown()
    {
        dragOffset = transform.position - GetMousePos();
        sprite.sortingOrder += 1;
        //selectedParticleName = selectedParticle.name;
    }
    void OnMouseDrag()
    {
        transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + dragOffset, speed * Time.deltaTime);
    }
    // determine the mouse pos
    Vector3 GetMousePos()
    {
        var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
    // determine if the particles react, and intanciating the result accordingly
    /*private void OnMouseUp()
    {
        Collider2D collider = Physics2D.OverlapPoint(transform.position);
        if (collider != null)
        {
            if (gameObject.name == "Proton" && collider.gameObject.name == "Electron")
            {
                Instantiate(resultParticle, collider.transform.position, Quaternion.identity);
                Destroy(gameObject);
                Destroy(collider.gameObject);
            }
            else if (gameObject.name == "Electron" && collider.gameObject.name == "Proton")
            {
                Instantiate(resultParticle, collider.transform.position, Quaternion.identity);
                Destroy(gameObject);
                Destroy(collider.gameObject);
            }
            else 
            {
                collider.isTrigger = true;
            }
        }
    }*/
}