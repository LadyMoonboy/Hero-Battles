using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGameEngine
{
    // Mage --> has less HP but also deals more damage
    //-Has 5% less HP
    //-Deals 20% more base damage
    //-Each attack has a 30% chance to cause triple damage
    //-On every other hit taken, casts a shield that reduces incoming damage by 50% - 60%
    public class Mage : Hero
    {
        public Mage() : this("Gandalf") { }
        public Mage(string name) : base(name)
        {
            Health = (int)(Health * 0.95);
            int hitsTakenCount = 0;
        }
        public override int Attack()
        {
            int attackDamage = base.Attack();
            attackDamage = (int)(attackDamage * 1.20);

            int chance = Random.Shared.Next(1, 101);

            if (chance <= 40) 
            {
                attackDamage = (int)(attackDamage * 3);
            }
            return attackDamage;
        }
        private int hitsTakenCount;
        public override void TakeDamage(int incomingDamage)
        {
            hitsTakenCount++;

            if (hitsTakenCount == 2)
            {
                int reductionPercentage = Random.Shared.Next(50, 61);

                incomingDamage -= (incomingDamage * reductionPercentage) / 100;

                hitsTakenCount = 0;
            }
            base.TakeDamage(incomingDamage);
        }
    }
}
