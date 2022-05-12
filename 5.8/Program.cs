using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._8
{
    class Program
    {
        static void Main(string[] args)
        {
            int PlayerHealth = 100;
            int PlayerMoral = 50;
            
            int DragonHealth = 100;
            int DragonMoral = 50;

            Random rnd = new Random();

            while(true)
            {
                Console.Clear();
                
                Console.WriteLine($"Здоровье: {PlayerHealth}                         Здоровье дракона: {DragonHealth}");
                Console.WriteLine($"Боевой дух: {PlayerMoral}                       Боевой дух дракона: {DragonMoral}");

                Console.WriteLine();

                Console.WriteLine("Выберите действие:");
                Console.WriteLine();
                Console.WriteLine("1. Ударить дракона рыцарским копьем (урон 20, боевой дух +10)");
                Console.WriteLine("2. Устрашить дракона (урон 5, боевой дух дракона -20)");
                Console.WriteLine("3. Помолиться (боевой дух +25)");
                Console.WriteLine("4. Приложить подорожник (здоровье +30)");
                Console.WriteLine("5. Задушить дракона голыми руками (необходим боевой дух не менее 100)");

                Console.WriteLine();

                if (PlayerHealth <= 0)
                {
                    Console.WriteLine("Вы пали в бою как герой. Барды будут слагать песни об этом печальном дне, но вам их не суждено услышать...");
                    
                    Console.ReadLine();
                    break;
                }

                if (DragonHealth <= 0)
                {
                    Console.WriteLine("Вы победили! Чудовище пало от вашей руки, но вам все равно никто не поверит...");
                    
                    Console.ReadLine();
                    break;
                }

                if (PlayerMoral <= 0)
                {
                    Console.WriteLine("Вы сбежали с поля боя. Этот позор будет преследовать вас до конца жизни. Долгой и счастливой жизни...");
                    
                    Console.ReadLine();
                    break;
                }

                if (DragonMoral <= 0)
                {
                    Console.WriteLine("Дракон был поражен вашей отвагой, доблестью и сияющими доспехами. Он просит пощадить его и отпустить домой");
                    Console.WriteLine("1. Пощадить дракона");
                    Console.WriteLine("2. Убить дракона");

                    int End = int.Parse(Console.ReadLine());

                    if (End == 1) Console.WriteLine("Дракон поблагодарил вас за доброту и улетел, а через неделю спалил вашу родную деревню...");
                    if (End == 2) Console.WriteLine("Вы победили! Чудовище пало от вашей руки, но вам все равно никто не поверит...");

                    Console.ReadLine();
                    break;
                }

                int PlayerTurn = int.Parse(Console.ReadLine());

                if (PlayerTurn > 5 || PlayerTurn < 1)
                {
                    Console.WriteLine("Вы совершили странное и необдуманное действие, запнулись о собственный меч и упали. Попробуйте еще раз");
                    
                    Console.ReadLine();
                    continue;
                }

                if (PlayerTurn == 1)
                {
                    DragonHealth -= 20;
                    PlayerMoral += 10;

                    Console.WriteLine("Вы метко ткнули копьем дракону между глаз, но от полученных ранений дракон становится агрессивней (боевой дух дракона +10)");

                    DragonMoral += 10;
                    
                    Console.ReadLine();
                }

                if (PlayerTurn == 2)
                {
                    DragonHealth -= 5;
                    DragonMoral -= 20;

                    Console.WriteLine("Вы кричите Фус-Ро-Да и кидаете в дракона камень. Дракон удивлен и немного напуган");
                                        
                    Console.ReadLine();
                }

                if (PlayerTurn == 3)
                {                   
                    PlayerMoral += 25;

                    Console.WriteLine("Вы помолились и ваш боевой дух вырос");                                      

                    Console.ReadLine();
                }

                if (PlayerTurn == 4)
                {                    
                    PlayerHealth += 30;

                    Console.WriteLine("Вы приложили подорожник к своему изрененному телу и почуствовали себя немного лучше");

                    Console.ReadLine();
                }

                if (PlayerTurn == 5)
                {
                    if (PlayerMoral >= 100)
                    {
                        DragonHealth = 0;
                        PlayerMoral = 100;

                        Console.WriteLine("Вы задушили дракона голыми руками");

                        Console.ReadLine();
                    }

                    else
                    {
                        Console.WriteLine("Вам не хватает боевого духа, чтобы броситься на дракона безоружным");

                        Console.ReadLine();
                        continue;
                    }                    
                }

                if (DragonHealth > 0 && DragonMoral > 0)
                {
                    if (DragonMoral >= 100)
                    {
                       
                        PlayerHealth = 0;
                        PlayerMoral = 0;

                        Console.WriteLine("Дракон взбесился и уничтожил все живое в зоне видимости, включая вас");

                        Console.ReadLine();
                    }
                    else
                    {
                        int Damage = rnd.Next(1, 5) * 10 - 5;
                        int DamageMoral = rnd.Next(1, 3) * 10;

                        PlayerHealth -= Damage;
                        PlayerMoral -= DamageMoral;

                        Console.WriteLine($"Дракон атаковал вас. Он нанес {Damage} урона и ваш боевой дух упал на {DamageMoral}");

                        Console.ReadLine();
                    }
                }

               

            }
        }
    }
}
