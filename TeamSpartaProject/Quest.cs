using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartanTeamProject
{
    public class Quest
    {
        public string Title {  get; set; } //퀘스트 제목
        public string Explanation { get; set; }// 퀘스트 설명
        public bool IsClear {  get; set; } //퀘스트 클리어 여부
        public bool IsAccept { get; set; } //퀘스트 승낙 여부
        public int CompletionCondition { get; set; } //완료 조건
        public int NowCondition {  get; set; } //현재 진행도
        public string WhichMonster { get; set; } //잡아야 하는 몬스터 이름
        public int Reward { get; set; }

        public Quest (string title, string explanation, bool isClear, bool isAccept, int completionCondition, int nowCondition, string whichMonster, int reward)
        {
            Title = title;
            Explanation = explanation;
            IsClear = isClear;
            IsAccept = isAccept;
            CompletionCondition = completionCondition;
            NowCondition = nowCondition;
            WhichMonster = whichMonster;
            Reward = reward;
        }

        public void printInfo()
        {
            Console.WriteLine(Title);
            Console.WriteLine("");
            Console.WriteLine(Explanation);
            Console.WriteLine("");
            Console.WriteLine($"- {WhichMonster} {CompletionCondition}마리 처치 ({NowCondition}/{CompletionCondition})");
            Console.WriteLine("");
            Console.WriteLine("-보상-");
            Console.WriteLine($"{Reward}G");

        }
    }
}
