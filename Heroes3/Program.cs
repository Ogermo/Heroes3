using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Heroes3;

        static class Program
        {
    /// <summary>
    /// Главная точка входа для приложения.
    /// </summary>
    [STAThread]
    static void Main()
    {
        /*Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());*/
        List<UnitStack> stack = new List<UnitStack> { new UnitStack("ANGEL", 999), new UnitStack("ANGEL", 965), new UnitStack("ANGEL", 98),
         new UnitStack("ANGEL", 999), new UnitStack("ANGEL", 965)};

        ArmyClass ss = new ArmyClass(stack);
        Angel super = new Angel();
    

        BattleUnitStack STACK = new BattleUnitStack(new UnitStack("ANGEL" , 365));
        BattleArmy ARMY = new BattleArmy(ss);
        ARMY.Add(STACK);
        STACK.curHitPoints = 365;
        ARMY.Add(STACK);

        STACK.curDefence = 900;
        ARMY.Add(STACK);
        (ARMY.Description[0]).curDefence = 666;
        Battle GAME = new Battle(ss, ss);
        STACK.curDefence = 900;
        GAME.BLUE.Description[0].curInitiative = 999;
        GAME.RED.Description[0].curHitPoints = 5000;
        int b = 7;
        GAME.SaveBLUE.Description.RemoveAt(0);

    }
}
