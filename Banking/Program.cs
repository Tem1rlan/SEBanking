using System;

namespace Banking
{
    class Program
    {
        static void Main(string[] args)
        {
			// булеановская переменная для принятия решения
			bool credit = false;

			Console.Write("Введите свой ежемесячный доход: ");
			int dohod = Convert.ToInt32(Console.ReadLine()); // Ежемесячный доход;

			Console.Write("Сколько вам лет? ");
			int age = Convert.ToInt32(Console.ReadLine()); // Возраст;

			Console.Write("Введите ваш пол(М, если мужской, Ж, если женский): ");
			char gen = Convert.ToChar(Console.ReadLine()); // Пол;

			Console.Write("Введите свой стаж работы: ");
			int exp = Convert.ToInt32(Console.ReadLine()); // Стаж работы;

			Console.Write("Введите свой статус (ф, если физический, ю, если юридический): ");
			char status = Convert.ToChar(Console.ReadLine()); // Юридический статус (физ.лицо или юр.лицо);
			char creditForm = 'б';
			if (status.ToString().ToLower() == "ф")
            {
				Console.Write("В какой форме вы хотите получить кредит?(н, если наличными, б, если безналичными) ");
				creditForm = Convert.ToChar(Console.ReadLine()); // Форма выдачи кредита (нал или безнал);
			}

			Console.Write("Сколько кредитов вы просрочили? ");
			int overCredits = Convert.ToInt32(Console.ReadLine()); // Количество просроченных кредитов;

			Console.Write("Есть ли залог?(Да, если есть, нет, если нету) ");
			string deposit = Console.ReadLine(); // Наличие залогового имущества (при наличии, вводит его стоимость);
			int depositCost = 0;
			if (deposit.ToLower() == "да")
			{
				Console.Write("Стоимость вашего депозита: ");
				depositCost = Convert.ToInt32(Console.ReadLine()); // Стоимость залога
			}

			Console.Write("На какую сумму вы хотите получить кредит? ");
			int sum = Convert.ToInt32(Console.ReadLine()); // Запрашиваемая сумма.


			// Поступим по простому просто if else
			if (overCredits == 0) // If нет просроченных кредитов
			{
				// проверка статуса, физическое или юридическое лицо
				if (status.ToString().ToLower() == "ф")
				{
					// проверка на пол
					if ((gen.ToString().ToLower() == "м" && age < 63 && age > 18) || (gen.ToString().ToLower() == "ж" && age < 58 && age > 18))
						// проврка стажа
						if (exp >= 2)
							// проверка дохда 
							if (dohod * 12 >= 720000)
								// проверка суммы кредита
								if (sum <= 3000000+depositCost)
									credit = true;
				}
				else if (status.ToString().ToLower() == "ю")
					if (creditForm.ToString().ToLower() == "б")
						// возраст
						if ((gen.ToString().ToLower() == "м" && age < 63) || (gen.ToString().ToLower() == "ж" && age < 58))
							// стаж
							if (exp >= 5)
								// доход
								if (dohod * 12 >= 3000000)
									// сумма кредита
									if (sum < 30000000 + depositCost)
										credit = true;
			}
			if (credit)
                Console.WriteLine("ОДОБРЕНО");
			else
                Console.WriteLine("ОКТАЗАНО");
		}
    }
}
