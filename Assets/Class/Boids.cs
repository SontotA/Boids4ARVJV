using UnityEngine;

public class Boids
{
    private Vector3 direction;
    private Vector3 position;


    public Boids() {
        this.direction = new Vector3(5, 2, 3);
        this.position = new Vector3(1, 1, 1);

    }

    public Vector3 getDirection() { return this.direction; }
    public Vector3 getPosition() { return this.position; }
    public void setDirection(Vector3 dir) {  this.direction =dir ; }
    public void setPosition(Vector3 pos) {  this.position =pos ; }

    


}
