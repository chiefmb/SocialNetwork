﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SocialNetwork.Data;

namespace SocialNetwork.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20191212061707_set_follow_requireds")]
    partial class set_follow_requireds
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GSN.Models.Follow", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FollowedId")
                        .HasColumnType("int");

                    b.Property<int>("FollowerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FollowedId");

                    b.HasIndex("FollowerId");

                    b.ToTable("Follows");
                });

            modelBuilder.Entity("GSN.Models.Like", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LikerId")
                        .HasColumnType("int");

                    b.Property<long>("PostId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("LikerId");

                    b.HasIndex("PostId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("GSN.Models.Post", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("SenderId");

                    b.HasIndex("Time");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Gihan.Identity.Models.AccessToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("ExpiresTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastLoginIp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("LastLoginTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastLoginUserAgent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AccessTokens");
                });

            modelBuilder.Entity("Gihan.Identity.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Gihan.Identity.Models.UserBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<bool>("MobileNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("IsActive");

                    b.HasIndex("MobileNumber")
                        .IsUnique()
                        .HasFilter("[MobileNumber] IS NOT NULL");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Accounts");

                    b.HasDiscriminator<string>("Discriminator").HasValue("UserBase");
                });

            modelBuilder.Entity("Gihan.Identity.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("JoinTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("GSN.Models.User", b =>
                {
                    b.HasBaseType("Gihan.Identity.Models.UserBase");

                    b.ToTable("Accounts");

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("GSN.Models.Follow", b =>
                {
                    b.HasOne("GSN.Models.User", "Followed")
                        .WithMany("FollowedFollows")
                        .HasForeignKey("FollowedId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GSN.Models.User", "Follower")
                        .WithMany("FollowerFollows")
                        .HasForeignKey("FollowerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("GSN.Models.Like", b =>
                {
                    b.HasOne("GSN.Models.User", "Liker")
                        .WithMany("Likes")
                        .HasForeignKey("LikerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GSN.Models.Post", "Post")
                        .WithMany("Likes")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("GSN.Models.Post", b =>
                {
                    b.HasOne("GSN.Models.Post", "Parent")
                        .WithMany("Comments")
                        .HasForeignKey("ParentId");

                    b.HasOne("GSN.Models.User", "Sender")
                        .WithMany("Posts")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Gihan.Identity.Models.AccessToken", b =>
                {
                    b.HasOne("Gihan.Identity.Models.UserBase", "User")
                        .WithMany("AccessTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Gihan.Identity.Models.UserRole", b =>
                {
                    b.HasOne("Gihan.Identity.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gihan.Identity.Models.UserBase", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
