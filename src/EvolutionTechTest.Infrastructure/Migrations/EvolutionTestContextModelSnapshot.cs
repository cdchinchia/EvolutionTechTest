﻿// <auto-generated />
using EvolutionTechTest.Infrastructure.Respositories.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EvolutionTechTest.Infrastructure.Migrations
{
    [DbContext(typeof(EvolutionTestContext))]
    partial class EvolutionTestContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EvolutionTechTest.Core.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PedID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<float>("Amount")
                        .HasColumnType("real")
                        .HasColumnName("PedCant");

                    b.Property<float>("IVA")
                        .HasColumnType("real")
                        .HasColumnName("PedIVA");

                    b.Property<int>("OrderProductId")
                        .HasColumnType("int")
                        .HasColumnName("PedProd");

                    b.Property<int>("OrderUserId")
                        .HasColumnType("int")
                        .HasColumnName("PedUsu");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("money")
                        .HasColumnName("PedSubTot");

                    b.Property<decimal>("Total")
                        .HasColumnType("money")
                        .HasColumnName("PedTotal");

                    b.Property<decimal>("UnitValue")
                        .HasColumnType("money")
                        .HasColumnName("PedVrUnit");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("EvolutionTechTest.Core.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ProDesc");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ProNombre");

                    b.Property<decimal>("Value")
                        .HasColumnType("money")
                        .HasColumnName("ProValor");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EvolutionTechTest.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UsuID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("UsuNombre");

                    b.Property<string>("Password")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("UsuPass");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
