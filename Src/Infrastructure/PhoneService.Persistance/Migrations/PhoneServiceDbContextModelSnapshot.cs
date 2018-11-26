﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhoneService.Persistance;

namespace PhoneService.Persistance.Migrations
{
    [DbContext(typeof(PhoneServiceDbContext))]
    partial class PhoneServiceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PhoneService.Domain.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CustomerId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("LastName");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNum");

                    b.Property<string>("TaxNum");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("PhoneService.Domain.CustomerAddres", b =>
                {
                    b.Property<int>("CustomerAddresId");

                    b.Property<string>("Adress");

                    b.Property<string>("City");

                    b.Property<string>("PostCode");

                    b.HasKey("CustomerAddresId");

                    b.ToTable("CustomerAddres");
                });

            modelBuilder.Entity("PhoneService.Domain.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Model");

                    b.Property<string>("Producer");

                    b.Property<int?>("RepairId");

                    b.HasKey("ProductId");

                    b.HasIndex("RepairId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("PhoneService.Domain.ProductSaparePart", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("SaparePartId");

                    b.HasKey("ProductId", "SaparePartId");

                    b.HasIndex("SaparePartId");

                    b.ToTable("ProductSapareParts");
                });

            modelBuilder.Entity("PhoneService.Domain.Repair", b =>
                {
                    b.Property<int>("RepairId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerId");

                    b.Property<string>("Description");

                    b.Property<int?>("ProductId");

                    b.Property<int?>("RepairStatusId");

                    b.HasKey("RepairId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.HasIndex("RepairStatusId");

                    b.ToTable("Repairs");
                });

            modelBuilder.Entity("PhoneService.Domain.RepairStatus", b =>
                {
                    b.Property<int>("RepairStatusId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("RepairStatusId");

                    b.ToTable("RepairStatuses");
                });

            modelBuilder.Entity("PhoneService.Domain.SaparePart", b =>
                {
                    b.Property<int>("SaparePartId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<string>("ReferenceNumebr");

                    b.Property<int?>("RepairId");

                    b.Property<int?>("SaparePartItemsSaparePArtItemId");

                    b.HasKey("SaparePartId");

                    b.HasIndex("RepairId");

                    b.HasIndex("SaparePartItemsSaparePArtItemId");

                    b.ToTable("SapareParts");
                });

            modelBuilder.Entity("PhoneService.Domain.SaparePartItem", b =>
                {
                    b.Property<int>("SaparePArtItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Quantity");

                    b.Property<int?>("RepairId");

                    b.Property<int?>("SeparePartSaparePartId");

                    b.HasKey("SaparePArtItemId");

                    b.HasIndex("RepairId");

                    b.HasIndex("SeparePartSaparePartId");

                    b.ToTable("SaparePartItems");
                });

            modelBuilder.Entity("PhoneService.Domain.CustomerAddres", b =>
                {
                    b.HasOne("PhoneService.Domain.Customer", "Customer")
                        .WithOne("Addres")
                        .HasForeignKey("PhoneService.Domain.CustomerAddres", "CustomerAddresId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PhoneService.Domain.Product", b =>
                {
                    b.HasOne("PhoneService.Domain.Repair")
                        .WithMany("Products")
                        .HasForeignKey("RepairId");
                });

            modelBuilder.Entity("PhoneService.Domain.ProductSaparePart", b =>
                {
                    b.HasOne("PhoneService.Domain.Product", "Product")
                        .WithMany("ProductSapareParts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PhoneService.Domain.SaparePart", "SaparePart")
                        .WithMany("ProductSapareParts")
                        .HasForeignKey("SaparePartId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PhoneService.Domain.Repair", b =>
                {
                    b.HasOne("PhoneService.Domain.Customer", "Customer")
                        .WithMany("RepairsList")
                        .HasForeignKey("CustomerId");

                    b.HasOne("PhoneService.Domain.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("PhoneService.Domain.RepairStatus", "RepairStatus")
                        .WithMany("Repairs")
                        .HasForeignKey("RepairStatusId");
                });

            modelBuilder.Entity("PhoneService.Domain.SaparePart", b =>
                {
                    b.HasOne("PhoneService.Domain.Repair")
                        .WithMany("SapareParts")
                        .HasForeignKey("RepairId");

                    b.HasOne("PhoneService.Domain.SaparePartItem", "SaparePartItems")
                        .WithMany("SapareParts")
                        .HasForeignKey("SaparePartItemsSaparePArtItemId");
                });

            modelBuilder.Entity("PhoneService.Domain.SaparePartItem", b =>
                {
                    b.HasOne("PhoneService.Domain.Repair")
                        .WithMany("SaparePartItem")
                        .HasForeignKey("RepairId");

                    b.HasOne("PhoneService.Domain.SaparePart", "SeparePart")
                        .WithMany()
                        .HasForeignKey("SeparePartSaparePartId");
                });
#pragma warning restore 612, 618
        }
    }
}
