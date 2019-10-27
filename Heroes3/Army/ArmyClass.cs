using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class ArmyClass
    {
    public readonly List<UnitStack> Description = new List<UnitStack>();

        public ArmyClass()
        {

        }
    public ArmyClass(List<UnitStack> SaveArmy)
    {
        if (SaveArmy.Count > 6)
        {
            throw new ArgumentException("SIZE TOO BIG.");
            //exception
        }
        Description = new List<UnitStack>(SaveArmy);
    }

    public string Add(string AddType, int AddAmount)
    {
        if (Description.Count() == 6)
        { 
            return("Full Army already");
        }
        Description.Insert(Description.Count(), new UnitStack(AddType, AddAmount));
        foreach (UnitStack u in Description)
        {
            if (u.Amount == 0)
            {
                Description.RemoveAt(Description.Count() - 1);
                return("The stack is invalid and was removed");
            }
        }
        return ($"{AddType} : {AddAmount} was added");
    }

        public int Size() //more comfortable to check
        {
            return Description.Count();
        }

        public string Show()
        {
        string ArmyShow = "";
           foreach (UnitStack u in Description)
            {
            ArmyShow = ArmyShow + $"///{u.minion.Type} : {u.Amount}///\n" +
                $"{u.ShowStats()}\n";
        }
        if (ArmyShow == "")
        {
            return ("Empty army");
        }
        else
        {
            return ArmyShow;
        }
        }

    }
