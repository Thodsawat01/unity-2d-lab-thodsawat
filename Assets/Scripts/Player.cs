using System;
using UnityEngine;

public class Player : Character, IShootable
{
    [field: SerializeField] public GameObject Bullet {  get; set; }
    [field: SerializeField] public Transform ShootPoint { get; set; }
    [field: SerializeField] public float ReloadTime { get; set; }
    [field: SerializeField] public float WaitTime { get; set; }
    

    public static event Action<float, float> OnHealthChanged;
    private int maxHealth;

    void Start()
    {
        maxHealth = 100;
        base.Intialize(maxHealth);
        ReloadTime = 1.0f;
        WaitTime = 0.0f;
        

        if (OnHealthChanged != null)
        {
            OnHealthChanged(this.health, maxHealth);
        }
    }

    private void FixedUpdate()
    {
        WaitTime += Time.fixedDeltaTime;
    }

    private void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        if ( Input.GetButtonDown("Fire1") && WaitTime >= ReloadTime)
        {
            var bullet = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
            Banana banana = bullet.GetComponent<Banana>();
            if (banana != null)
                banana.InitWeapon(20, this);
            WaitTime = 0.0f;
        }
    }


    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        
        if (OnHealthChanged != null)
        {
            OnHealthChanged(this.health, maxHealth);
        }
        
        if (this.health <= 0)
        {
            Debug.Log(this.name + " is defeated!");

        }
    }

    public void OnHitWith(Enemy enemy)
    {
        TakeDamage(enemy.DamageHit);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            Debug.Log($"{this.name} Hit with {enemy.name}!");
            OnHitWith(enemy);
        }
    }
}