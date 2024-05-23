using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGameEngine
{
    // Brute --> very tanky but doesn't do a lot of damage
    //-Has 150% more HP
    //-Deals the least amount of damage
    //-There's a 40% chance for him to do 30% more damage
    //-There's a random chance (from 20% to 40%) to take 10% to 20% less damage
    public class Brute : Hero
    {
        public Brute() : this("Big Guy") { }

        public Brute(string name) : base(name) 
        {
            Health = (int)(Health * 2.50);
        }

        public override int Attack()
        {
            int attackDamage = base.Attack();
            attackDamage = (int)(attackDamage * 0.75);

            int chance = Random.Shared.Next(1, 101);
            if (chance <= 40)
            {
                attackDamage = (int)(attackDamage * 1.30);
            }
            return attackDamage;
        }
        public override void TakeDamage(int incomingDamage)
        {
            //There's a random chance (from 20% to 40%) to take 10% to 20% less damage
            int chanceToTakeLessDamage = Random.Shared.Next(20, 41);//determines what the chance to take less damage will be
            int reductionPercentage = Random.Shared.Next(10, 21);//determines the percenatege of damage reduction

            int finalChance = Random.Shared.Next(1, 101);

            if (finalChance <= chanceToTakeLessDamage)
            {
                incomingDamage = incomingDamage - incomingDamage * reductionPercentage / 100;
            }

            base.TakeDamage(incomingDamage);
        }
    }
}
