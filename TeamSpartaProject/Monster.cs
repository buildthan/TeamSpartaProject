using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace SpartanTeamProject
{
    public class Monster 
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public double Health { get; set; }
        public double MaxHealth { get; set; }
        public double Attack { get; set; }
        public int ExpReward { get; set; } // 몬스터를 처치하면 얻는 경험치
        public int GoldReward { get; set; } // 골드 보상
        

        public Monster(string name, int level, double health, double maxHealth, double attack, int expReward, int goldReward)
        {
            Name = name;
            Level = level;
            Health = health;
            MaxHealth = maxHealth;
            Attack = attack;
            ExpReward = level; // 경험치는 몬스터 레벨만큼
            GoldReward = 500; // 골드 보상
        }

        public int MonsterAttack()
        {
            Random rand = new Random();

            int damage = 0;
            double difference = 0;
            difference = Math.Ceiling(Attack * 0.1);
            damage = rand.Next((int)Attack - (int)difference, (int)Attack + (int)difference + 1);

            return damage;
        }

        // 몬스터 처치 후 경험치 얻기
        public int GetExp()
        {
            return ExpReward;
        }
        // 골드 보상
        public int GetGold()
        {
            return GoldReward;
        }

    }
}
