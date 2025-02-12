using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace SpartanTeamProject
{

    

    public class Player
    {
        public string Name { get; set; } = "";
        public int Level { get; set; }
        public string Job { get; set; } = "";
        public double Attack { get; set; }
        public double Deffense { get; set; }
        public double Health { get; set; }
        public double MaxHealth { get; set; }
        public int Exp { get; set; } // 경험치
        public int ExpNextLevel { get; set; } // 추가 경험치
        public double Gold { get; set; }
        public double Mana { get; set; } // 현재 MP
        public double MaxMana { get; set; } // 최대 MP
        public bool iscritical = false; // 치명타 발동 여부
        public bool isevade = false; // 공격이 적중했는지 여부
        public double Alphacount { get; set; } // 알파스킬 사용횟수
        public double Doublecount { get; set; } // 더블스킬 사용횟수
        public int NowStage { get; set; } //현재 공략중인 던전 스테이지


        public Player(int level, float attack, float deffense, float health, float maxHealth, float mana, float maxMana,int exp, int expNextLevel, float gold)
        {

            Level = level;             
            Attack = attack;
            Deffense = deffense;
            Health = health; //현재 체력
            MaxHealth = maxHealth;//최대 체력
            Exp = exp; // 경험치
            ExpNextLevel = expNextLevel; // 추가 경험치
            Mana = mana; ; // 현재 MP
            MaxMana = maxMana; // 최대 MP
            Gold = gold;
            iscritical = false;
            isevade = false;
            Alphacount = 0;
            Doublecount = 0;
            NowStage = 1;
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


        // 레벨업 메서드
        private void LevelUp()
        {
            Level++;
            Attack += 0.5;  // 레벨업 시 공격력 증가
            Deffense += 1;   // 레벨업 시 방어력 증가
            Exp -= ExpNextLevel;  // 레벨업 후 경험치 초기화
            ExpNextLevel = (int)(ExpNextLevel * 3.5);  // 다음 레벨업까지 필요한 경험치 증가
            Console.WriteLine($"{Name}이(가) 레벨 {Level}로 상승했습니다!");
        }
        // 몬스터 처치 후 경험치 추가
        public void GainExp(int exp)
        {
            Exp += exp;
            Console.WriteLine("");
            Console.WriteLine($"획득한 경험치: {exp}");
            Console.WriteLine($"현재 경험치: {Exp}");
            Console.WriteLine("");
            if (Exp >= ExpNextLevel) // 경험치가 목표를 넘으면 레벨업 처리
            {
                LevelUp();
            }
        }
        // 골드 획득 메서드
        public void GainGold(int amount)
        {
            Gold += amount;
            Console.WriteLine($"{amount} G을 획득했습니다! 현재 골드: {Gold} G");
            Console.WriteLine("");
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
