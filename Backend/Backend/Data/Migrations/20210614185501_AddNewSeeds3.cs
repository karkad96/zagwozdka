using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Data.Migrations
{
    public partial class AddNewSeeds3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 6);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Problems",
                columns: new[] { "ProblemId", "Answer", "Description", "Difficulty", "ReleaseDate", "SolvedBy", "Title" },
                values: new object[] { 1, "233168", "Jeśli wymienimy wszystkie liczby naturalne poniżej 10, które są wielokrotnościami 3 lub 5, otrzymamy 3, 5, 6 i 9. Suma tych wielokrotności wynosi 23.\n Znajdź sumę wszystkich wielokrotności 3 lub 5 poniżej 1000.", 5, new DateTime(2021, 6, 14, 20, 47, 34, 652, DateTimeKind.Local).AddTicks(881), 112, "Wielokrotność 3 i 5" });

            migrationBuilder.InsertData(
                table: "Problems",
                columns: new[] { "ProblemId", "Answer", "Description", "Difficulty", "ReleaseDate", "SolvedBy", "Title" },
                values: new object[] { 13, "73682", "W Polsce waluta składa się ze złotówki (zł) i grosza (gr). W powszechnym obiegu znajduje się dziewięc monet:\n1gr, 2gr, 5gr, 10gr, 20gr, 50gr, 1zł (100gr), 2zł (200gr) i 5zł (500gr).\n5zł można rozmienić w następujący sposób:\n1×2zł + 2×1zł + 1×50gr + 2×20gr + 1×5gr + 1×2gr + 3×1gr\nNa ile różnych sposobów można rozimenić 5zł przy użyciu dowolnej liczby monet?\n", 15, new DateTime(2021, 6, 14, 20, 47, 34, 656, DateTimeKind.Local).AddTicks(9407), 87, "Suma monet" });

            migrationBuilder.InsertData(
                table: "Problems",
                columns: new[] { "ProblemId", "Answer", "Description", "Difficulty", "ReleaseDate", "SolvedBy", "Title" },
                values: new object[] { 12, "31626", "Permutacja to uporządkowany układ obiektów. Na przykład 3124 jest jedną z możliwych permutacji cyfr 1, 2, 3 i 4. Jeśli wszystkie permutacje są wymienione numerycznie lub alfabetycznie, nazywamy to porządkiem leksykograficznym. Leksykograficzne permutacje 0, 1 i 2 to:\n012 021 102 120 201 210Jaka jest milionowa permutacja leksykograficzna cyfr 0, 1, 2, 3, 4, 5, 6, 7, 8 i 9?", 5, new DateTime(2021, 6, 14, 20, 47, 34, 656, DateTimeKind.Local).AddTicks(9403), 145, "Permutacje leksykograficzne" });

            migrationBuilder.InsertData(
                table: "Problems",
                columns: new[] { "ProblemId", "Answer", "Description", "Difficulty", "ReleaseDate", "SolvedBy", "Title" },
                values: new object[] { 11, "31626", "Niech d(n) będzie zdefiniowana jako suma właściwych dzielników n (liczby mniejsze od n, które dzielą się bez reszty z n).Jeśli d(a) = b i d(b) = a, gdzie a != b, to a i b są parą zaprzyjaźnioną i każde z a i b nazywa się liczbami zaprzyjaźnionymi.\nNa przykład właściwymi dzielnikami liczby 220 są 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 i 110; zatem d(220) = 284. Właściwymi dzielnikami 284 są 1, 2, 4, 71 i 142; więc d(284) = 220.\nOblicz sumę wszystkich liczb zaprzyjaźnionych poniżej 10000.", 5, new DateTime(2021, 6, 14, 20, 47, 34, 656, DateTimeKind.Local).AddTicks(9399), 145, "Liczby zaprzyjaźnione" });

            migrationBuilder.InsertData(
                table: "Problems",
                columns: new[] { "ProblemId", "Answer", "Description", "Difficulty", "ReleaseDate", "SolvedBy", "Title" },
                values: new object[] { 9, "1366", "2^15 = 32768, a suma jej cyfr to 3 + 2 + 7 + 6 + 8 = 26.\nJaka jest suma cyfr liczby 2^1000?", 5, new DateTime(2021, 6, 14, 20, 47, 34, 656, DateTimeKind.Local).AddTicks(9389), 96, "Suma cyfr z potęgi" });

            migrationBuilder.InsertData(
                table: "Problems",
                columns: new[] { "ProblemId", "Answer", "Description", "Difficulty", "ReleaseDate", "SolvedBy", "Title" },
                values: new object[] { 8, "142913828922", "Suma liczb pierwszych poniżej 10 to 2 + 3 + 5 + 7 = 17.\nZnajdź sumę wszystkich liczb pierwszych poniżej dwóch milionów.", 5, new DateTime(2021, 6, 14, 20, 47, 34, 656, DateTimeKind.Local).AddTicks(9385), 104, "Specjalna trójka pitagorejska" });

            migrationBuilder.InsertData(
                table: "Problems",
                columns: new[] { "ProblemId", "Answer", "Description", "Difficulty", "ReleaseDate", "SolvedBy", "Title" },
                values: new object[] { 10, "648", "n! oznacza n × (n − 1) × ... × 3 × 2 × 1\nNa przykład 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,\na suma cyfr w liczbie 10! to 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.\nZnajdź sumę cyfr w liczbie 100!", 5, new DateTime(2021, 6, 14, 20, 47, 34, 656, DateTimeKind.Local).AddTicks(9395), 101, "Suma cyfr silni" });

            migrationBuilder.InsertData(
                table: "Problems",
                columns: new[] { "ProblemId", "Answer", "Description", "Difficulty", "ReleaseDate", "SolvedBy", "Title" },
                values: new object[] { 6, "104743", "Wymieniając sześć pierwszych liczb pierwszych: 2, 3, 5, 7, 11 i 13, widzimy, że szósta liczba pierwsza to 13.\nJaka jest 10001 liczba pierwsza?", 5, new DateTime(2021, 6, 14, 20, 47, 34, 656, DateTimeKind.Local).AddTicks(9377), 98, "10001 liczba pierwsza" });

            migrationBuilder.InsertData(
                table: "Problems",
                columns: new[] { "ProblemId", "Answer", "Description", "Difficulty", "ReleaseDate", "SolvedBy", "Title" },
                values: new object[] { 5, "232792560", "2520 to najmniejsza liczba, którą można podzielić przez każdą z liczb od 1 do 10 bez reszty.\nJaka jest najmniejsza liczba dodatnia, która jest podzielna bez reszt przez wszystkie liczby od 1 do 20?", 5, new DateTime(2021, 6, 14, 20, 47, 34, 656, DateTimeKind.Local).AddTicks(9369), 112, "Najmniejsza wielokrotność" });

            migrationBuilder.InsertData(
                table: "Problems",
                columns: new[] { "ProblemId", "Answer", "Description", "Difficulty", "ReleaseDate", "SolvedBy", "Title" },
                values: new object[] { 4, "906609", "Palindrom to wyrażenie brzmiące tak samo czytane od lewej do prawej i od prawej do lewej. Największy palindrom wykonany z iloczynu dwóch liczb dwucyfrowych to 9009 = 91 × 99.\nZnajdź największy palindrom wykonany z iloczynu dwóch 3-cyfrowych liczb.", 5, new DateTime(2021, 6, 14, 20, 47, 34, 656, DateTimeKind.Local).AddTicks(9365), 115, "Największy produkt palindromowy" });

            migrationBuilder.InsertData(
                table: "Problems",
                columns: new[] { "ProblemId", "Answer", "Description", "Difficulty", "ReleaseDate", "SolvedBy", "Title" },
                values: new object[] { 3, "6857", "Czynniki pierwsze liczby 13195 to 5, 7, 13 i 29.\nJaki jest największy czynnik pierwszy liczby 600851475143?", 5, new DateTime(2021, 6, 14, 20, 47, 34, 656, DateTimeKind.Local).AddTicks(9358), 95, "Największy czynnik pierwszy" });

            migrationBuilder.InsertData(
                table: "Problems",
                columns: new[] { "ProblemId", "Answer", "Description", "Difficulty", "ReleaseDate", "SolvedBy", "Title" },
                values: new object[] { 2, "4613732", "Każdy nowy wyraz w ciągu Fibonacciego jest generowany przez dodanie dwóch poprzednich wyrazów. Zaczynając od 1 i 2, pierwsze 10 terminów będzie:\n1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...\nRozważając wyrazy w ciągu Fibonacciego, których wartości nie przekraczają czterech milionów, znajdź sumę wyrazów o parzystych wartościach.", 5, new DateTime(2021, 6, 14, 20, 47, 34, 656, DateTimeKind.Local).AddTicks(9303), 101, "Parzyste liczby Fibonacciego" });

            migrationBuilder.InsertData(
                table: "Problems",
                columns: new[] { "ProblemId", "Answer", "Description", "Difficulty", "ReleaseDate", "SolvedBy", "Title" },
                values: new object[] { 7, "31875000", "Trójka pitagorejska to zbiór trzech liczb naturalnych, a < b < c, dla których: a^2 + b^2 = c^2Na przykład 3^2 + 4^2 = 9 + 16 = 25 = 5^2.Istnieje dokładnie jedna trójka pitagorejska, dla której a + b + c = 1000.Znajdź produkt a*b*c.", 5, new DateTime(2021, 6, 14, 20, 47, 34, 656, DateTimeKind.Local).AddTicks(9381), 102, "Sumowanie liczb pierwszych" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "TagName" },
                values: new object[] { 5, "Jednolinijkowiec" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "TagName" },
                values: new object[] { 1, "Matematyka" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "TagName" },
                values: new object[] { 2, "Programowanie" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "TagName" },
                values: new object[] { 3, "Programowanie Dynamiczne" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "TagName" },
                values: new object[] { 4, "Fizyka" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "TagName" },
                values: new object[] { 6, "Drzewa binarne" });
        }
    }
}
