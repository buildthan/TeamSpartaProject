
using System.Runtime.Serialization.Formatters.Binary;
using SpartanTeamProject;
using Newtonsoft.Json;

namespace TeamProject;

class Program
{
    static void Main(string[] args)
    {
        GameManager gm = new GameManager(); //생성자를 이용해 시작 데이터 세팅
        gm.MainScreen();
    }

}

class GameManager
{
    Player player;
    List<Monster> monsterList;
    List<Monster> battleList;

    public GameManager()
    {
        player = new Player(
            "Chad", //플레이어 이름
            1, //플레이어 레벨
            "전사", //플레이어 직업
            20, //플레이어 공격력
            5, //플레이어 방어력
            100, //플레이어 현재체력
            100, //플레이어 최대체력
            1500 //플레이어 소지골드
            );

        monsterList = new List<Monster>
        {
            new Monster
            (
                "미니언", //이름
                2, //레벨
                15, //현재 체력
                15, //최대 체력
                5 //공격력
             ),
            new Monster
            (
                "공허충", //이름
                3, //레벨
                10, //현재 체력
                10, //최대 체력
                9 //공격력
             ),
            new Monster
            (
                "대포미니언", //이름
                5, //레벨
                25, //현재 체력
                25, //최대 체력
                8 //공격력
             ),
            new Monster
            (
                "바론", //이름
                10, //레벨
                30, //현재 체력
                30, //최대 체력
                10 //공격력
             ),

        };
    }

    public static T DeepClone<T>(T obj) //리스트 값을 참조하지 않고 복사해오기 위한 매서드
    {
        string jsonString = JsonConvert.SerializeObject(obj);
        return JsonConvert.DeserializeObject<T>(jsonString);
    }

    public void MainScreen() //메인메뉴
    {
        Console.Clear();
        Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
        Console.WriteLine("이제 전투를 시작할 수 있습니다.");
        Console.WriteLine("");
        Console.WriteLine("1. 상태 보기");
        Console.WriteLine("2. 전투 시작");
        Console.WriteLine("");
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        Console.WriteLine("");

        int input = ConsoleUtility.GetInput(1, 2);

        switch(input)
        {
            case 1:
                StatusScreen(player); //1. 상태보기
                break;
            case 2:
                BattleScreen(); //2. 전투시작
                break;
        
        }

    }


    public void StatusScreen(Player player) //상태보기 창
    {
        Console.Clear();
        Console.WriteLine("상태 보기");
        Console.WriteLine("캐릭터의 정보가 표시됩니다.");
        Console.WriteLine("");
        player.Info();
        Console.WriteLine("");
        Console.WriteLine("0. 나가기");
        Console.WriteLine("");
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        Console.WriteLine("");

        int input = ConsoleUtility.GetInput(0, 0);

        switch (input)
        {
            case 0:
                MainScreen(); //0. 나가기
                break;

        }

    }

    public void BattleScreen() //전투하기 창
    {
        Random rand = new Random();
        battleList = new List<Monster>(); //배틀리스트를 비워줍니다.
        int monsterCount = rand.Next(1,5); //1~4의 랜덤값 배정

        Console.Clear();
        Console.WriteLine("Battle!!");
        Console.WriteLine("");

        //여기서 나타난 몬스터 종류 출력
        for (int i = 0; i < monsterCount; i++)
        {
            int whichMonster = rand.Next(0, monsterList.Count);

            //battleList.Add( monsterList[whichMonster]);
            battleList.Add(DeepClone(monsterList[whichMonster]));

            if (battleList[i].Health == 0) //몬스터가 죽었다면
            {
                ConsoleUtility.ForegroundColor_DarkGray($"{i + 1} Lv.{battleList[i].Level} {battleList[i].Name} Dead");
            }
            else
            {
                Console.WriteLine($"{i + 1} Lv.{battleList[i].Level} {battleList[i].Name} HP {battleList[i].Health}");

            }
        }

        Console.WriteLine("");

        //내정보 출력
        Console.WriteLine("[내정보]");
        Console.WriteLine($"Lv.{player.Level} {player.Name} ({player.Job})");
        Console.WriteLine($"HP {player.Health}/{player.MaxHealth}");

        Console.WriteLine("");
        Console.WriteLine("1. 공격");
        Console.WriteLine("");
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        Console.WriteLine("");

        int input = ConsoleUtility.GetInput(1,1);

        switch (input)
        {
            case 1:
                AttackScreen(); //1. 공격
                break;

        }
    }

