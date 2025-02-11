using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
        public double Mana { get; set; } // 현재 MP
        public double MaxMana { get; set; } // 최대 MP
        public double Gold { get; set; }        
        public bool iscritical = false; // 치명타 발동 여부
        public bool isevade = false; // 공격이 적중했는지 여부
        public double Alphacount { get; set; } // 알파스킬 사용횟수
        public double Doublecount { get; set; } // 더블스킬 사용횟수

        public Player(string name, int level, string job, float attack, float deffense, float health, float maxHealth, float mana, float maxMana, float gold)
        {
            Name = name;
            Level = level;
            Job = job; 
            Attack = attack;
            Deffense = deffense;
            Health = health; //현재 체력
            MaxHealth = maxHealth;//최대 체력
            Mana = mana; ; // 현재 MP
            MaxMana = maxMana; // 최대 MP
            Gold = gold;
            iscritical = false;
            isevade = false;
            Alphacount = 0;
            Doublecount = 0;
        }

        public void Info()
        {
            Console.WriteLine($"Lv. {Level}");
            Console.WriteLine($"{Name} ( {Job} )");
            Console.WriteLine($"공격력 : {Attack}");
            Console.WriteLine($"방어력 : {Deffense}");
            Console.WriteLine($"현재 체력 : {Health}");
            Console.WriteLine($"최대 체력 : {MaxHealth}");
            Console.WriteLine($"현재 마나 : {Mana}");
            Console.WriteLine($"최대 마나 : {MaxMana}");
            Console.WriteLine($"Gold : {Gold} G");
        }

        public int PlayerAttack()
        {
            Random rand = new Random();

            int damage = 0;
            double difference = 0;
            difference = Math.Ceiling(Attack * 0.1);
            damage = rand.Next((int)Attack - (int)difference, (int)Attack + (int)difference + 1);
                    
            
            Random atktyperand = new Random();
            int atktypep = atktyperand.Next(0, 100);

            if (atktypep >= 0 && atktypep < 15) // 치명타 기능 : 공격 시 15%의 확률로 160% 데미지의 치명타 발생
            {
                iscritical = true;
                damage = (int)(damage * 1.6);                
            }
            else if(atktypep >= 90 && atktypep < 100) // 회피 기능 : 공격 시 10%의 확률로 공격 적중 실패
            {
                isevade = true;
                damage = 0;
            }
            else
            {
                isevade = false;
                iscritical = false;                
            }

            return damage;           
        }

        public int SkillAttack() // 스킬 공격 시 데미지(default 기본데미지, 스킬에 따라 계산해서 사용), 치명타 가능, 회피 불가
        {
            Random rand = new Random();

            int damage = 0;
            double difference = 0;
            difference = Math.Ceiling(Attack * 0.1);
            damage = rand.Next((int)Attack - (int)difference, (int)Attack + (int)difference + 1);


            Random atktyperand = new Random();
            int atktypep = atktyperand.Next(0, 100);

            if (atktypep >= 0 && atktypep < 15) // 치명타 기능 : 공격 시 15%의 확률로 160% 데미지의 치명타 발생
            {
                iscritical = true;
                damage = (int)(damage * 1.6);
            }            
            else
            {                
                iscritical = false;
            }
            return damage;
        }

        public string PrintAtkType() // 치명타 시 출력 문구
        {
            string prtatktype = "";

            if (iscritical == true)
            {
                prtatktype = " - 치명타 공격!!";               
            }
            else
            {
                prtatktype = "";               
            }

            return prtatktype;
        }
    }
}
