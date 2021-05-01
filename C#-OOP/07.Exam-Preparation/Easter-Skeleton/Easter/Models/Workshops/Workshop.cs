using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            var dyes = bunny.Dyes;

            foreach (var dye in dyes)
            {
                while (!egg.IsDone())
                {
                    if (bunny.Energy > 0 && !dye.IsFinished())
                    {
                        dye.Use();
                        bunny.Work();
                        egg.GetColored();
                    }
                    else
                    {
                        break;
                    }
                }

                if (egg.IsDone() || bunny.Energy <= 0)
                {
                    break;
                }
            }
        }
    }
}
