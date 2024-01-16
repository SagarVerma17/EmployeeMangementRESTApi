﻿// <auto-generated />
using System;
using EmployeeRESTApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeRESTApi.Migrations
{
    [DbContext(typeof(EmployeeContext))]
    [Migration("20240109123635_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployeeRESTApi.Models.Employee", b =>
                {
                    b.Property<int>("EmpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmpId"));

                    b.Property<string>("EmpAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmpAge")
                        .HasColumnType("int");

                    b.Property<string>("EmpDeptNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("EmpMobileNo")
                        .HasColumnType("bigint");

                    b.Property<string>("EmpName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("JoiningDate")
                        .HasColumnType("datetime2");

                    b.HasKey("EmpId");

                    b.ToTable("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
