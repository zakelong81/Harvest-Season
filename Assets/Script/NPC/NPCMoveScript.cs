using UnityEngine;

public class NPCMoveScript : MonoBehaviour
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

    public Vector2 walkingChangeX = new Vector2(-2f, 2f); // used in the example for X and Y!!!! add another Vector2 if needed.

    // timing for movement change
    private float tChange = 0; // force new direction in the first Update	
    public Vector2 timeChange = new Vector2(0.5f, 1.5f);

    public float moveSpeed = 4f;
    public bool letNPCMove = true;


    // sets the value when the character should play its animation
    private Animator anim;
    public float animThreshold = 0.5f;

    public bool facingRight = true;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
 
    }


  
    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(0, 0);

        float h = randomX;
        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();

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
                direction.x = 1;
                anim.SetInteger("State", 1);
            }
            else if(randomX < -animThreshold) 
            {
                direction.x = -1;
                anim.SetInteger("State", 1);
               
            }
            else if(randomY > animThreshold)
            {
                direction.y = 1;
                anim.SetInteger("State", 1);
            }
            else if(randomY < -animThreshold)
            {
                direction.y = -1;
                anim.SetInteger("State", 1);
            }
            else
            {
                anim.SetInteger("State", 0);
            }
            GetComponent<Rigidbody2D>().velocity = direction * moveSpeed;
           
        }

    }
   
    void Flip()
    {
        facingRight = !facingRight;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}