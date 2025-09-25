namespace Console_2
{
    internal class Program
    {
        static List<string>list=new List<string>();
        static void Main(string[] args)
        {
            Managemenu();
            int num=Getnumber(1,6);
            Console.WriteLine("Sikeres szám megadás"+num);
            SwitchMenu(num);
            Console.ReadKey();
        }
        static void Managemenu()
        {
            Writemenu();
           
        }
        static void Writemenu()
        {
            Console.Clear();
            Console.WriteLine("1. adatok listázása");
            Console.WriteLine("2. adat létrehozása");
            Console.WriteLine("3. legnagyobb adat");
            Console.WriteLine("4. legkisebb adat");
            Console.WriteLine("5. adat törlése");
            Console.WriteLine("6. kilépés");
        }
        static int Getnumber(int min=int.MinValue,int max = int.MaxValue)
        {
            Console.WriteLine("Add meg a számot!");
            string line=Console.ReadLine().Trim(' ',',','.');
            int resault = 0;
            if (int.TryParse(line,out resault))
                if (resault<=max&& resault>=min)
                {
                    return resault;
                }
                else
                {
                    Console.WriteLine("A szám nem a megadott határértéken belül van");
                }
            else
                Console.WriteLine("Nem szám lett megadva");


            resault = Getnumber(min, max);
            return resault;
        }
        static void SwitchMenu(int num)
        {
            switch (num)
            {
                case 1:
                    functionOne();
                    break;
                case 2:
                    functionTwo();
                    break;
                case 3:
                    functionThree();
                    break;
                case 4:
                    functionFour();
                    break;
                case 5:
                    functionFive();
                    break;
                case 6:
                    functionSix();
                    break;
                default:
                    Console.WriteLine("Hibás menupont kerult megadásra");
                    break;
            }
        }
        static void functionOne()
        {
            if (list.Count==0)
            {
                Console.WriteLine("Üres a lista");
            }
            else
            {
                Console.WriteLine("A lista elemei: "+list);

            }
        }
        static void functionTwo()
        {
            Console.WriteLine("Adj meg egy adatot: ");
            string addlist = Console.ReadLine().Trim();
            list.Add(addlist);
            
        }
        static void functionThree()
        {

        }
        static void functionFour()
        {

        }
        static void functionFive()
        {

        }
        static void functionSix()
        {

        }
    }
}
