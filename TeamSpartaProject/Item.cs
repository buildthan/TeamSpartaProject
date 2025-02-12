<<<<<<< Updated upstream
﻿usinusing System;
using System.Collections.Generic;
using TeamProject;


namespace TeamProject;

class Item
{
    // 아이템 필요 정보 변수 선언(get 접근, set 저장)
    public string Name { get; set; }
    public int Effect { get; set; }
    public string Info { get; set; }
    public string ItemType { get; set; } //회복
    public bool IsEquip { get; set; }
}

    //초기화(생성자)
public Item(string name, int effect, string info, string itemType, bool isEquip)
    {
        Name = name;
        Effect = effect;
        Info = info;
        ItemType = itemType;
        IsEquip = isEquip;
    }

    // 오버라이드
    public override string ToString()
    {
        return $"Name: {Name}, Effect: {Effect}, Info: {Info}, ItemType: {ItemType}, IsEquip: {IsEquip}";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // 체력
        double currentHealth = 100;
        double maxHealth = 100;

        // 아이템 리스트
        List<Item> itemList = new List<Item>
        {
            new Item("체력 물약", 10, "체력을 10 회복합니다.", "회복", false),
            new Item("충전형 물약", 15, "체력을 15 회복합니다.", "회복", false),
            new Item("루비 수정", 20, "체력을 20 회복합니다.", "회복", false),
            new Item("요정의 부적", 25, "체력을 25 회복합니다.", "회복", false),
            new Item("원기 회복의 구슬", 30, "체력을 30 회복합니다.", "회복", false)

        };

        // 아이템 사용 프로세스
        foreach (var item in itemList)
        {
            Console.WriteLine(item);

            if (item.ItemType == "회복")
            {
                if (currentHealth < maxHealth)
                {
                    double healAmount = Math.Min(item.Effect, maxHealth - currentHealth);
                    currentHealth += healAmount;
                    Console.WriteLine($"{item.Name} 사용: 체력이 {healAmount}만큼 회복되어 현재 체력은 {currentHealth}/{maxHealth}입니다.");
                }
                else
                {
                    Console.WriteLine($"{item.Name} 사용 불가: 체력이 이미 꽉 찼습니다.");
                }
            }

        }
    }
=======
﻿using System;

namespace SpartanTeamProject
{
    class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Item(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }

    class Potion : Item
    {
        public int HealAmount { get; set; } = 30;

        public Potion() : base("회복 포션", "체력을 30 회복할 수 있습니다.") { }
    }
>>>>>>> Stashed changes
}