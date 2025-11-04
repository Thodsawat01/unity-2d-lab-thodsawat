using UnityEngine;

public abstract class Character : MonoBehaviour
{
    protected int health;
    public int Health { get => health; set => health = (value < 0) ? 0 : value; }


    protected Animator anim;
    protected Rigidbody2D rb;


    //methods
    public void Intialize(int startHealth)
    {
        Health = startHealth;
        Debug.Log($"{this.name} intialize Health: {this.Health}");
        
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    //methods
    public virtual void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"{this.name} took damage {damage}. Current Health: {Health}");

        IsDead();
    }

    public bool IsDead()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log($"{this.name} is dead! and destroyed!");
            return true;
        }
        else return false;

    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
}
