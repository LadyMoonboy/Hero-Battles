using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ArenaGameEngine
{
    // Vampire --> balanced all around but has a small chance to insta-kill the opponent
    //-Has 5% - 10% more base HP
    //-Every attack deals 2% more damage compared to the previous attack
    //-Every dealt attack heals him for 2% of his max HP
    //-There is a 5% chance of causing bleeding on the opponent (bleeding kills the opponent instantly)
    public class Vampire : Hero
    {
        public Vampire() : this("Dracula") { }
        public Vampire(string name) : base(name) 
        {
            int moreHealthPercentage = Random.Shared.Next(105, 111);
            Health = (int)(Health * moreHealthPercentage / 100);
        }
        private int previousAttack = 0;
        public override int Attack()
        {
            Health = (int)(Health * 1.05);

            int attackDamage = base.Attack();

            attackDamage = (int)(attackDamage + previousAttack * 1.02);
            previousAttack = attackDamage;

            int chanceToBleed = Random.Shared.Next(1, 101);
            if (chanceToBleed <= 5)
            {
                attackDamage = int.MaxValue;
            }
            return attackDamage;
        }
        public override void TakeDamage(int incomingDamage)
        {
            base.TakeDamage(incomingDamage);
        }
    }
}
