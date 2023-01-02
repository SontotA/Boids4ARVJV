using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidsManager : MonoBehaviour
{
    public int nbrBoids;
    List<Boids> boids;
    List<GameObject> prefabBoids;
    public float distanceSeparation;
    public float distAllign;
    public float coeffAlligment;
    public float distRapproch;
    public float coeffRapprochement;
    public GameObject prefab;
    public float spd;

    // Start is called before the first frame update
    void Start()
    {
        boids = new List<Boids>();
        prefabBoids = new List<GameObject>();
        for(int i = 0; i < nbrBoids; i++)
        {
            boids.Add(new Boids());
            GameObject go = Instantiate(prefab, new Vector3(1, 1, 1), Quaternion.identity);
            prefabBoids.Add(go);

        }
    }

    // Update is called once per frame
    void Update()
    {

        moveBoids();
        for(int i = 0; i < prefabBoids.Count; i++)
        {
            Debug.Assert(boids[i].getPosition().x != float.NaN);
            prefabBoids[i].transform.position = boids[i].getPosition();
            
        }
        

    }

    void moveBoids()
    {
        foreach(Boids b in boids)
        {
            Vector3 v1 = rule1(b);
            Vector3 v2 = rule2(b);
            Vector3 v3 = rule3(b);

            b.setDirection((v1 + v2 + v3).normalized*spd);
            b.setPosition(b.getPosition() + b.getDirection());
        }
    }

    Vector3 rule1(Boids b)
    {
        Vector3 v3 = new Vector3(0,0,0);
        
        foreach(Boids bj in boids)
        {
            if(bj != b)
            {
                if (Vector3.Distance(b.getPosition(),bj.getPosition())<distanceSeparation )
                {
                    v3 = v3-(bj.getPosition()-b.getPosition());
                }
            }
        }

        return v3/coeffAlligment;
    }

    Vector3 rule2(Boids b)
    {
        Vector3 v3 = new Vector3(0, 0, 0);

        foreach (Boids bj in boids)
        {
            if (bj != b)
            {
                if (Vector3.Distance(b.getPosition(), bj.getPosition()) < distAllign)
                {
                    v3 += bj.getDirection() ;
                }
            }
        }
        v3 = v3 / coeffAlligment;
        return v3;
    }

    Vector3 rule3(Boids b)
    {
        Vector3 v3 = new Vector3(0, 0, 0);
        int sum = 1;

        foreach (Boids bj in boids)
        {
            if (bj != b)
            {
                if (Vector3.Distance(b.getPosition(), bj.getPosition()) < distRapproch)
                {
                    v3 += bj.getPosition();
                    sum++;
                }
            }
        }
        if (sum == 0) return new Vector3(0, 0, 0);
        v3 = v3 / (sum-1);

        v3 = (v3 - b.getPosition()) / coeffRapprochement;
        return v3;
    }
}
