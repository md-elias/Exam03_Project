using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Repository_Domain;
using RepositoryPattern;

namespace Exam03Project
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRun = true; 
            while (isRun)
            {
                Console.Clear(); 
                Console.WriteLine(); 
                Console.WriteLine("================= Select Your Process =================");
                Console.WriteLine("Press 1 : To Get a Operator Information");
                Console.WriteLine("Press 2 : To Create a New Operator Information");
                Console.WriteLine("Press 3 : To Exit The Application"); 
                string inputKey = Console.ReadLine(); 
                Console.Clear();
                if (inputKey == "1") 
                {
                    var source = RepositoryFactory.Create<IOperatorRepository>(ContextTypes.XMLSource);
                    var items = source.GetAll();
                    Console.WriteLine();
                    Console.WriteLine("=============Operator Information==========="); 
                    foreach (var item in items)
                    { 
                        Console.WriteLine(item.OperatorName + ", " + item.SimName + ", " + item.NidNo + ", " + item.CellPhoneNo); 
                    } Console.Write("Press any key to continue...");
                    Console.ReadKey(); 
                } 
                else if (inputKey == "2")
                {
                    Operator opr = new Operator(); 
                    Console.Write("Operator Name : ");
                    opr.OperatorName = Console.ReadLine();
                    Console.Write("Sim Name : ");
                    opr.SimName = Console.ReadLine();
                    Console.Write("NID No. : ");
                    opr.NidNo = Console.ReadLine();
                    Console.Write("Cell Phone No. : ");
                    opr.CellPhoneNo = Console.ReadLine();
                    Console.Clear();
                    IOperatorRepository source = RepositoryFactory.Create<IOperatorRepository>(ContextTypes.XMLSource);
                    try 
                    { 
                        source.Insert(opr); 
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex); 
                        Console.ReadKey();
                        continue;
                    }
                }
                else if (inputKey == "3") 
                {
                    isRun = false; 
                }
            }
        }
    }
}
