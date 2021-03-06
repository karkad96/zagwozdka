// <auto-generated />
using System;
using Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Backend.Data.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210614184735_AddNewSeeds2")]
    partial class AddNewSeeds2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("Backend.Models.Joins.PostUserLike", b =>
                {
                    b.Property<int>("PostId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Likes")
                        .HasColumnType("INTEGER");

                    b.HasKey("PostId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("PostUserLikes");
                });

            modelBuilder.Entity("Backend.Models.Joins.PostUserReport", b =>
                {
                    b.Property<int>("PostId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Report")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PostId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("PostUserReports");
                });

            modelBuilder.Entity("Backend.Models.Joins.ProblemTag", b =>
                {
                    b.Property<int>("ProblemId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TagId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProblemId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("ProblemTags");
                });

            modelBuilder.Entity("Backend.Models.Joins.ProblemUser", b =>
                {
                    b.Property<int>("ProblemId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("SolvedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("ProblemId", "Id");

                    b.HasIndex("Id");

                    b.ToTable("ProblemUsers");
                });

            modelBuilder.Entity("Backend.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Likes")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("PostDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProblemId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Reports")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PostId");

                    b.HasIndex("ProblemId");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Backend.Models.Problem", b =>
                {
                    b.Property<int>("ProblemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Difficulty")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("SolvedBy")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ProblemId");

                    b.ToTable("Problems");

                    b.HasData(
                        new
                        {
                            ProblemId = 1,
                            Answer = "233168",
                            Description = "Jeśli wymienimy wszystkie liczby naturalne poniżej 10, które są wielokrotnościami 3 lub 5, otrzymamy 3, 5, 6 i 9. Suma tych wielokrotności wynosi 23.\n Znajdź sumę wszystkich wielokrotności 3 lub 5 poniżej 1000.",
                            Difficulty = 5,
                            ReleaseDate = new DateTime(2021, 6, 14, 20, 47, 34, 652, DateTimeKind.Local).AddTicks(881),
                            SolvedBy = 112,
                            Title = "Wielokrotność 3 i 5"
                        },
                        new
                        {
                            ProblemId = 2,
                            Answer = "4613732",
                            Description = "Każdy nowy wyraz w ciągu Fibonacciego jest generowany przez dodanie dwóch poprzednich wyrazów. Zaczynając od 1 i 2, pierwsze 10 terminów będzie:\n1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...\nRozważając wyrazy w ciągu Fibonacciego, których wartości nie przekraczają czterech milionów, znajdź sumę wyrazów o parzystych wartościach.",
                            Difficulty = 5,
                            ReleaseDate = new DateTime(2021, 6, 14, 20, 47, 34, 656, DateTimeKind.Local).AddTicks(9303),
                            SolvedBy = 101,
                            Title = "Parzyste liczby Fibonacciego"
                        },
                        new
                        {
                            ProblemId = 3,
                            Answer = "6857",
                            Description = "Czynniki pierwsze liczby 13195 to 5, 7, 13 i 29.\nJaki jest największy czynnik pierwszy liczby 600851475143?",
                            Difficulty = 5,
                            ReleaseDate = new DateTime(2021, 6, 14, 20, 47, 34, 656, DateTimeKind.Local).AddTicks(9358),
                            SolvedBy = 95,
                            Title = "Największy czynnik pierwszy"
                        },
                        new
                        {
                            ProblemId = 4,
                            Answer = "906609",
                            Description = "Palindrom to wyrażenie brzmiące tak samo czytane od lewej do prawej i od prawej do lewej. Największy palindrom wykonany z iloczynu dwóch liczb dwucyfrowych to 9009 = 91 × 99.\nZnajdź największy palindrom wykonany z iloczynu dwóch 3-cyfrowych liczb.",
                            Difficulty = 5,
                            ReleaseDate = new DateTime(2021, 6, 14, 20, 47, 34, 656, DateTimeKind.Local).AddTicks(9365),
                            SolvedBy = 115,
                            Title = "Największy produkt palindromowy"
                        },
                        new
                        {
                            ProblemId = 5,
                            Answer = "232792560",
                            Description = "2520 to najmniejsza liczba, którą można podzielić przez każdą z liczb od 1 do 10 bez reszty.\nJaka jest najmniejsza liczba dodatnia, która jest podzielna bez reszt przez wszystkie liczby od 1 do 20?",
                            Difficulty = 5,
                            ReleaseDate = new DateTime(2021, 6, 14, 20, 47, 34, 656, DateTimeKind.Local).AddTicks(9369),
                            SolvedBy = 112,
                            Title = "Najmniejsza wielokrotność"
                        },
                        new
                        {
                            ProblemId = 6,
                            Answer = "104743",
                            Description = "Wymieniając sześć pierwszych liczb pierwszych: 2, 3, 5, 7, 11 i 13, widzimy, że szósta liczba pierwsza to 13.\nJaka jest 10001 liczba pierwsza?",
                            Difficulty = 5,
                            ReleaseDate = new DateTime(2021, 6, 14, 20, 47, 34, 656, DateTimeKind.Local).AddTicks(9377),
                            SolvedBy = 98,
                            Title = "10001 liczba pierwsza"
                        },
                        new
                        {
                            ProblemId = 7,
                            Answer = "31875000",
                            Description = "Trójka pitagorejska to zbiór trzech liczb naturalnych, a < b < c, dla których: a^2 + b^2 = c^2Na przykład 3^2 + 4^2 = 9 + 16 = 25 = 5^2.Istnieje dokładnie jedna trójka pitagorejska, dla której a + b + c = 1000.Znajdź produkt a*b*c.",
                            Difficulty = 5,
                            ReleaseDate = new DateTime(2021, 6, 14, 20, 47, 34, 656, DateTimeKind.Local).AddTicks(9381),
                            SolvedBy = 102,
                            Title = "Sumowanie liczb pierwszych"
                        },
                        new
                        {
                            ProblemId = 8,
                            Answer = "142913828922",
                            Description = "Suma liczb pierwszych poniżej 10 to 2 + 3 + 5 + 7 = 17.\nZnajdź sumę wszystkich liczb pierwszych poniżej dwóch milionów.",
                            Difficulty = 5,
                            ReleaseDate = new DateTime(2021, 6, 14, 20, 47, 34, 656, DateTimeKind.Local).AddTicks(9385),
                            SolvedBy = 104,
                            Title = "Specjalna trójka pitagorejska"
                        },
                        new
                        {
                            ProblemId = 9,
                            Answer = "1366",
                            Description = "2^15 = 32768, a suma jej cyfr to 3 + 2 + 7 + 6 + 8 = 26.\nJaka jest suma cyfr liczby 2^1000?",
                            Difficulty = 5,
                            ReleaseDate = new DateTime(2021, 6, 14, 20, 47, 34, 656, DateTimeKind.Local).AddTicks(9389),
                            SolvedBy = 96,
                            Title = "Suma cyfr z potęgi"
                        },
                        new
                        {
                            ProblemId = 10,
                            Answer = "648",
                            Description = "n! oznacza n × (n − 1) × ... × 3 × 2 × 1\nNa przykład 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,\na suma cyfr w liczbie 10! to 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.\nZnajdź sumę cyfr w liczbie 100!",
                            Difficulty = 5,
                            ReleaseDate = new DateTime(2021, 6, 14, 20, 47, 34, 656, DateTimeKind.Local).AddTicks(9395),
                            SolvedBy = 101,
                            Title = "Suma cyfr silni"
                        },
                        new
                        {
                            ProblemId = 11,
                            Answer = "31626",
                            Description = "Niech d(n) będzie zdefiniowana jako suma właściwych dzielników n (liczby mniejsze od n, które dzielą się bez reszty z n).Jeśli d(a) = b i d(b) = a, gdzie a != b, to a i b są parą zaprzyjaźnioną i każde z a i b nazywa się liczbami zaprzyjaźnionymi.\nNa przykład właściwymi dzielnikami liczby 220 są 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 i 110; zatem d(220) = 284. Właściwymi dzielnikami 284 są 1, 2, 4, 71 i 142; więc d(284) = 220.\nOblicz sumę wszystkich liczb zaprzyjaźnionych poniżej 10000.",
                            Difficulty = 5,
                            ReleaseDate = new DateTime(2021, 6, 14, 20, 47, 34, 656, DateTimeKind.Local).AddTicks(9399),
                            SolvedBy = 145,
                            Title = "Liczby zaprzyjaźnione"
                        },
                        new
                        {
                            ProblemId = 12,
                            Answer = "31626",
                            Description = "Permutacja to uporządkowany układ obiektów. Na przykład 3124 jest jedną z możliwych permutacji cyfr 1, 2, 3 i 4. Jeśli wszystkie permutacje są wymienione numerycznie lub alfabetycznie, nazywamy to porządkiem leksykograficznym. Leksykograficzne permutacje 0, 1 i 2 to:\n012 021 102 120 201 210Jaka jest milionowa permutacja leksykograficzna cyfr 0, 1, 2, 3, 4, 5, 6, 7, 8 i 9?",
                            Difficulty = 5,
                            ReleaseDate = new DateTime(2021, 6, 14, 20, 47, 34, 656, DateTimeKind.Local).AddTicks(9403),
                            SolvedBy = 145,
                            Title = "Permutacje leksykograficzne"
                        },
                        new
                        {
                            ProblemId = 13,
                            Answer = "73682",
                            Description = "W Polsce waluta składa się ze złotówki (zł) i grosza (gr). W powszechnym obiegu znajduje się dziewięc monet:\n1gr, 2gr, 5gr, 10gr, 20gr, 50gr, 1zł (100gr), 2zł (200gr) i 5zł (500gr).\n5zł można rozmienić w następujący sposób:\n1×2zł + 2×1zł + 1×50gr + 2×20gr + 1×5gr + 1×2gr + 3×1gr\nNa ile różnych sposobów można rozimenić 5zł przy użyciu dowolnej liczby monet?\n",
                            Difficulty = 15,
                            ReleaseDate = new DateTime(2021, 6, 14, 20, 47, 34, 656, DateTimeKind.Local).AddTicks(9407),
                            SolvedBy = 87,
                            Title = "Suma monet"
                        });
                });

            modelBuilder.Entity("Backend.Models.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TagId");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            TagId = 1,
                            TagName = "Matematyka"
                        },
                        new
                        {
                            TagId = 2,
                            TagName = "Programowanie"
                        },
                        new
                        {
                            TagId = 3,
                            TagName = "Programowanie Dynamiczne"
                        },
                        new
                        {
                            TagId = 4,
                            TagName = "Fizyka"
                        },
                        new
                        {
                            TagId = 5,
                            TagName = "Jednolinijkowiec"
                        },
                        new
                        {
                            TagId = 6,
                            TagName = "Drzewa binarne"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Backend.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("ExtraInfo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ProgramingLanguage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Backend.Models.Joins.PostUserLike", b =>
                {
                    b.HasOne("Backend.Models.Post", "Post")
                        .WithMany("PostUserLikes")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("PostUserLikes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Backend.Models.Joins.PostUserReport", b =>
                {
                    b.HasOne("Backend.Models.Post", "Post")
                        .WithMany("PostUserReports")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("PostUserReports")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Backend.Models.Joins.ProblemTag", b =>
                {
                    b.HasOne("Backend.Models.Problem", "Problem")
                        .WithMany("ProblemTags")
                        .HasForeignKey("ProblemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.Tag", "Tag")
                        .WithMany("ProblemTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Problem");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Backend.Models.Joins.ProblemUser", b =>
                {
                    b.HasOne("Backend.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("ProblemUsers")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.Problem", "Problem")
                        .WithMany("ProblemUsers")
                        .HasForeignKey("ProblemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Problem");
                });

            modelBuilder.Entity("Backend.Models.Post", b =>
                {
                    b.HasOne("Backend.Models.Problem", "Problem")
                        .WithMany("Posts")
                        .HasForeignKey("ProblemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Problem");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Models.Post", b =>
                {
                    b.Navigation("PostUserLikes");

                    b.Navigation("PostUserReports");
                });

            modelBuilder.Entity("Backend.Models.Problem", b =>
                {
                    b.Navigation("Posts");

                    b.Navigation("ProblemTags");

                    b.Navigation("ProblemUsers");
                });

            modelBuilder.Entity("Backend.Models.Tag", b =>
                {
                    b.Navigation("ProblemTags");
                });

            modelBuilder.Entity("Backend.Models.ApplicationUser", b =>
                {
                    b.Navigation("Posts");

                    b.Navigation("PostUserLikes");

                    b.Navigation("PostUserReports");

                    b.Navigation("ProblemUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
