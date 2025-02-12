using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpartanTeamProject
{
    public class Player
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public string Job {  get; set; }
        public double Attack { get; set; }
        public double Deffense { get; set; }
        public double Health { get; set; }
        public double MaxHealth { get; set; }
<<<<<<< Updated upstream
        public double Gold { get; set; }
=======
        public double Mana { get; set; } // 현재 MP
        public double MaxMana { get; set; } // 최대 MP
        public double Gold { get; set; }        
        public bool iscritical = false; // 치명타 발동 여부
        public bool isevade = false; // 공격이 적중했는지 여부
        public double Alphacount { get; set; } // 알파스킬 사용횟수
        public double Doublecount { get; set; } // 더블스킬 사용횟수
        public int PotionCount { get; set; } // 보유 포션 개수
>>>>>>> Stashed changes

        public Player(string name, int level, string job, float attack, float deffense, float health, float maxHealth, float gold)
        {
            Name = name;
            Level = level;
            Job = job; 
            Attack = attack;
            Deffense = deffense;
            Health = health; //현재 체력
            MaxHealth = maxHealth;//최대 체력
            Gold = gold;
<<<<<<< Updated upstream
        }
=======
            iscritical = false;
            isevade = false;
            Alphacount = 0;
            Doublecount = 0;
            PotionCount = 3; //기본 포션 3개

        }
      

       /* public Player(string name, string job)
        {
            Name = name;
            Job = job;

            switch (job)
            {
                case "전사":
                    Level = 1;
                    Attack = 17;
                    Deffense = 8;
                    Health = 120;
                    MaxHealth = 120;
                    Gold = 1500;
                    break;

                case "마법사":
                    Level = 1;
                    Attack = 23;
                    Deffense = 5;
                    Health = 85;
                    MaxHealth = 85;
                    Gold = 1500;
                    break;

                case "도적":
                    Level = 1;
                    Attack = 20;
                    Deffense = 6;
                    Health = 100;
                    MaxHealth = 100;
                    Gold = 1500;
                    break;

                case "궁수":
                    Level = 1;
                    Attack = 21;
                    Deffense = 5;
                    Health = 100;
                    MaxHealth = 100;
                    Gold = 1500;
                    break;
            }
        }*/

        public void SetStatus () //직업에 따라 다른 스테이터스 세팅
        {
            PotionCount = 3; // 포션 3개 설정

            switch (Job)
            {
                case "전사":
                    Level = 1;
                    Attack = 17;
                    Deffense = 8;
                    Health = 120;
                    MaxHealth = 120;
                    Mana = 50;
                    MaxMana = 50;
                    Gold = 1500;
                    break;

                case "마법사":
                    Level = 1;
                    Attack = 23;
                    Deffense = 5;
                    Health = 85;
                    MaxHealth = 85;
                    Mana = 80;
                    MaxMana = 80;
                    Gold = 1500;
                    break;

                case "도적":
                    Level = 1;
                    Attack = 20;
                    Deffense = 6;
                    Health = 100;
                    MaxHealth = 100;
                    Mana = 50;
                    MaxMana = 50;
                    Gold = 1500;
                    break;

                case "궁수":
                    Level = 1;
                    Attack = 21;
                    Deffense = 5;
                    Health = 100;
                    MaxHealth = 100;
                    Mana = 50;
                    MaxMana = 50;
                    Gold = 1500;
                    break;
            }
        }

>>>>>>> Stashed changes

        public void Info()
        {
            Console.WriteLine($"Lv. {Level}");
            Console.WriteLine($"{Name} ( {Job} )");
            Console.WriteLine($"공격력 : {Attack}");
            Console.WriteLine($"방어력 : {Deffense}");
            Console.WriteLine($"현재 체력 : {Health}");
            Console.WriteLine($"최대 체력 : {MaxHealth}");
            Console.WriteLine($"Gold : {Gold} G");
        }

        public int PlayerAttack()
        {
            Random rand = new Random();

            int damage = 0;
            double difference = 0;
            difference = Math.Ceiling(Attack * 0.1);
            damage = rand.Next((int)Attack - (int)difference, (int)Attack + (int)difference + 1);

            return damage;
        }
    }
}