    public void AttackScreen()//공격하기 창
    {
        Console.Clear();
        Console.WriteLine("Battle!!");
        Console.WriteLine("");

        //여기서 나타난 몬스터 종류 출력
        for (int i = 0; i < battleList.Count; i++)
        {
            if (battleList[i].Health == 0) //몬스터가 죽었다면
            {
                ConsoleUtility.ForegroundColor_DarkGray($"{i+1} Lv.{battleList[i].Level} {battleList[i].Name} Dead");
            }
            else //몬스터가 살아있다면
            {
                Console.WriteLine($"{i + 1} Lv.{battleList[i].Level} {battleList[i].Name} HP {battleList[i].Health}");
            }
        }

        Console.WriteLine("");

        //내정보 출력
        Console.WriteLine("[내정보]");
        Console.WriteLine($"Lv.{player.Level} {player.Name} ({player.Job})");
        Console.WriteLine($"HP {player.Health}/{player.MaxHealth}");

        Console.WriteLine("");
        Console.WriteLine("0. 취소");
        Console.WriteLine("");
        Console.WriteLine("대상을 선택해주세요.");
        Console.WriteLine("");

        
        while (true)
        
        {
            int input = ConsoleUtility.GetInput(0, battleList.Count);

            if (input == 0) //취소를 눌렀다면
            {
                EnemyPhase();
                break;
                //바로 Enemy Phase 시작
            }
            else if (battleList[input - 1].Health <= 0) //이미 죽은 대상을 골랐다면
            {
                Console.WriteLine();
                Console.WriteLine("이미 죽은 대상입니다. 다시 입력해주십시오.");
                Console.WriteLine();
                continue;
            }
            else //대상을 올바르게 선택했다면
            {
                //공격 결과창 출력
                AttackResultScreen(input);
                break;
            }
        }
    }

    public void AttackResultScreen(int input) //공격 결과창
    {
        int enemy_down_count = 0;

        Random rand = new Random();
        Console.Clear();
        Console.WriteLine("Battle!!");
        Console.WriteLine("");
        Console.WriteLine($"{player.Name} 의 공격!");

        int damage = player.PlayerAttack();
            
        Console.WriteLine($"Lv.{battleList[input-1].Level} {battleList[input-1].Name} 을(를) 맞췄습니다. [데미지 : {damage}]");
        Console.WriteLine("");
        Console.WriteLine($"Lv.{battleList[input - 1].Level} {battleList[input - 1].Name}");
        Console.Write($"HP {battleList[input-1].Health} -> ");
        battleList[input - 1].Health = battleList[input - 1].Health - damage;
        if(battleList[input - 1].Health <= 0)
        {
            battleList[input - 1].Health = 0;
            ConsoleUtility.ForegroundColor_DarkGray("Dead");
        }
        else
        {
            Console.WriteLine($"{battleList[input-1].Health}");
        }
        Console.WriteLine("");
        Console.WriteLine("0.다음");
        Console.WriteLine("");

        for(int i = 0; i<battleList.Count; i++) //적들이 얼마나 쓰러졌는지 체크
        {
            if(battleList[i].Health <= 0)
            {
                enemy_down_count++;
            }
        }

        int Input = ConsoleUtility.GetInput(0,0);

        while (true)
        {
            if (enemy_down_count == battleList.Count) //적들이 모두 쓰러졌다면
            {
                //Victory 결과창 출력
                Victory();
                break;
            }

            if (player.Health <= 0) //플레이어 체력이 바닥이 났다면
            {
                //Lose 결과창 출력
                Lose();
                break;
            }

            if (player.Health > 0) //플레이어 체력이 여전히 남아있다면
            {
                EnemyPhase(); //적 공격 차례 시작
                break;
            }
        }
    }

