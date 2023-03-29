using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdruinoGUI
{
    public class ProfileClassData
    {
        [Index(0)]
        public int Time { get; set; }

        [Index(1)]
        public int LeftMotor { get; set; }

        [Index(2)]
        public int RightMotor { get; set; }

    }
}
