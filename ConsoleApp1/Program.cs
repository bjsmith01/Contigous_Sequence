using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{
    static void Main(String[] args)
    {
        Console.WriteLine("Hello World!");
        Console.WriteLine("This is a fully functioning C# environment.");


        String[] user0 = { "/start", "/green", "/blue", "/pink", "/register", "/orange", "/one/two" };
        String[] user1 = { "/start", "/pink", "/register", "/orange", "/red", "a" };
        String[] user2 = { "a", "/one", "/two" };
        String[] user3 = { "/pink", "/orange", "/yellow", "/plum", "/blue", "/tan", "/red", "/amber", "/HotRodPink", "/CornflowerBlue", "/LightGoldenRodYellow", "/BritishRacingGreen" };
        String[] user4 = { "/pink", "/orange", "/amber", "/BritishRacingGreen", "/plum", "/blue", "/tan", "/red", "/lavender", "/HotRodPink", "/CornflowerBlue", "/LightGoldenRodYellow" };
        String[] user5 = { "a" };
        String[] user6 = { "/pink", "/orange", "/six", "/plum", "/seven", "/tan", "/red", "/amber" };


        var res = findContiguousHistory(user3, user6);
        foreach(var s in res)
        {
            Console.WriteLine(s);
        }
        Console.ReadLine();
    }

    static string[] findContiguousHistory(IEnumerable<string> u1, IEnumerable<string> u2)
    {
        var u1Len = u1.Count();
        var u2Len = u2.Count();
        List<string> shortList;
        List<string> longList;
        List<List<(string, int)>> history = new List<List<(string, int)>>();

        if (u1Len > u2Len)
        {
            shortList = u2.ToList();
            longList = u1.ToList();
        }
        else
        {
            shortList = u1.ToList();
            longList = u2.ToList();
        }

        string val;
        string val2;

        List<(string key, int)> tempHistory = new List<(string key, int)>();
        int lPos = 0;
        for (int pos = 0; pos < shortList.Count(); pos++)
        {
            val = shortList[pos];
            if (longList.Contains(val)) {
                for (int pos2 = lPos; pos2 < longList.Count(); pos2++)
                {
                    val2 = longList[pos2];
                    if (val == val2)
                    {
                        tempHistory.Add((val, pos));
                        lPos = pos2 + 1;
                        break;
                    }
                    history.Add(tempHistory);
                    tempHistory = new List<(string key, int)>();
                }
            }
            else
            {
                history.Add(tempHistory);
                tempHistory = new List<(string key, int)>();
                lPos = 0;
            }

        }

        if (tempHistory.Any())
        {
            history.Add(tempHistory);
        }

        return history.OrderByDescending(l => l.Count())?.FirstOrDefault()?.Select(s => s.Item1).ToArray();
    }
}