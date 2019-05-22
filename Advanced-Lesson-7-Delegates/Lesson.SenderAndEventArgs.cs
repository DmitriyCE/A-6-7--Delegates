using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Lesson_7_Delegates
{
    public partial class Lesson
    {
        public static void SenderAndEventArgsExample()
        {
            var scooter = new Scooter() { Mileage = 2000 };

            scooter.LowOilEvent += (object sender, ScooterEventArgs e) => { };
            scooter.LowBatteryEvent += (Scooter sender, ScooterEventArgs args) => { };

        }        

        public class Scooter
        {
            public delegate void LowBatteryHandler(Scooter sender, ScooterEventArgs args);

            public event LowBatteryHandler LowBatteryEvent;
            public event EventHandler<ScooterEventArgs> LowOilEvent;           

            public double Mileage { get; set; }

            public virtual void Move(double km)
            {
                Mileage += km;

                LowOilEvent(this, new ScooterEventArgs() { Mileage = this.Mileage });
                LowBatteryEvent(this, new ScooterEventArgs() { Mileage = this.Mileage });
            }                    
        }

        public class ScooterEventArgs: EventArgs
        {
            public double Mileage { get; set; }
        }
    }
}
