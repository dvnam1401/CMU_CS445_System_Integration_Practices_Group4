﻿// <auto-generated />
using DashBoard.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DashBoard.API.Migrations.Mysql
{
    [DbContext(typeof(MysqlContext))]
    [Migration("20240309141005_v0")]
    partial class v0
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");
#pragma warning restore 612, 618
        }
    }
}
