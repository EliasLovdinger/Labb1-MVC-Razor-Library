﻿// <auto-generated />
using System;
using Labb1_MVC_Razor.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Labb1_MVC_Razor.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Labb1_MVC_Razor.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            Amount = 10,
                            Description = "The popular paperback edition of J.R.R. Tolkien's classic masterpiece, illustrated for the first time with Tolkien's own painting originally created by him for the first edition, and featuring brand new reproductions of all his drawings and maps. The Hobbit is a tale of high adventure, undertaken by a company of dwarves in search of dragon-guarded gold. A reluctant partner in this perilous quest is Bilbo Baggins, a comfort-loving unambitious hobbit, who surprises even himself by his resourcefulness and skill as a burglar. Encounters with trolls, goblins, dwarves, elves and giant spiders, conversations with the dragon, Smaug, and a rather unwilling presence at the Battle of Five Armies are just some of the adventures that befall Bilbo. Bilbo Baggins has taken his place among the ranks of the immortals of children's fiction. Written by Professor Tolkien for his own children, The Hobbit met with instant critical acclaim when published.\r\n",
                            Title = "The Hobbit"
                        },
                        new
                        {
                            BookId = 2,
                            Amount = 5,
                            Description = "The first part of J. R. R. Tolkien's epic adventureTHE LORD OF THE RINGS'A most remarkable feat'GuardianIn a sleepy village in the Shire, a young hobbit is entrusted with an immense task. He must make a perilous journey across Middle-earth to the Cracks of Doom, there to destroy the Ruling Ring of Power - the only thing that prevents the Dark Lord Sauron's evil dominion.Thus begins J. R. R. Tolkien's classic tale of adventure, which continues in The Two Towers and The Return of the King.",
                            Title = "Fellowship of the Ring"
                        },
                        new
                        {
                            BookId = 3,
                            Amount = 10,
                            Description = "The second part of J.R.R. Tolkien's epic adventureTHE LORD OF THE RINGS'Among the greatest works of imaginative fiction of the twentieth century.'Sunday TelegraphThe company of the Ring is torn asunder. Frodo and Sam continue their journey alone down the great River Anduin - alone, that is, save for the mysterious creeping figure that follows wherever they go.This continues the classic tale begun in The Fellowship of the Ring, which reaches its awesome climax in The Return of the King.\r\nKundrecensioner",
                            Title = "Two Towers"
                        },
                        new
                        {
                            BookId = 4,
                            Amount = 7,
                            Description = "The third part of J.R.R. Tolkien's epic adventureTHE LORD OF THE RINGS'Extraordinarily imaginative, and wholly exciting'The TimesThe armies of the Dark Lord are massing as his evil shadow spreads even wider. Men, Dwarves, Elves and Ents unite forces to battle against the Dark. Meanwhile, Frodo and Sam struggle further into Mordor in their heroic quest to destroy the One Ring.The devastating conclusion of J.R.R. Tolkien's classic tale of adventure, begun in The Fellowship of the Ring and The Two Towers.",
                            Title = "Return of the King"
                        },
                        new
                        {
                            BookId = 5,
                            Amount = 5,
                            Description = "Four-volume boxed-set edition of The Lord of the Rings in hardback, featuring Tolkien's original unused dust-jacket designs, together with fourth hardback volume, The Lord of the Rings: A Reader's Companion. Includes special features and the definitive edition of the text. Since it was first published in 1954, The Lord of the Rings has been a book people have treasured. Steeped in unrivalled magic and otherworldliness, its sweeping fantasy has touched the hearts of young and old alike, with one hundred and fifty million copies of its many editions sold around the world. In 2005 Tolkien's text was fully restored - with the full co-operation of Christopher Tolkien - with almost 400 corrections, the original red and black maps as fold-out sheets, a fully revised and enlarged index, and for the first time a special plate section containing the pages from the Book of Mazarbul, making this set as close as possible to the version that J.R.R. Tolkien intended. This Diamond Anniversary reissue of the prized boxed set marks 60 years since the first publication of The Fellowship of the Ring. These hardback editions feature Tolkien's original unused dust-jacket designs from the 1950s, reworked for this edition, and some additional text corrections. The four-volume boxed set includes The Lord of the Rings: A Reader's Companion, a unique annotated guide to the text, fully updated since its first publication in 2005, and is a book which will enhance the reader's enjoyment and understanding of one of the most influential books of the 20th century.",
                            Title = "The Lord of the Rings Boxed Set"
                        });
                });

            modelBuilder.Entity("Labb1_MVC_Razor.Models.CartItem", b =>
                {
                    b.Property<int>("CartItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartItemId"), 1L, 1);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("CartId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CartItemId");

                    b.HasIndex("BookId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("Labb1_MVC_Razor.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Labb1_MVC_Razor.Models.RentBook", b =>
                {
                    b.Property<int>("RentBookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RentBookId"), 1L, 1);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RentedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.HasKey("RentBookId");

                    b.HasIndex("CustomerId");

                    b.ToTable("RentBooks");
                });

            modelBuilder.Entity("Labb1_MVC_Razor.Models.RentBookDetail", b =>
                {
                    b.Property<int>("RentBookDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RentBookDetailId"), 1L, 1);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("RentBookId")
                        .HasColumnType("int");

                    b.HasKey("RentBookDetailId");

                    b.HasIndex("BookId");

                    b.HasIndex("RentBookId");

                    b.ToTable("RentBookDetails");
                });

            modelBuilder.Entity("Labb1_MVC_Razor.Models.CartItem", b =>
                {
                    b.HasOne("Labb1_MVC_Razor.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Labb1_MVC_Razor.Models.RentBook", b =>
                {
                    b.HasOne("Labb1_MVC_Razor.Models.Customer", "Customer")
                        .WithMany("RentBook")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Labb1_MVC_Razor.Models.RentBookDetail", b =>
                {
                    b.HasOne("Labb1_MVC_Razor.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labb1_MVC_Razor.Models.RentBook", "RentBook")
                        .WithMany("RentBookDetails")
                        .HasForeignKey("RentBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("RentBook");
                });

            modelBuilder.Entity("Labb1_MVC_Razor.Models.Customer", b =>
                {
                    b.Navigation("RentBook");
                });

            modelBuilder.Entity("Labb1_MVC_Razor.Models.RentBook", b =>
                {
                    b.Navigation("RentBookDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
