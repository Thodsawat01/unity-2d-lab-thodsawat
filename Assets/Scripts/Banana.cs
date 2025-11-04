using UnityEngine;

public class Banana : Weapon
{
    [SerializeField] private float speed;
    public override void Move()
    {
        float newX = transform.position.x + speed * Time.fixedDeltaTime;
        float newY = transform.position.y;
        Vector2 newPosition = new Vector2(newX, newY);
        transform.position = newPosition;
    }

    public override void OnHitWith(Character character)
    {
        if (character is Enemy)
            character.TakeDamage(this.damage);
    }

    private void Start()
    {
        speed = 4.0f * GetShootDirection();
        damage = 30;
    }

    private void FixedUpdate()
    {
        Move();
    }
}
