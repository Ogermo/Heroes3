using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class Battle
    {
        public BattleArmy BLUE;
        public BattleArmy RED;
    public ArmyClass SaveBLUE;
    public ArmyClass SaveRED; //Used after battle to change sides CrusadeArmy

    public Battle(ArmyClass initBLUE, ArmyClass initRED)
    {
        BLUE = new BattleArmy(initBLUE);
        RED = new BattleArmy(initRED);
        SaveBLUE = initBLUE;
        SaveRED = initRED;
        GameLoop();
    }

    public void GameLoop()
    {
        while (true)
        {
            //there will be our GameLoop
            ShowInfo();
            break; // will be summoned when fight is over
        }
        ChangeArmies();
        return;
    }

    public void ChangeArmies()
    {
        //first it will write losses
        //there CrusadeArmies will be changed
    }

    public void ShowInfo()
    {
        Console.Clear();
        // there it will write battle(turns,actions, etc)
    }

    }
