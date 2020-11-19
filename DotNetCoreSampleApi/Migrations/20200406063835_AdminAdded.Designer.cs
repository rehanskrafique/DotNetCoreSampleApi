﻿// <auto-generated />
using System;
using DotNetCoreSampleApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DotNetCoreSampleApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200406063835_AdminAdded")]
    partial class AdminAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DotNetCoreSampleApi.Domains.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastModifiedOnUtc")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CategoryId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("LastModifiedBy");

                    b.HasIndex("ParentId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DotNetCoreSampleApi.Domains.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastModifiedOnUtc")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("LastModifiedBy");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DotNetCoreSampleApi.Domains.Role", b =>
                {
                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("NormalizedName")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = new Guid("846e64ff-5bd9-43b9-a6b1-8a2e3c0f6c54"),
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            RoleId = new Guid("f9ca24f3-8b65-4cda-ad27-4533d8cedb70"),
                            Name = "Customer",
                            NormalizedName = "CUSTOMER"
                        });
                });

            modelBuilder.Entity("DotNetCoreSampleApi.Domains.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastModifiedOnUtc")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("UserId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("LastModifiedBy");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("211f6640-810a-466b-818f-ca153e382072"),
                            ContactNumber = "0987654321",
                            CreatedBy = new Guid("211f6640-810a-466b-818f-ca153e382072"),
                            CreatedOnUtc = new DateTime(2020, 4, 6, 6, 38, 33, 258, DateTimeKind.Utc).AddTicks(818),
                            EmailId = "admin@7techitservices.com",
                            IsActive = true,
                            Name = "Admin",
                            Password = "123456",
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("DotNetCoreSampleApi.Domains.UserRole", b =>
                {
                    b.Property<Guid>("UserRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserRoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("DotNetCoreSampleApi.Domains.UserToken", b =>
                {
                    b.Property<Guid>("UserTokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ExpiresOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("IPAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("IssuedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<string>("UserAgent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserTokenId");

                    b.HasIndex("UserId");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("DotNetCoreSampleApi.Domains.Category", b =>
                {
                    b.HasOne("DotNetCoreSampleApi.Domains.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DotNetCoreSampleApi.Domains.User", "LastModifiedByUser")
                        .WithMany()
                        .HasForeignKey("LastModifiedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DotNetCoreSampleApi.Domains.Category", "ParentCategory")
                        .WithMany()
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DotNetCoreSampleApi.Domains.Product", b =>
                {
                    b.HasOne("DotNetCoreSampleApi.Domains.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DotNetCoreSampleApi.Domains.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DotNetCoreSampleApi.Domains.User", "LastModifiedByUser")
                        .WithMany()
                        .HasForeignKey("LastModifiedBy")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DotNetCoreSampleApi.Domains.User", b =>
                {
                    b.HasOne("DotNetCoreSampleApi.Domains.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DotNetCoreSampleApi.Domains.User", "LastModifiedByUser")
                        .WithMany()
                        .HasForeignKey("LastModifiedBy")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DotNetCoreSampleApi.Domains.UserRole", b =>
                {
                    b.HasOne("DotNetCoreSampleApi.Domains.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DotNetCoreSampleApi.Domains.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DotNetCoreSampleApi.Domains.UserToken", b =>
                {
                    b.HasOne("DotNetCoreSampleApi.Domains.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
