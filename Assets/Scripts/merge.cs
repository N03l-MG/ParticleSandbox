using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class merge : MonoBehaviour
{
    private static Dictionary<string, string> _recipes = new Dictionary<string, string>()
    {
        { "Proton + Electron", "Hydrogen" },
        {"Hydrogen(Clone) + Proton", "Helium" }
        //clean up later lol
    };

    private void OnCollisionStay2D(Collision2D collision)
    {
        var otherGameObject = collision.gameObject;
        Debug.Log($"{gameObject} collided with {otherGameObject}");

        var recipe = $"{gameObject.name} + {otherGameObject.name}";
        if (!_recipes.ContainsKey(recipe)) return;
        Instantiate(Resources.Load(_recipes[recipe]), (otherGameObject.transform.position + gameObject.transform.position) / 2, Quaternion.identity);
        Destroy(gameObject);
        Destroy(otherGameObject);
    }
}





/* public class merge : MonoBehaviour
{
    public class ParticlePair
    {
        public string particle1;
        public string particle2;
        public GameObject resultParticlePrefab;

        public ParticlePair(string particle1, string particle2, GameObject resultParticlePrefab)
        {
            this.particle1 = particle1;
            this.particle2 = particle2;
            this.resultParticlePrefab = resultParticlePrefab;
        }
    }

    public List<ParticlePair> particlePairs = new List<ParticlePair>();
    void Start(GameObject resultParticlePrefab)
    {
        
        particlePairs.Add(new ParticlePair("Proton", "Electron", resultParticlePrefab));
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        foreach (ParticlePair particlePair in particlePairs)
        {
            if ((gameObject.name == particlePair.particle1 && collider.gameObject.name == particlePair.particle2) || (gameObject.name == particlePair.particle2 && collider.gameObject.name == particlePair.particle1))
            {
                collider.isTrigger = true;
                Instantiate(particlePair.resultParticlePrefab, (transform.position + collider.transform.position) / 2, Quaternion.identity);
                Destroy(gameObject);
                Destroy(collider.gameObject);
                break;
            }
            else {
                collider.isTrigger = false;
            }
        }
    }
}
*/