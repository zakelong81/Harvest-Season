using UnityEngine;

public class NPCAnimal : MonoBehaviour
{
    // borders where your NPCs moves in, can be packed in vector2
    public float maxX = 6.1f;
    public float minX = -6.1f;
    public float maxY = 4.2f;
    public float minY = -4.2f;

    private float randomX;
    private float randomY;

    // random range for walking distance (check for timing), can be packed in vector2...
    public float minRange = -2f;
    public float maxRange = 2f;

    public Vector2 walkingChangeX = new Vector2(-2f, 2f);

    // timing for movement change
    private float tChange = 0; // force new direction in the first Update	
    public Vector2 timeChange = new Vector2(0.5f, 1.5f);

    public float moveSpeed = 1f;
    public bool letNPCMove = true;


    // sets the value when the character should play its animation
    private Animator anim;
    public float animThreshold = 0.5f;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(0, 0);


        if (letNPCMove)
        {
            if (Time.time >= tChange)
            {
                randomX = Random.Range(walkingChangeX.x, walkingChangeX.y);  															 
                randomY = Random.Range(walkingChangeX.x, walkingChangeX.y);  
                tChange = Time.time + Random.Range(timeChange.x, timeChange.y);           
            }

            // used for changing the animation of the NPC
            if (randomX > animThreshold)
            {
                anim.SetInteger("Direction", 1);
                direction.x = 1;
                
            }
            else if(randomX < -animThreshold) 
            {
                anim.SetInteger("Direction", -1);
                direction.x = -1;
               
               
            }
            else if(randomY > animThreshold)
            {
                anim.SetInteger("Direction", 2);
                direction.y = 1;
               
            }
            else if(randomY < -animThreshold)
            {
                anim.SetInteger("Direction", -2);
                direction.y = -1;
                
            }
          
            GetComponent<Rigidbody2D>().velocity = direction * moveSpeed;
           
        }

    }
   
}