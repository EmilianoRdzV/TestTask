using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestTask
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var task = new Task(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Tarea interna");
            });
            task.Start();

            var task2 = new Task(() =>
            {
                Thread.Sleep(1100);
                Console.WriteLine("Tarea interna 2");
            });
            task2.Start();

            Console.WriteLine("Trabajo sin descansoooo");

            await task; //Hasta terminar la task, verifica si termina la task 1 para poder seguir a task2 y por ultimo 'Termineee'
            await task2;

            int resultRandom = await MultAsync(5);
            Console.WriteLine(resultRandom);

            Console.WriteLine("Termineeeee");
            Console.ReadLine();
        }

        public static async Task<int> MultAsync(int num)
        {
            int num2 = 22;
            var taskInt = new Task<int>(() =>

               num * num2);
               taskInt.Start();
               int result = await taskInt;
               return result;
        }


    }
}