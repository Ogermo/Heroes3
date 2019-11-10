using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Battle
{
    Writer writer = new Writer(); //operrator
    Random random = new Random(); //randomizer
    public BattleArmy BLUE;
    public BattleArmy RED;
    public ArmyClass SaveBLUE;
    public ArmyClass SaveRED; //Used after battle to change sides CrusadeArmy

    public List<BattleUnitStack> ArmyQueue = new List<BattleUnitStack>();
    BattleUnitStack curStack;

    private int setID = 0; // grow each time new stack summoned

    public int Compare(BattleUnitStack x, BattleUnitStack y)
    {
        // CompareTo() method 
        return y.queueInitiative.CompareTo(x.queueInitiative);

    }
    public bool First(BattleUnitStack x)
    {
        if (x.queueInitiative == -900)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    int findID = 0;
    public bool Find(BattleUnitStack x)
    {
        if (x.ID == findID)
        {
            return true;
        }
        return false;
    }

    public Battle(ArmyClass initBLUE, ArmyClass initRED)
    {
        BLUE = new BattleArmy(initBLUE);
        foreach (BattleUnitStack u in BLUE.Description)
        {
            u.setID(setID);
            setID = setID + 1;
            u.setSide("BLUE");
            u.setCounter(1);
            u.setIsWaited(0);
        }
        RED = new BattleArmy(initRED);
        foreach (BattleUnitStack u in RED.Description)
        {
            u.setID(setID);
            setID = setID + 1;
            u.setSide("RED");
            u.setCounter(1);
            u.setIsWaited(0);
        }
        SaveBLUE = initBLUE;
        SaveRED = initRED;
        ArmyQueue.AddRange(BLUE.Description);
        ArmyQueue.AddRange(RED.Description);
        ArmyQueue.Sort(Compare);
        GameLoop();
    }

    public void ShowInfo()
    {
        writer.MainInfo(ArmyQueue, BLUE, RED);
    }

    private bool isThereTurn()
    {
        return ArmyQueue.Exists(First);
    }

    private void Refresh()
    {
        ArmyQueue.Clear();
        ArmyQueue.AddRange(BLUE.Description);
        ArmyQueue.AddRange(RED.Description);
        ArmyQueue.Sort(Compare);
    }
    private void attack(BattleUnitStack attacker, BattleUnitStack defender)
    {
        double defence = defender.curDefence;
        double Alive = (double)attacker.curHitPoints / attacker.minion.HitPoints;
        Alive = Math.Ceiling(Alive);
        int minDamage;
        int maxDamage;
        int damage;
        if (defender.isDefend == 1)
        {
            defence = Math.Ceiling(defender.curDefence * 1.3);
        }
        if (attacker.curAttack >= defence)
        {
            minDamage = Convert.ToInt32(Alive * attacker.minion.MinDamage * (1 + 0.05 * (attacker.curAttack - defence)));
            maxDamage = Convert.ToInt32(Alive * attacker.minion.MaxDamage * (1 + 0.05 * (attacker.curAttack - defence)));
            damage = random.Next(minDamage, maxDamage);
        }
        else
        {
            minDamage = Convert.ToInt32(Alive * attacker.minion.MinDamage * (1 + 0.05 / (defence - attacker.curAttack)));
            maxDamage = Convert.ToInt32(Alive * attacker.minion.MaxDamage * (1 + 0.05 / (defence - attacker.curAttack)));
            damage = random.Next(minDamage, maxDamage);
        }
        defender.changeHealth(-damage);
        if ((defender.curHitPoints != 0) && (defender.counter != 0)) //counter
        {
            Alive = (double)defender.curHitPoints / defender.minion.HitPoints;
            Alive = Math.Ceiling(Alive);
            if (defender.curAttack >= attacker.curDefence)
            {
                minDamage = Convert.ToInt32(Alive * defender.minion.MinDamage * (1 + 0.05 * (defender.curAttack - defence)));
                maxDamage = Convert.ToInt32(Alive * defender.minion.MaxDamage * (1 + 0.05 * (defender.curAttack - defence)));
                damage = random.Next(minDamage, maxDamage);
            }
            else
            {
                minDamage = Convert.ToInt32(Alive * defender.minion.MinDamage * (1 + 0.05 / (defence - defender.curAttack)));
                maxDamage = Convert.ToInt32(Alive * defender.minion.MaxDamage * (1 + 0.05 / (defence - defender.curAttack)));
                damage = random.Next(minDamage, maxDamage);
            }
            attacker.changeHealth(-damage);
            defender.setCounter(0);
        }
    }

    public void GameLoop()
    {
        bool input;
        string action;
        string winner = "";
        while (true)
        {
            int reverse = -100;
            // Beggining of turn
            while (isThereTurn())
            {
                input = false;
                Refresh();
                writer.MainInfo(ArmyQueue, BLUE, RED);
                curStack = ArmyQueue.Find(First);
                // action holder
                writer.YourTurn(curStack);
                while (!input)
                {
                    action = Console.ReadLine();
                    switch (action)
                    {
                        case "1":
                            input = false;
                            writer.Target("enemy");
                            while (!input)
                            {
                                action = Console.ReadLine();
                                bool isNumeric = int.TryParse(action, out int n);
                                if (!isNumeric)
                                {
                                    continue;
                                }
                                findID = Int32.Parse(action);
                                if (!ArmyQueue.Exists(Find))
                                {
                                    continue;
                                }
                                if (ArmyQueue.Find(Find).Side == curStack.Side)
                                {
                                    continue;
                                }
                                input = true;
                            }
                            attack(curStack, ArmyQueue.Find(Find));
                            curStack.changeQueueInitiative(-900);
                            BLUE.RemoveDead();
                            RED.RemoveDead();
                            break;
                        case "2":
                            break;
                            input = true;
                            break;
                        case "3":
                            if (curStack.isWaited == 1)
                            {
                                break;
                            }
                            input = true;
                            curStack.changeQueueInitiative(reverse);
                            reverse = reverse + 1;
                            break;
                        case "4":
                            curStack.setIsDefend(1);
                            curStack.changeQueueInitiative(-900);
                            input = true;
                            break;
                        case "5":
                            input = true;
                            if (curStack.Side == "RED")
                            {
                                winner = "BLUE";
                            }
                            else
                            {
                                winner = "RED";
                            }
                            break;
                        case "6":
                            writer.Target("any");
                            while (!input)
                            {
                                action = Console.ReadLine();
                                bool isNumeric = int.TryParse(action, out int n);
                                if (!isNumeric)
                                {
                                    continue;
                                }
                                findID = Int32.Parse(action);
                                if (!ArmyQueue.Exists(Find))
                                {
                                    continue;
                                }
                                input = true;
                            }
                            writer.MainInfo(ArmyQueue, BLUE, RED);
                            writer.YourTurn(curStack);
                            Console.WriteLine(ArmyQueue.Find(Find).ShowBattleStats());
                            input = false;
                            break;
                        default:
                            break;
                    }
                }
                    if (RED.IsDefeated())
                    {
                        winner = "BLUE";
                        Refresh();
                        break;
                    }
                    if (BLUE.IsDefeated())
                    {
                        winner = "RED";
                        Refresh();
                        break;
                    }
                    if (winner != "")
                {
                    break;
                }
                    Refresh();
                    //
                }
                ArmyQueue.Sort(Compare);
            if (winner != "")
            {
                Console.WriteLine($"WINNER IS {winner}");
                break;
            }
                Console.WriteLine("///////////////////END OF TURN///////////////////");
                // end of turn
                foreach (BattleUnitStack u in ArmyQueue)
                {
                    u.changeQueueInitiative(u.curInitiative);
                    u.setCounter(1);
                    u.setIsDefend(0);
                    u.setIsWaited(0);
                }
                //there will be our GameLoop
                //ShowInfo();
                //break; // will be summoned when fight is over
            }
            ChangeArmies();
            return;
        }


        void ChangeArmies()
        {
            Console.WriteLine("ARMY CHANGED");
            //first it will write losses
            //there CrusadeArmies will be changed
        }


    }
