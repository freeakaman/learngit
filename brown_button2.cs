
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brown_button2 : MonoBehaviour
{
    public Collider2D coll;
    public LayerMask groundLayer;
    public float upDistance ;
    public bool isPress;
    public float upOffset;
    public float leftoffset;
    public float mass;
    //public Animator anim;
    public int trig;
    RaycastHit2D hitinfo;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
       
        PhysicsCheck();
        button();
    }
    void PhysicsCheck()
    {
        upDistance = 0.5f;
        upOffset =-0.1878201f;
        leftoffset= 0.4863567f;
        RaycastHit2D upcheck = Raycast(new Vector2(-leftoffset, upOffset), Vector2.up, upDistance, groundLayer);
        RaycastHit2D upcheck2 = Raycast(new Vector2(leftoffset, upOffset), Vector2.up, upDistance, groundLayer);
        RaycastHit2D upcheck3 = Raycast(new Vector2(0f, upOffset), Vector2.up, upDistance, groundLayer);
        if (upcheck)
        {
            isPress = true;
            mass = upcheck.collider.attachedRigidbody.mass;
        }
        else if (upcheck2)
        {
            isPress = true;
            mass = upcheck2.collider.attachedRigidbody.mass;
        }
        else if (upcheck3)
        {
            isPress = true;
            mass = upcheck3.collider.attachedRigidbody.mass;
        }
        else{
            mass=0;
        }
    }

    RaycastHit2D Raycast(Vector2 offset, Vector2 rayDirection, float length, LayerMask layer)
    {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(pos + offset, rayDirection, length, layer);
        Color color = hit ? Color.red : Color.green;
        Debug.DrawRay(pos + offset,rayDirection * length, color);
        return hit;
    }
   void button(){
       if(mass>trig){
        transform.GetComponent<SpriteRenderer>().enabled=true;
        transform.GetComponent<Collider2D>().enabled=true;
       }
   }
   

}