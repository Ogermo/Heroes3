using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Writer
{
    public int Compare(BattleUnitStack x, BattleUnitStack y)
    {
        if (x.curInitiative == 0 || y.curInitiative == 0)
        {
            return 0;
        }

        // CompareTo() method 
        return y.curInitiative.CompareTo(x.curInitiative);

    }
    public void MainInfo(List<BattleUnitStack> queue,BattleArmy BLUE,BattleArmy RED)
    {
        int BLUEcount = BLUE.Description.Count;
        int REDcount = RED.Description.Count;
        int max = Math.Max(BLUEcount,REDcount);
        string str1 ="";
        string str2 ="";
        string write = "";
        double Alive; 
        for (int i=0; i < max; i++)
        {
            str1 = "";
            str2 = "";
            if (i < BLUEcount)
            {
                Alive = (double)BLUE.Description[i].curHitPoints / BLUE.Description[i].minion.HitPoints;
                Alive = Math.Ceiling(Alive);
                str1 = $"{BLUE.Description[i].ID}:{BLUE.Description[i].minion.Type}:{Alive}";
            }
            if (i < REDcount)
            {
                Alive = (double)RED.Description[i].curHitPoints / RED.Description[i].minion.HitPoints;
                Alive = Math.Ceiling(Alive);
                str2 = $"{RED.Description[i].ID}:{RED.Description[i].minion.Type}:{Alive}";
            }
            write = String.Format("{0} {1}", str1.PadRight(20), str2.PadRight(20));
            Console.WriteLine(write);
        }
        //Console.Clear();

        Console.WriteLine("v - you're here");
        ShowQueue(queue);
        Console.WriteLine();

    }

    public void YourTurn(BattleUnitStack stack)
    {
        Console.WriteLine($"Your turn: {stack.Side}, choose your action\n" +
            $"1.Attack\n" +
            $"2.Cast\n" +
            $"3.Wait\n" +
            $"4.Defend\n" +
            $"5.Give up\n" +
            $"6.Show stats\n");
    }

    public void Target(string side)
    {
        if (side == "enemy") {
            Console.WriteLine("Choose enemy target");
                }
        if (side == "ally")
        {
            Console.WriteLine("Choose ally target");
        }
        if (side == "any")
        {
            Console.WriteLine("Choose any target");
        }
    }

    public void ShowQueue(List<BattleUnitStack> queue)
    {
        int first = 1;
        List<BattleUnitStack> SecondQueue = new List<BattleUnitStack>(queue);
        SecondQueue.Sort(Compare);
        foreach (BattleUnitStack u in queue)
        {
            if (u.queueInitiative != -900)
            {
                if (first == 1)
                {
                    Console.Write($"{u.ID}:{u.minion.Type} ");
                    first = 0;
                }
                else
                {
                    Console.Write($"-> {u.ID}:{u.minion.Type} ");
                }
            }
        }
        Console.Write("|");
        first = 1;
        foreach (BattleUnitStack u in SecondQueue)
        {
            if (first == 1)
            {
                Console.Write($"{u.ID}:{u.minion.Type} ");
                first = 0;
            }
            else
            {
                Console.Write($"-> {u.ID}:{u.minion.Type} ");
            }
        }
        Console.WriteLine();
    }
}