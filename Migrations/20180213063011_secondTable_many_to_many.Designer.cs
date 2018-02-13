﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using Vue2Spa.Models;

namespace Vue2Spa.Migrations
{
    [DbContext(typeof(MyDataContext))]
    [Migration("20180213063011_secondTable_many_to_many")]
    partial class secondTable_many_to_many
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Vue2Spa.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Vue2Spa.Models.MyData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("MyDatas");
                });

            modelBuilder.Entity("Vue2Spa.Models.MyDataCategory", b =>
                {
                    b.Property<int>("MyDataId");

                    b.Property<int>("CategoryId");

                    b.HasKey("MyDataId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("MyDataCategory");
                });

            modelBuilder.Entity("Vue2Spa.Models.MyDataCategory", b =>
                {
                    b.HasOne("Vue2Spa.Models.Category", "Category")
                        .WithMany("MyDataCategory")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Vue2Spa.Models.MyData", "MyData")
                        .WithMany("MyDataCategory")
                        .HasForeignKey("MyDataId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
