﻿// <auto-generated />
using APIA.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace APIA.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190808000738_ADVC")]
    partial class ADVC
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APIA.Models.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Cnpj");

                    b.Property<string>("Estado");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("APIA.Models.Processo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataInicio");

                    b.Property<string>("Estado");

                    b.Property<int>("IdEmpresa");

                    b.Property<bool>("IsAtivo");

                    b.Property<string>("NumeroProcesso");

                    b.Property<decimal>("Valor");

                    b.HasKey("Id");

                    b.ToTable("Processos");
                });
#pragma warning restore 612, 618
        }
    }
}
