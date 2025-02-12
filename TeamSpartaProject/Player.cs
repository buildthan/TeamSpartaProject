﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
        public string  Job { get; set; }
        public double Attack { get; set; }
        public double Deffense { get; set; }
        public double Health { get; set; }
        public double MaxHealth { get; set; }
        public double Gold { get; set; }

        public Player(int level, float attack, float deffense, float health, float maxHealth, float gold)
        {
            
            Level = level;             
            Attack = attack;
            Deffense = deffense;
            Health = health; //현재 체력
            MaxHealth = maxHealth;//최대 체력
            Gold = gold;            
        }
      

        public Player(string name, string job)
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
        }


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
