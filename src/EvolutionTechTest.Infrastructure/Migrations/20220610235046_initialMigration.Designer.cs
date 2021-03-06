// <auto-generated />
using System;
using EvolutionTechTest.Infrastructure.Respositories.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EvolutionTechTest.Infrastructure.Migrations
{
    [DbContext(typeof(EvolutionTestContext))]
    [Migration("20220610235046_initialMigration")]
    partial class initialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("money")
                        .HasColumnName("PedSubTot");

                    b.Property<decimal>("UnitValue")
                        .HasColumnType("money")
                        .HasColumnName("PedVrUnit");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

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

            modelBuilder.Entity("EvolutionTechTest.Core.Entities.Order", b =>
                {
                    b.HasOne("EvolutionTechTest.Core.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("EvolutionTechTest.Core.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Product");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