    public void EnemyPhase() //적의 공격 차례
    {
        int enemy_down_count = 0;

        for (int i = 0; i<battleList.Count; i++) //적의 개수만큼 반복
        {
            if (battleList[i].Health <= 0) //죽은 적이 있다면 스킵
            {
                continue;
            }

            Console.Clear();
            Console.WriteLine("Battle!!");
            Console.WriteLine("");
            Console.WriteLine($"Lv. {battleList[i].Level} {battleList[i].Name} 의 공격!");

            int damage = battleList[i].MonsterAttack();

            Console.WriteLine($"{player.Name} 을/를 맞췄습니다. [데미지 : {damage}]");
            Console.WriteLine("");
            Console.WriteLine($"Lv. {player.Level} {player.Name}");
            Console.Write($"HP {player.Health} -> ");
            player.Health = player.Health - damage;
            if (player.Health <= 0)
            {
                player.Health = 0;
                ConsoleUtility.ForegroundColor_DarkGray("Dead");
            }
            else
            {
                Console.WriteLine($"{player.Health}");
            }
            Console.WriteLine("");
            Console.WriteLine("0.다음");
            Console.WriteLine("");

            int Input = ConsoleUtility.GetInput(0, 0);

            if (player.Health <= 0) //플레이어가 맞아 쓰러졌다면 바로 게임 종료
            {
                break;
            }

        }

        for (int i = 0; i < battleList.Count; i++) //적들이 얼마나 쓰러졌는지 체크
        {
            if (battleList[i].Health <= 0)
            {
                enemy_down_count++;
            }
        }

        while (true)
        {
            if (enemy_down_count == battleList.Count) //적들이 모두 쓰러졌다면
            {
                //Victory 결과창 출력
                Victory();
                break;
            }

            if (player.Health <= 0) //플레이어 체력이 바닥이 났다면
            {
                //Lose 결과창 출력
                Lose();
                break;
            }

            if (player.Health > 0) //플레이어 체력이 여전히 남아있다면
            {
                AttackScreen(); //플레이어 차례로 복귀
                break;
            }
        }
    }

    public void Victory()
    {
        Console.Clear();

        Console.WriteLine("Battle!! - Result");
        Console.WriteLine("");
        Console.WriteLine("Victory");
        Console.WriteLine("");
        Console.WriteLine($"던전에서 몬스터 {battleList.Count}마리를 잡았습니다.");
        Console.WriteLine("");
        Console.WriteLine($"Lv. {player.Level} {player.Name}");
        Console.WriteLine($"HP {player.MaxHealth} -> {player.Health}");
        Console.WriteLine("");
        Console.WriteLine("0.다음");
        Console.WriteLine("");

        int Input = ConsoleUtility.GetInput(0, 0);

        player.Health = player.MaxHealth; // 메인화면으로 돌아가기 전에 체력 회복해줌.
        MainScreen();
    }

    public void Lose()
    {
        Console.Clear();

        Console.WriteLine("Battle!! - Result");
        Console.WriteLine("");
        Console.WriteLine("You Lose");
        Console.WriteLine("");
        Console.WriteLine($"Lv. {player.Level} {player.Name}");
        Console.WriteLine($"HP {player.MaxHealth} -> {player.Health}");
        Console.WriteLine("");
        Console.WriteLine("0.다음");
        Console.WriteLine("");

        int Input = ConsoleUtility.GetInput(0, 0);

        player.Health = player.MaxHealth; //메인화면으로 돌아가기 전에 체력 회복해줌.
        MainScreen();
    }

}