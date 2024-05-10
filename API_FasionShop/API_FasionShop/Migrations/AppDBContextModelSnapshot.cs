﻿// <auto-generated />
using System;
using API_FashionShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_FashionShop.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("API_FashionShop.Models.BaiViet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdNV")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayViet")
                        .HasColumnType("DATE");

                    b.Property<string>("NoiDung")
                        .HasColumnType("longtext");

                    b.Property<string>("TieuDe")
                        .HasColumnType("longtext");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("BaiViets");
                });

            modelBuilder.Entity("API_FashionShop.Models.CTGHang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdCTSP")
                        .HasColumnType("int");

                    b.Property<int>("IdGh")
                        .HasColumnType("int");

                    b.Property<string>("MauSac")
                        .HasColumnType("longtext");

                    b.Property<string>("Size")
                        .HasColumnType("longtext");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CTGHangs");
                });

            modelBuilder.Entity("API_FashionShop.Models.CTHDBan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdCTSPham")
                        .HasColumnType("int");

                    b.Property<int>("IdHDBan")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CTHDBans");
                });

            modelBuilder.Entity("API_FashionShop.Models.CTHDNhap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("GiaNhap")
                        .HasColumnType("int");

                    b.Property<int>("IdCTSPham")
                        .HasColumnType("int");

                    b.Property<int>("IdHDNhap")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CTHDNhaps");
                });

            modelBuilder.Entity("API_FashionShop.Models.CTSPham", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("HinhAnh")
                        .HasColumnType("longtext");

                    b.Property<int>("IdSanPham")
                        .HasColumnType("int");

                    b.Property<string>("MauSac")
                        .HasColumnType("longtext");

                    b.Property<string>("Size")
                        .HasColumnType("longtext");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("CTSPhams");
                });

            modelBuilder.Entity("API_FashionShop.Models.DiaChi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DiaChiNH")
                        .HasColumnType("longtext");

                    b.Property<string>("GhiChu")
                        .HasColumnType("longtext");

                    b.Property<int>("IdKH")
                        .HasColumnType("int");

                    b.Property<string>("SoDT")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("DiaChis");
                });

            modelBuilder.Entity("API_FashionShop.Models.GioHang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdKH")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("DATE");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("GioHangs");
                });

            modelBuilder.Entity("API_FashionShop.Models.HDBan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("GhiChu")
                        .HasColumnType("longtext");

                    b.Property<int>("IdDiaChi")
                        .HasColumnType("int");

                    b.Property<int>("IdKH")
                        .HasColumnType("int");

                    b.Property<int>("IdNV")
                        .HasColumnType("int");

                    b.Property<int>("KhuyenMai")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("DATE");

                    b.Property<int>("TinhTrangDH")
                        .HasColumnType("int");

                    b.Property<int>("TongTien")
                        .HasColumnType("int");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("HDBans");
                });

            modelBuilder.Entity("API_FashionShop.Models.HDNhap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdNcc")
                        .HasColumnType("int");

                    b.Property<int>("IdNhanVien")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayNhap")
                        .HasColumnType("Date");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("HDNhaps");
                });

            modelBuilder.Entity("API_FashionShop.Models.KhachHang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<bool>("GioiTinh")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("HoTen")
                        .HasColumnType("longtext");

                    b.Property<string>("MatKhau")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("DATE");

                    b.Property<string>("SoDT")
                        .HasColumnType("longtext");

                    b.Property<string>("TenDN")
                        .HasColumnType("longtext");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("KhachHangs");
                });

            modelBuilder.Entity("API_FashionShop.Models.KhuyenMai", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayAD")
                        .HasColumnType("DATE");

                    b.Property<DateTime>("NgayKT")
                        .HasColumnType("DATE");

                    b.Property<double>("TiLeKM")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("KhuyenMais");
                });

            modelBuilder.Entity("API_FashionShop.Models.LoaiSP", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .HasColumnType("longtext");

                    b.Property<string>("TenLoai")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("LoaiSPs");
                });

            modelBuilder.Entity("API_FashionShop.Models.Ncc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DiaChi")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("SoDT")
                        .HasColumnType("longtext");

                    b.Property<string>("TenNCC")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Nccs");
                });

            modelBuilder.Entity("API_FashionShop.Models.NhanVien", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Avatar")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("HoTen")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<sbyte>("Quyen")
                        .HasColumnType("TINYINT");

                    b.Property<string>("SoDT")
                        .HasColumnType("longtext");

                    b.Property<string>("SoTK")
                        .HasColumnType("longtext");

                    b.Property<string>("TenNH")
                        .HasColumnType("longtext");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("NhanViens");
                });

            modelBuilder.Entity("API_FashionShop.Models.SanPham", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ChatLieu")
                        .HasColumnType("longtext");

                    b.Property<int>("Gia")
                        .HasColumnType("int");

                    b.Property<string>("HinhAnh1")
                        .HasColumnType("longtext");

                    b.Property<string>("HinhAnh2")
                        .HasColumnType("longtext");

                    b.Property<string>("HinhAnh3")
                        .HasColumnType("longtext");

                    b.Property<int>("IdLoaiSP")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .HasColumnType("longtext");

                    b.Property<string>("TenSP")
                        .HasColumnType("longtext");

                    b.Property<string>("ThuongHieu")
                        .HasColumnType("longtext");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("SanPhams");
                });
#pragma warning restore 612, 618
        }
    }
}
