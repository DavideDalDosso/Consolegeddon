using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract class Building : GameObject, IDamageable
{
    public int health { get; set; }
    public void Damage(int damage)
    {
        health -= damage;
    }
}
