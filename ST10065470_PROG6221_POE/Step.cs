using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10065470_PROG6221_POE
{
    public class Step
    {
        // Variables
        private string step;

        public Step(string step)
        {
            this.step = step;
        }

        // Getters And Setters
        public string GetStep { get => step; set => step = value; }
    }
}
