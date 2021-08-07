using System;
using System.Collections.Generic;
using System.Linq;

class Solution {
    static void Main(String[] args) {
        Console.WriteLine("Hello World!");
        Console.WriteLine("This is a fully functioning C# environment.");
        
        
        String[] user0 = {"/start", "/green", "/blue", "/pink", "/register", "/orange", "/one/two"};
        String[] user1 = {"/start", "/pink", "/register", "/orange", "/red", "a"};
        String[] user2 = {"a", "/one", "/two"};
        String[] user3 = {"/pink", "/orange", "/yellow", "/plum", "/blue", "/tan", "/red", "/amber", "/HotRodPink", "/CornflowerBlue", "/LightGoldenRodYellow", "/BritishRacingGreen"};
        String[] user4 = {"/pink", "/orange", "/amber", "/BritishRacingGreen", "/plum", "/blue", "/tan", "/red", "/lavender", "/HotRodPink", "/CornflowerBlue", "/LightGoldenRodYellow"};
        String[] user5 = {"a"};
        String[] user6 = {"/pink","/orange","/six","/plum","/seven","/tan","/red", "/amber"};        
        
    }
    
    static string[] findContiguousHistory(string[] u1, string[] u2){
        var u1Len = u1.Count();
        var u2Len = u2.Count();
        string[] shortList;
        string[] longList;
        List<((string,int))[]> history = new List<((string,int)[]) >();
        
        if (u1Len > u2Len){
            shortList = u2;
            longList = u1;
        }
        else{
            shortList = u1;
            longList = u2;
        }
        
        string val;
        string val2;
        
        List<(string key,int)> tempHistory;
        int lPos = 0;
        for (int pos = 0; pos < shortList.Count(); pos ++){
            tempHistory = new List<(string key,int)>();
            val = shortList[pos];
            for (int pos2 = lPos; pos2 < longList.Count(); pos2++){
                val2 = longList[pos2];
                if (val == val2){
                    tempHistory.Add((val,pos));
                    lPos = pos2++;
                    continue;
                }          
                else{
                    history.Add(tempHistory.ToArray());
                }
            }            
        }
        
        
        
        return history.OrderByDescending(l=> l.Count()).Select(s => s.item1).ToArray();
    }
}



/*

We have some clickstream data that we gathered on our client's website. Using cookies, we collected snippets of users' anonymized URL histories while they browsed the site. The histories are in chronological order, and no URL was visited more than once per person.

Write a function that takes two users' browsing histories as input and returns the longest contiguous sequence of URLs that appears in both.

Sample input:

user0 = ["/start", "/green", "/blue", "/pink", "/register", "/orange", "/one/two"]
user1 = ["/start", "/pink", "/register", "/orange", "/red", "a"]
user2 = ["a", "/one", "/two"]
user3 = ["/pink", "/orange", "/yellow", "/plum", "/blue", "/tan", "/red", "/amber", "/HotRodPink", "/CornflowerBlue", "/LightGoldenRodYellow", "/BritishRacingGreen"]
user4 = ["/pink", "/orange", "/amber", "/BritishRacingGreen", "/plum", "/blue", "/tan", "/red", "/lavender", "/HotRodPink", "/CornflowerBlue", "/LightGoldenRodYellow"]
user5 = ["a"]
user6 = ["/pink","/orange","/six","/plum","/seven","/tan","/red", "/amber"]

Sample output:

findContiguousHistory(user0, user1) => ["/pink", "/register", "/orange"]
findContiguousHistory(user0, user2) => [] (empty)
findContiguousHistory(user0, user0) => ["/start", "/green", "/blue", "/pink", "/register", "/orange", "/one/two"]
findContiguousHistory(user2, user1) => ["a"] 
findContiguousHistory(user5, user2) => ["a"]
findContiguousHistory(user3, user4) => ["/plum", "/blue", "/tan", "/red"]
findContiguousHistory(user4, user3) => ["/plum", "/blue", "/tan", "/red"]
findContiguousHistory(user3, user6) => ["/tan", "/red", "/amber"]

n: length of the first user's browsing history
m: length of the second user's browsing history



*/
