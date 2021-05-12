using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW03
{
    public partial class Car
    {
        public void printCar()
        {
            Console.WriteLine($"Регистрационный номер: {this.number}");
            Console.WriteLine($"Марка: {this.brand}");
            Console.WriteLine($"Модель: {this.model}");
            Console.WriteLine($"Мощность двигателя {this.power} л.с. / {horseToKW(this.power)} кВт");
            Console.WriteLine($"Объем двигателя {this.engineCapacity} л.");
            Console.WriteLine($"{this.GetHashCode()}\n");
        }
    }
}
