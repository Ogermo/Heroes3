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
        ARMY.Add(STACK);

        ARMY.Add(STACK);
        Battle GAME = new Battle(ss, ss);
        int b = 7;
        GAME.SaveBLUE.Description.RemoveAt(0);

    }
}
