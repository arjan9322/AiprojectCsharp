using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIproject.Goals
{
    class Think // choose the most important goal
    {
        private const int getPoints = 100;
        private int getFuel;
        private int getRepair;
        private Vehicle parent;
        public Goal Goal { get; set; }

        public Think(Vehicle _parent)
        {
            parent = _parent;
        }

        public void Update(){
            parent.hull -= 2;
            parent.fuel -= 1;
            getFuel = 500 - parent.fuel;
            getRepair = 500 - parent.hull;

            if(getFuel >= getRepair && getFuel >= getPoints)
                Goal = new GetFuel(parent);
            else if(getRepair >= getPoints)
                Goal = new GetRepair(parent);
            else
                Goal = new GetPoints(parent);

            Goal.Update();
        }
    }
}
