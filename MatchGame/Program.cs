// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Welcome to 357 gmae!");

int[] matchGroup = { 3, 5, 7 };
int[] canSelect = { 1, 1, 1 };
int totalRestCount = 15;
bool isLastGroup = false;
int lastGroupIndex = 3;
Random groupRD = new Random();

int loop = 0;
while (true)
{
   
    int contestant = loop%2+1;
  

    //select a group
    int groupIndex = isLastGroup ? lastGroupIndex: groupRD.Next(0, 3);
    int groupName = groupIndex + 1;


    if (canSelect[groupIndex] == 0)
    {
        continue;
    }
   

    Console.WriteLine("————————-参赛者" + contestant + "开始选--------------");

    Console.WriteLine("————————-参赛者" + contestant + "选了"+ groupName + "组--------------");

    //select match count  to take off
    int restCount = matchGroup[groupIndex];
    int takeoffCount = groupRD.Next(1, restCount+1);
    Console.WriteLine("————————-参赛者" + contestant + "选了" + groupName + "组,取走了"+ takeoffCount + "根火柴-----------");
    matchGroup[groupIndex]=  matchGroup[groupIndex] - takeoffCount;


    totalRestCount = totalRestCount - takeoffCount;

    // check the contest result;
    if (totalRestCount == 0)
    {
        Console.WriteLine("————————-参赛者" + contestant + "输了比赛");
        break;
    }

    // Check if the last group is left

    if (matchGroup[groupIndex] == 0)
    {
        canSelect[groupIndex] = 0;
       
        lastGroupIndex = lastGroupIndex - groupIndex;
        var emptyGroupCount = canSelect.Where((n, index) => n == 0).Count();
        isLastGroup = emptyGroupCount >= 2 ? true : false;

    }
    loop++;

}
