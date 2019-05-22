using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Lesson_7_Delegates
{
    public partial class Lesson
    {
        public static void CarDelegateExample() {
            var car = new CarDelegate(10, 5, 1000) {
                Tank = 50,
                LastCheckEngineMileAge = 20
            };

            car.LowFuelHandler += (double fuel) => {
                Console.WriteLine($"Low fuel!!! {fuel}");
            };

            car.CheckEngineHandler += (double mileAge) => {
                Console.WriteLine($"Check Engine!!! {mileAge}");
            };            

            car.Move(100);

            car.CheckEngineHandler(25);
        }

        public static void CarEventExample()
        {
            var car = new CarEvent(10, 5, 1000)
            {
                Tank = 50,
                LastCheckEngineMileAge = 20
            };

            car.LowFuelEvent += (double fuel) => {
                Console.WriteLine($"Low fuel!!! {fuel}");
            };

            car.CheckEngineEvent += (double mileAge) => {
                Console.WriteLine($"Check Engine!!! {mileAge}");
            };

            car.Move(100);

            //car.LowFuelEvent(25);
        }

        public class Transport
        {
            public Transport()
            {
            }

            public Transport(double mileage)
            {
                this.Mileage = mileage;
            }

            public double Mileage { get; protected set; }

            public virtual void Move(double km)
            {
                Mileage += km;
                Console.WriteLine($"Transport.Move: {km}");
            }

            public virtual void Start(int idleTime)
            {
            }            
        }

        public class Marine : Transport
        {
            public double Draft { get; protected set; }

            public Marine()
            {
            }

            public Marine(double mileage)
            {
                this.Mileage = mileage;
            }
        }

        public class Aircraft : Transport
        {
            public Aircraft()
            {
            }

            public Aircraft(double mileage)
            {
                this.Mileage = mileage;
            }
        }

        public class Car : Transport
        {
            public Car(double consumption,
                    int fuel,
                    int mileage) : base(mileage)
            {
                this.Fuel = fuel;
                this.Consumption = consumption;
            }

            public double Fuel { get; protected set; }
            public double Tank { get; protected set; }
            public double Consumption { get; protected set; }
            public double IdleConsumption { get; protected set; }
            public double LastCheckEngineMileAge { get; protected set; }

            public override void Move(double km)
            {
                base.Move(km);
                Fuel -= km * Consumption;
                Console.WriteLine($"Car.Move: {km}");
            }

            /*public override (bool lowFuel, bool checkEngine) Move(double km)
            {
                base.Move(km);
                Fuel -= km * Consumption;

                Console.WriteLine($"Car.Move: {km}");

                return  (
                            (Fuel < Tank * 0.05),
                            (Mileage > LastCheckEngineMileAge + 1000)
                        );
            }*/

            public override void Start(int idleTime)
            {
                Fuel -= IdleConsumption * Consumption;
            }            

            public void FillUp(int liters)
            {
                Fuel += liters;
            }
        }

        public class CarDelegate : Transport
        {
            public CarDelegate(double consumption,
                    int fuel,
                    int mileage) : base(mileage)
            {
                this.Fuel = fuel;
                this.Consumption = consumption;
            }

            public Action<double> LowFuelHandler = (double fuel) => { };
            public Action<double> CheckEngineHandler = (double distance) => { };

            public double Fuel { get; protected set; }
            public double Tank { get;  set; }
            public double Consumption { get; protected set; }
            public double IdleConsumption { get; set; }
            public double LastCheckEngineMileAge { get; set; }

            public override void Move(double km)
            {
                base.Move(km);
                Fuel -= km * Consumption;

                if (Fuel < Tank * 0.05)
                {
                    LowFuelHandler(Fuel);
                }

                if (Mileage > LastCheckEngineMileAge + 1000)
                {
                    CheckEngineHandler(Mileage);
                }

                Console.WriteLine($"Car.Move: {km}");
            }            

            public override void Start(int idleTime)
            {
                Fuel -= IdleConsumption * Consumption;

                if (Fuel < Tank * 0.05)
                {
                    LowFuelHandler(Fuel);
                }
            }

            public void FillUp(int liters)
            {
                Fuel += liters;
            }
        }

        public class CarEvent : Transport
        {
            public CarEvent(double consumption,
                    int fuel,
                    int mileage) : base(mileage)
            {
                this.Fuel = fuel;
                this.Consumption = consumption;
            }

            public event Action<double> LowFuelEvent;
            public event Action<double> CheckEngineEvent;

            public double Fuel { get; protected set; }
            public double Tank { get; set; }
            public double Consumption { get; protected set; }
            public double IdleConsumption { get; set; }
            public double LastCheckEngineMileAge { get; set; }

            public override void Move(double km)
            {
                base.Move(km);
                Fuel -= km * Consumption;

                if (Fuel < Tank * 0.05)
                {
                    if (LowFuelEvent != null)
                        LowFuelEvent(Fuel);
                }

                if (Mileage > LastCheckEngineMileAge + 1000)
                {
                    CheckEngineEvent?.Invoke(Mileage);
                }

                Console.WriteLine($"Car.Move: {km}");
            }

            public override void Start(int idleTime)
            {
                Fuel -= IdleConsumption * Consumption;

                if (Fuel < Tank * 0.05)
                {
                    LowFuelEvent?.Invoke(Fuel);
                }
            }

            public void FillUp(int liters)
            {
                Fuel += liters;
            }
        }

    }
}
