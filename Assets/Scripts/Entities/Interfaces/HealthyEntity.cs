using UnityEngine;

public class HealthyEntity : Entity {
    [SerializeField]
    private float _health;
    public float health {
        get => _health; set {
            this._health = value;
            if (health <= 0f) {
                if (this is Enemy e) {
                    this.level.enemyList.Remove(e);
                } else if (this is Turret t) {
                    this.level.turretList.Remove(t);
                } else if (this is Player) {
                    this.level.player = null;
                }
                GameObject.Destroy(this);
            }
        }
    }

    public void doDamage(float damage) {
        this.health -= damage;
    }

}
