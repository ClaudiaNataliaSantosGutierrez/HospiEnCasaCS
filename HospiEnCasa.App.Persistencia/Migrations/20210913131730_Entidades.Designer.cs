﻿// <auto-generated />
using System;
using HospiEnCasa.App.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HospiEnCasa.App.Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20210913131730_Entidades")]
    partial class Entidades
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("HospiEnCasa.App.Dominio.Historia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Diagnostico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Entorno")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Historias");
                });

            modelBuilder.Entity("HospiEnCasa.App.Dominio.Persona", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Genero")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroTelefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Personas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("HospiEnCasa.App.Dominio.SignoVital", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("FechaHora")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Pacienteid")
                        .HasColumnType("int");

                    b.Property<int>("Signo")
                        .HasColumnType("int");

                    b.Property<float>("Valor")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("Pacienteid");

                    b.ToTable("SignosVitales");
                });

            modelBuilder.Entity("HospiEnCasa.App.Dominio.SugerenciaCuidado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaHora")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HistoriaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HistoriaId");

                    b.ToTable("SugerenciasCuidado");
                });

            modelBuilder.Entity("HospiEnCasa.App.Dominio.Enfermera", b =>
                {
                    b.HasBaseType("HospiEnCasa.App.Dominio.Persona");

                    b.Property<int>("HorasLaborales")
                        .HasColumnType("int");

                    b.Property<string>("TarjetaProfesional")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Enfermera");
                });

            modelBuilder.Entity("HospiEnCasa.App.Dominio.FamiliarDesignado", b =>
                {
                    b.HasBaseType("HospiEnCasa.App.Dominio.Persona");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Parentesco")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("FamiliarDesignado");
                });

            modelBuilder.Entity("HospiEnCasa.App.Dominio.Medico", b =>
                {
                    b.HasBaseType("HospiEnCasa.App.Dominio.Persona");

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Especialidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistroRethus")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Medico");
                });

            modelBuilder.Entity("HospiEnCasa.App.Dominio.Paciente", b =>
                {
                    b.HasBaseType("HospiEnCasa.App.Dominio.Persona");

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Enfermeraid")
                        .HasColumnType("int");

                    b.Property<int?>("Familiarid")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HistoriaId")
                        .HasColumnType("int");

                    b.Property<float>("Latitud")
                        .HasColumnType("real");

                    b.Property<float>("Longitud")
                        .HasColumnType("real");

                    b.Property<int?>("Medicoid")
                        .HasColumnType("int");

                    b.HasIndex("Enfermeraid");

                    b.HasIndex("Familiarid");

                    b.HasIndex("HistoriaId");

                    b.HasIndex("Medicoid");

                    b.HasDiscriminator().HasValue("Paciente");
                });

            modelBuilder.Entity("HospiEnCasa.App.Dominio.SignoVital", b =>
                {
                    b.HasOne("HospiEnCasa.App.Dominio.Paciente", null)
                        .WithMany("SignosVitales")
                        .HasForeignKey("Pacienteid");
                });

            modelBuilder.Entity("HospiEnCasa.App.Dominio.SugerenciaCuidado", b =>
                {
                    b.HasOne("HospiEnCasa.App.Dominio.Historia", null)
                        .WithMany("Sugerencias")
                        .HasForeignKey("HistoriaId");
                });

            modelBuilder.Entity("HospiEnCasa.App.Dominio.Paciente", b =>
                {
                    b.HasOne("HospiEnCasa.App.Dominio.Enfermera", "Enfermera")
                        .WithMany()
                        .HasForeignKey("Enfermeraid");

                    b.HasOne("HospiEnCasa.App.Dominio.FamiliarDesignado", "Familiar")
                        .WithMany()
                        .HasForeignKey("Familiarid");

                    b.HasOne("HospiEnCasa.App.Dominio.Historia", "Historia")
                        .WithMany()
                        .HasForeignKey("HistoriaId");

                    b.HasOne("HospiEnCasa.App.Dominio.Medico", "Medico")
                        .WithMany()
                        .HasForeignKey("Medicoid");

                    b.Navigation("Enfermera");

                    b.Navigation("Familiar");

                    b.Navigation("Historia");

                    b.Navigation("Medico");
                });

            modelBuilder.Entity("HospiEnCasa.App.Dominio.Historia", b =>
                {
                    b.Navigation("Sugerencias");
                });

            modelBuilder.Entity("HospiEnCasa.App.Dominio.Paciente", b =>
                {
                    b.Navigation("SignosVitales");
                });
#pragma warning restore 612, 618
        }
    }
}
