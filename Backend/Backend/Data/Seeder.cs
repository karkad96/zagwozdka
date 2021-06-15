using System;
using System.Collections.Generic;
using Backend.Models;
using Backend.Models.Joins;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
	public static class Seeder
	{
		private static readonly List<Problem> Problems = new List<Problem>
		{
			new Problem
			{
				ProblemId = 1,
				Title = "Wielokrotność 3 i 5",
				Description = "Jeśli wymienimy wszystkie liczby naturalne poniżej 10, które są " +
				              "wielokrotnościami 3 lub 5, otrzymamy 3, 5, 6 i 9. Suma tych wielokrotności wynosi 23.\n " +
				              "Znajdź sumę wszystkich wielokrotności 3 lub 5 poniżej 1000.",
				Answer = "233168",
				SolvedBy = 112,
				Difficulty = 5,
				ReleaseDate = DateTime.Now
			},
			new Problem
			{
				ProblemId = 2,
				Title = "Parzyste liczby Fibonacciego",
				Description = "Każdy nowy wyraz w ciągu Fibonacciego jest generowany " +
				              "przez dodanie dwóch poprzednich wyrazów. Zaczynając od 1 i 2, " +
				              "pierwsze 10 terminów będzie:\n" +

				              "1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...\n"+

				              "Rozważając wyrazy w ciągu Fibonacciego, których wartości " +
				              "nie przekraczają czterech milionów, znajdź sumę wyrazów " +
				              "o parzystych wartościach.",
				Answer = "4613732",
				SolvedBy = 101,
				Difficulty = 5,
				ReleaseDate = DateTime.Now
			},
			new Problem
			{
				ProblemId = 3,
				Title = "Największy czynnik pierwszy",
				Description = "Czynniki pierwsze liczby 13195 to 5, 7, 13 i 29.\n" +
				              "Jaki jest największy czynnik pierwszy liczby 600851475143?",
				Answer = "6857",
				SolvedBy = 95,
				Difficulty = 5,
				ReleaseDate = DateTime.Now
			},
			new Problem
			{
				ProblemId = 4,
				Title = "Największy produkt palindromowy",
				Description = "Palindrom to wyrażenie brzmiące tak samo czytane od lewej do prawej i od prawej do lewej. " +
				              "Największy palindrom wykonany z iloczynu dwóch liczb dwucyfrowych to 9009 = 91 × 99.\n" +
				              "Znajdź największy palindrom wykonany z iloczynu dwóch 3-cyfrowych liczb.",
				Answer = "906609",
				SolvedBy = 115,
				Difficulty = 5,
				ReleaseDate = DateTime.Now
			},
			new Problem
			{
				ProblemId = 5,
				Title = "Najmniejsza wielokrotność",
				Description = "2520 to najmniejsza liczba, którą można podzielić przez każdą z liczb od 1 do 10 bez reszty.\n" +
				              "Jaka jest najmniejsza liczba dodatnia, która jest podzielna bez reszt przez wszystkie liczby od 1 do 20?",
				Answer = "232792560",
				SolvedBy = 112,
				Difficulty = 5,
				ReleaseDate = DateTime.Now
			},
			new Problem
			{
				ProblemId = 6,
				Title = "10001 liczba pierwsza",
				Description = "Wymieniając sześć pierwszych liczb pierwszych: 2, 3, 5, 7, 11 i 13, widzimy, że szósta liczba pierwsza to 13.\n" +
				              "Jaka jest 10001 liczba pierwsza?",
				Answer = "104743",
				SolvedBy = 98,
				Difficulty = 5,
				ReleaseDate = DateTime.Now
			},
			new Problem
			{
				ProblemId = 7,
				Title = "Specjalna trójka pitagorejska",
				Description = "Trójka pitagorejska to zbiór trzech liczb naturalnych, a < b < c, dla których: a^2 + b^2 = c^2" +
							  "Na przykład 3^2 + 4^2 = 9 + 16 = 25 = 5^2." +
				              "Istnieje dokładnie jedna trójka pitagorejska, dla której a + b + c = 1000." +
							  "Znajdź produkt a*b*c.",
				Answer = "31875000",
				SolvedBy = 102,
				Difficulty = 5,
				ReleaseDate = DateTime.Now
			},
			new Problem
			{
				ProblemId = 8,
				Title = "Sumowanie liczb pierwszych",
				Description = "Suma liczb pierwszych poniżej 10 to 2 + 3 + 5 + 7 = 17.\n" +
				              "Znajdź sumę wszystkich liczb pierwszych poniżej dwóch milionów.",
				Answer = "142913828922",
				SolvedBy = 104,
				Difficulty = 5,
				ReleaseDate = DateTime.Now
			},
			new Problem
			{
				ProblemId = 9,
				Title = "Suma cyfr z potęgi",
				Description = "2^15 = 32768, a suma jej cyfr to 3 + 2 + 7 + 6 + 8 = 26.\n" +
				              "Jaka jest suma cyfr liczby 2^1000?",
				Answer = "1366",
				SolvedBy = 96,
				Difficulty = 5,
				ReleaseDate = DateTime.Now
			},
			new Problem
			{
				ProblemId = 10,
				Title = "Suma cyfr silni",
				Description = "n! oznacza n × (n − 1) × ... × 3 × 2 × 1\n" +
				              "Na przykład 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,\n" +
				              "a suma cyfr w liczbie 10! to 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.\n" +
				              "Znajdź sumę cyfr w liczbie 100!",
				Answer = "648",
				SolvedBy = 101,
				Difficulty = 5,
				ReleaseDate = DateTime.Now
			},
			new Problem
			{
				ProblemId = 11,
				Title = "Liczby zaprzyjaźnione",
				Description = "Niech d(n) będzie zdefiniowana jako suma właściwych dzielników n (liczby mniejsze od n, które dzielą się bez reszty z n)." +
				              "Jeśli d(a) = b i d(b) = a, gdzie a != b, to a i b są parą zaprzyjaźnioną i każde z a i b nazywa się liczbami zaprzyjaźnionymi.\n" +
				              "Na przykład właściwymi dzielnikami liczby 220 są 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 i 110; " +
				              "zatem d(220) = 284. Właściwymi dzielnikami 284 są 1, 2, 4, 71 i 142; więc d(284) = 220.\n" +
				              "Oblicz sumę wszystkich liczb zaprzyjaźnionych poniżej 10000.",
				Answer = "31626",
				SolvedBy = 145,
				Difficulty = 5,
				ReleaseDate = DateTime.Now
			},
			new Problem
			{
				ProblemId = 12,
				Title = "Permutacje leksykograficzne",
				Description = "Permutacja to uporządkowany układ obiektów. " +
				              "Na przykład 3124 jest jedną z możliwych permutacji cyfr 1, 2, 3 i 4. " +
				              "Jeśli wszystkie permutacje są wymienione numerycznie lub alfabetycznie, " +
				              "nazywamy to porządkiem leksykograficznym. Leksykograficzne permutacje 0, 1 i 2 to:\n"+
				              "012 021 102 120 201 210" +
				              "Jaka jest milionowa permutacja leksykograficzna cyfr 0, 1, 2, 3, 4, 5, 6, 7, 8 i 9?",
				Answer = "31626",
				SolvedBy = 145,
				Difficulty = 5,
				ReleaseDate = DateTime.Now
			},
			new Problem
			{
				ProblemId = 13,
				Title = "Rozmienianie monet",
				Description = "W Polsce waluta składa się ze złotówki (zł) i grosza (gr). W powszechnym obiegu znajduje się dziewięc monet:\n" +
				              "1gr, 2gr, 5gr, 10gr, 20gr, 50gr, 1zł (100gr), 2zł (200gr) i 5zł (500gr).\n" +
				              "5zł można rozmienić w następujący sposób:\n" +
				              "1×2zł + 2×1zł + 1×50gr + 2×20gr + 1×5gr + 1×2gr + 3×1gr\n" +
				              "Na ile różnych sposobów można rozimenić 5zł przy użyciu dowolnej liczby monet?\n",
				Answer = "73682",
				SolvedBy = 87,
				Difficulty = 15,
				ReleaseDate = DateTime.Now
			},
		};

		private static readonly List<Tag> Tags = new List<Tag>
		{
			new Tag
			{
				TagId = 1,
				TagName = "Matematyka"
			},
			new Tag
			{
				TagId = 2,
				TagName = "Programowanie"
			},
			new Tag
			{
				TagId = 3,
				TagName = "Programowanie Dynamiczne"
			},
			new Tag
			{
				TagId = 4,
				TagName = "Fizyka"
			},
			new Tag
			{
				TagId = 5,
				TagName = "Jednolinijkowiec"
			},
			new Tag
			{
				TagId = 6,
				TagName = "Drzewa binarne"
			},
		};

		private static void TagsSeed(ModelBuilder modelBuilder)
	    {
		    modelBuilder.Entity<Tag>().HasData(Tags);
	    }

		private static void ProblemsSeed(ModelBuilder modelBuilder)
	    {
		    modelBuilder.Entity<Problem>().HasData(Problems);
	    }

	    public static void Seed(ModelBuilder modelBuilder)
	    {
		    TagsSeed(modelBuilder);
		    ProblemsSeed(modelBuilder);
	    }
    }
}
