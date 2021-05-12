using System;
using System.Text.RegularExpressions;

namespace HW03
{
    public partial class Car
    {
        #region Static Members
        static double powerHorseWtRatio; //Коэффициент перевода из лошадиных сил в киловаты
        static String numberPattern; //Маска проверки регистрационного номера А123АА12
        #endregion
        #region Fields
        private String brand; //Бренд
        private String model; //Модель
        private String number; //Регисрационный номер
        private double power; //Мощьность двигателя
        private double engineCapacity; //Объем двигателя
        #endregion
        #region Constructors
        //Static constructor
        static Car() {
            powerHorseWtRatio = 1.3596; //Коэффициент перевода (можно было бы сделать константной, но по заданию нужно указать 2 статических члена.)
            numberPattern = @"[ABEKMHOPCTYX]\d{3}[ABEKMHOPCTYX]{2}\d{2}"; //маска номера А123АА12
        }
        //Constructors
        public Car()
        {
            CarBrand = "not defined";
            CarModel = "not defined";
            number = "not set!!!";
            power = 0;
            engineCapacity = 0;
        }
        public Car(String number, double power, double capacity, String brand = "not defined", String model = "not defined")
        {
            CarBrand = brand;
            CarModel = model;
            CarNumber = number;
            CarPower = power;
            CarEngineCapacity = capacity;
           
        }
        public Car(char[] number, double power, double capacity, char[] brand, char[] model)
        {
            CarBrand = Convert.ToString(brand);
            CarModel = Convert.ToString(model);
            CarNumber = Convert.ToString(number);
            CarPower = power;
            CarEngineCapacity = capacity;
        }
        #endregion
        #region Methods
        //methods
        static int horseToKW(double power)
        {
            return Convert.ToInt32(power / powerHorseWtRatio);
        }
        static bool numberCheck(ref String number)
        {
            if (Regex.IsMatch(number, numberPattern, RegexOptions.IgnoreCase) && number.Length == 8)
            {
                
                return true;
            }
            return false;
        }
        private bool powerCheck(double power)
        {
            if (power > 1 && power < 1000)
                return true;
            return false;
        }
        private bool engineCapacityCheck(double capacity)
        {
            if (capacity > 0 && capacity < 800)
                return true;
            return false;
        }
        #endregion
        #region Props
        public String CarBrand
        {
            get { return this.brand; }
            set { this.brand = value; }
        }
        public String CarModel
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public String CarNumber
        {
            get { return this.number; }
            set
            {
                if (numberCheck(ref value)) //передача по ссылке. тут нет особой необходимости, но в задаче стояло.
                {
                    this.number = value;
                }
                else
                {
                    this.number = "A123AB00";
                    Console.WriteLine("Неверно введен регисрационный номер - установлен номер по умолчанию!");
                }
            }
        }
        public double CarPower
        {
            get { return this.power; }
            set
            {
                if (powerCheck(value))
                {
                    power = value;
                }
                else
                {
                    power = 0;
                    Console.WriteLine("Неверно введена мощность двигателя! - установлена в 0!");
                }
            }
        }
        public double CarEngineCapacity
        {
            get { return this.engineCapacity; }
            set
            {
                if (engineCapacityCheck(value))
                {
                    this.engineCapacity = value;
                }
                else
                {
                    this.engineCapacity = 0;
                    Console.WriteLine("Неверно введен объем двигателя! - установлен в 0!");
                }
            }
        }
        #endregion
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Проверка кода:
            //Проверка Конструктора по умолчанию:
            Console.WriteLine("**************************************************************************************");
            Console.WriteLine("Код выполняемого модуля предназначен для отладки методов класса Car");
            Console.WriteLine("Выполнение кода происходит автоматически и предназначено для визуального контроля");
            Console.WriteLine("**************************************************************************************\n");
            Console.WriteLine("Проверка создания объекта класса конструктором по умолчанию:\n");
            Car car = new Car();
            car.printCar();
            //Проверка коструктора с параметрами:
            Console.WriteLine("Проверка создания объекта класса конструктором с параметрами:\n");
            Car car02 = new Car("B333BB39", 130, 2.0, "Lada", "X-Ray");
            Car car03 = new Car();
            car03.printCar();
            Console.WriteLine("Проверка механизма копирования объекта класса по умолчанию:\n");
            car03 = car02; //копируем объект
            car03.printCar();
            car02.CarBrand = "Tralala"; //Проверка упрощенного сеттера c# style
            car02.printCar();
            car03.printCar();//поменяли один объект - поменялся и второй.
            //Создаем массив из 5 элементов класса Car
            Console.WriteLine("Проверка создания массива объектов класса:\n");
            Car[] arrayCar = new Car[5];
            for(int i = 0; i < 5; i++)
            {
                arrayCar[i] = new Car();
                arrayCar[i].printCar();                
            }

        }
    }
}
