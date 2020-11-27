using System;

namespace RDO_Task_04
{
    class Program
    {
        static void Main(string[] args)
        {
            //readme
            Console.WriteLine("Очередная MMORPG \n");
            Console.WriteLine("Здоровье игрока = 200 ед.");
            Console.WriteLine("Здоровье босса = 400 ед.");
            Console.WriteLine("Первый ход за игроком");
            Console.WriteLine("Урон, наносимый боссом на каждом ходу = 50 \n");

            //заклинания
            Console.WriteLine("Возможные заклинания игрока \n");

            Console.WriteLine("парадокс - Наносит 50 ед. урона" +
                "\nС каждым последующим использованием урон заклинания возрастает на 25 ед." +
                "\nЭффект складывается до 2х раз" +
                "\nВы выходите из невидимости\n");

            Console.WriteLine("уклонение - Игрок получает 25 ед. урона" +
                "\nУклоняется от 2х следующих ходов босса" +
                "\nНевозможно использовать в состоянии невидимости\n");

            Console.WriteLine("восстановление - Игрок восстанавливает 50 ед. здоровья" +
                "\nВ течении 3х следующих ходов восстанавливает 25 ед. здоровья" +
                "\nМожно использовать только в состоянии невидимости" +
                "\nНе может быть использовано еще раз, пока активно\n");

            Console.WriteLine("исчезновение - Игрок получает 25 ед. урона" +
                "\nИгрок входит в состояние невидимости на 6 ходов" +
                "\nВ состоянии невидимости игрок не может быть атакован боссом\n");

            Console.WriteLine("укрепление - Игрок получает щит" +
                "\nЩит поглощает 25 ед. урона в течении 6 следующих ходов" +
                "\nукрепление нельзя использовать в состоянии невидимости" +
                "\nукрепление нельзя использовать под действием уклонение\n");

            //переменные
            int nomer_hoda = 0,
                hp_boss = 400,
                hp_igrok = 200,
                uron_paradoks = 50,
                schet_ukloneniya = 0,
                schet_vosstanovleniya = 0,
                schet_ischeznoveniya = 0,
                schet_ukrepleniya = 0;
            bool uklonenie = false,
                vosstanovlenie = false,
                ischeznovenie = false,
                ukreplenie = false;
            string zaklinanie_igroka;

            //Процесс игры
            while (hp_boss > 0 && hp_igrok > 0)
            {
                //Остаток действия заклинания уклонение
                if (uklonenie == true)
                {
                    schet_ukloneniya--;
                    if (schet_ukloneniya == 0)
                    {
                        uklonenie = false;
                    }
                }

                //Остаток действия заклинания восстановление
                if (vosstanovlenie == true)
                {
                    hp_igrok = hp_igrok + 25;
                    schet_vosstanovleniya--;
                    if (schet_vosstanovleniya == 0)
                    {
                        vosstanovlenie = false;
                    }
                }

                //Остаток действия заклинания исчезновения
                if (ischeznovenie == true)
                {
                    schet_ischeznoveniya--;
                    if (schet_ischeznoveniya == 0)
                    {
                        ischeznovenie = false;
                    }
                }

                //Остаток действия заклинания укрепления
                if (ukreplenie == true)
                {
                    hp_igrok = hp_igrok + 25;
                    schet_ukrepleniya--;
                    if (schet_ukrepleniya == 0)
                    {
                        ukreplenie = false;
                    }
                }

                //Счетчик ходов
                nomer_hoda++;

            viborzaklinaniya:
                //Сведения о ходе
                Console.Write("Ход № ");
                Console.WriteLine(nomer_hoda);

                Console.Write("Здоровье игрока - ");
                Console.WriteLine(hp_igrok);

                Console.Write("Здоровье босса - ");
                Console.WriteLine(hp_boss);
                Console.Write("\n");

                //Выбор заклинания игроком
                Console.Write("Каким умение хотите воспользоваться? -- ");
                zaklinanie_igroka = Convert.ToString(Console.ReadLine());
                Console.Write("\n");

                //Проверка правильности ввода заклинания
                if (zaklinanie_igroka == "1"
                    || zaklinanie_igroka == "2"
                    || zaklinanie_igroka == "3"
                    || zaklinanie_igroka == "4"
                    || zaklinanie_igroka == "5")
                {
                    //Условия заклинания парадокс
                    if (zaklinanie_igroka == "1")
                    {
                        hp_boss = hp_boss - uron_paradoks;
                        if (uron_paradoks < 100)
                        {
                            uron_paradoks = uron_paradoks + 25;
                        }
                        ischeznovenie = false;
                        if (uklonenie == false)
                        {
                            hp_igrok = hp_igrok - 50;
                        }
                    }

                    //Условия заклинания уклонение
                    if (zaklinanie_igroka == "2")
                    {
                        if (ischeznovenie == true)
                        {
                            Console.WriteLine("Это заклинание так не работает, вы ошиблись");
                        }
                        else
                        {
                            hp_igrok = hp_igrok - 25;
                            uklonenie = true;
                            schet_ukloneniya = 2;
                        }
                    }

                    //Условия заклинания восстановление
                    if (zaklinanie_igroka == "3")
                    {
                        if (ischeznovenie == false || vosstanovlenie == true)
                        {
                            Console.WriteLine("Это заклинание так не работает, вы ошиблись\n");
                        }
                        else
                        {
                            hp_igrok = hp_igrok + 50;
                            vosstanovlenie = true;
                            schet_vosstanovleniya = 3;
                        }
                    }

                    //Условия заклинания исчезновение
                    if (zaklinanie_igroka == "4")
                    {
                        ischeznovenie = true;
                        schet_ischeznoveniya = 6;
                    }

                    //Условия заклинания укрепление
                    if (zaklinanie_igroka == "5")
                    {
                        if (ischeznovenie == true || uklonenie == true)
                        {
                            Console.WriteLine("Это заклинание так не работает, вы ошиблись");
                        }
                        else
                        {
                            ukreplenie = true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Такого заклинания вы не знаете(\n");
                    goto viborzaklinaniya;
                }
            }
            //Итоговый вывод сведений о здоровье босса и игрока
            Console.Write("Здоровье игрока - ");
            Console.WriteLine(hp_igrok);

            Console.Write("Здоровье босса - ");
            Console.WriteLine(hp_boss);
            Console.Write("\n");
            //Вывод результата боя
            if (hp_igrok >= 0)
            {
                Console.WriteLine("ВЫ ПРОИГРАЛИ, ПОПРОБУЙТЕ ЕЩЕ РАЗ");
            }
            else
            {
                Console.WriteLine("ВЫ ПОБЕДИЛИ!");
            }
        }
    }
}
