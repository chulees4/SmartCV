using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartCV.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    photo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    token = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_admins", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "advertisements",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    job_listing_ad = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    job_listing_ad_status = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    job_listing_ad_url = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    company_listing_ad = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    company_listing_ad_status = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    company_listing_ad_url = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_advertisements", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "banners",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    banner_job_listing = table.Column<string>(type: "text", nullable: false),
                    banner_job_detail = table.Column<string>(type: "text", nullable: false),
                    banner_job_categories = table.Column<string>(type: "text", nullable: false),
                    banner_company_listing = table.Column<string>(type: "text", nullable: false),
                    banner_company_detail = table.Column<string>(type: "text", nullable: false),
                    banner_pricing = table.Column<string>(type: "text", nullable: false),
                    banner_blog = table.Column<string>(type: "text", nullable: false),
                    banner_post = table.Column<string>(type: "text", nullable: false),
                    banner_faq = table.Column<string>(type: "text", nullable: false),
                    banner_contact = table.Column<string>(type: "text", nullable: false),
                    banner_terms = table.Column<string>(type: "text", nullable: false),
                    banner_privacy = table.Column<string>(type: "text", nullable: false),
                    banner_signup = table.Column<string>(type: "text", nullable: false),
                    banner_login = table.Column<string>(type: "text", nullable: false),
                    banner_forget_password = table.Column<string>(type: "text", nullable: false),
                    banner_company_panel = table.Column<string>(type: "text", nullable: false),
                    banner_candidate_panel = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_banners", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "company_industries",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_company_industries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "company_locations",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_company_locations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "company_sizes",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_company_sizes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cv_templates",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    template_html = table.Column<string>(type: "text", nullable: false),
                    template_css = table.Column<string>(type: "text", nullable: false),
                    thumbnail_path = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    sort_order = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cv_templates", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "faculties",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    logo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_faculties", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "faqs",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    question = table.Column<string>(type: "text", nullable: false),
                    answer = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_faqs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "job_experiences",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_job_experiences", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "job_genders",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_job_genders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "job_locations",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_job_locations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "job_salary_ranges",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_job_salary_ranges", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "job_types",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_job_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "page_blog_items",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    heading = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    meta_description = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_page_blog_items", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "page_contact_items",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    heading = table.Column<string>(type: "text", nullable: false),
                    map_code = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    meta_description = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_page_contact_items", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "page_faq_items",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    heading = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    meta_description = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_page_faq_items", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "page_home_items",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    heading = table.Column<string>(type: "text", nullable: false),
                    text = table.Column<string>(type: "text", nullable: true),
                    job_title = table.Column<string>(type: "text", nullable: false),
                    job_category = table.Column<string>(type: "text", nullable: false),
                    job_location = table.Column<string>(type: "text", nullable: false),
                    search = table.Column<string>(type: "text", nullable: false),
                    background = table.Column<string>(type: "text", nullable: false),
                    job_category_heading = table.Column<string>(type: "text", nullable: false),
                    job_category_subheading = table.Column<string>(type: "text", nullable: true),
                    job_category_status = table.Column<string>(type: "text", nullable: false),
                    why_choose_heading = table.Column<string>(type: "text", nullable: false),
                    why_choose_subheading = table.Column<string>(type: "text", nullable: true),
                    why_choose_status = table.Column<string>(type: "text", nullable: false),
                    why_choose_background = table.Column<string>(type: "text", nullable: false),
                    featured_job_heading = table.Column<string>(type: "text", nullable: false),
                    featured_job_subheading = table.Column<string>(type: "text", nullable: true),
                    featured_job_status = table.Column<string>(type: "text", nullable: false),
                    testimonial_heading = table.Column<string>(type: "text", nullable: false),
                    testimonial_background = table.Column<string>(type: "text", nullable: false),
                    testimonial_status = table.Column<string>(type: "text", nullable: false),
                    blog_heading = table.Column<string>(type: "text", nullable: false),
                    blog_subheading = table.Column<string>(type: "text", nullable: true),
                    blog_status = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    meta_discription = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_page_home_items", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "page_job_category_items",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    heading = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    meta_description = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_page_job_category_items", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "page_other_items",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    login_page_heading = table.Column<string>(type: "text", nullable: false),
                    login_page_title = table.Column<string>(type: "text", nullable: true),
                    login_page_meta_description = table.Column<string>(type: "text", nullable: true),
                    signup_page_heading = table.Column<string>(type: "text", nullable: false),
                    signup_page_title = table.Column<string>(type: "text", nullable: true),
                    signup_page_meta_description = table.Column<string>(type: "text", nullable: true),
                    forget_password_page_heading = table.Column<string>(type: "text", nullable: false),
                    forget_password_page_title = table.Column<string>(type: "text", nullable: true),
                    forget_password_page_meta_description = table.Column<string>(type: "text", nullable: true),
                    company_listing_page_heading = table.Column<string>(type: "text", nullable: false),
                    company_listing_page_title = table.Column<string>(type: "text", nullable: true),
                    company_listing_page_meta_description = table.Column<string>(type: "text", nullable: true),
                    job_page_heading = table.Column<string>(type: "text", nullable: false),
                    job_page_title = table.Column<string>(type: "text", nullable: true),
                    job_page_meta_description = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_page_other_items", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "page_pricing_items",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    heading = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    meta_description = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_page_pricing_items", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "page_privacy_items",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    heading = table.Column<string>(type: "text", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    meta_description = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_page_privacy_items", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "page_term_items",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    heading = table.Column<string>(type: "text", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    meta_description = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_page_term_items", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "page_tip_items",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    heading = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    meta_description = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_page_tip_items", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "settings",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    total_allowed_job = table.Column<int>(type: "integer", nullable: false),
                    total_allowed_featured_job = table.Column<int>(type: "integer", nullable: false),
                    total_allowed_photo = table.Column<int>(type: "integer", nullable: false),
                    total_allowed_video = table.Column<int>(type: "integer", nullable: false),
                    logo = table.Column<string>(type: "text", nullable: false),
                    favicon = table.Column<string>(type: "text", nullable: false),
                    top_bar_phone = table.Column<string>(type: "text", nullable: true),
                    top_bar_email = table.Column<string>(type: "text", nullable: true),
                    footer_phone = table.Column<string>(type: "text", nullable: true),
                    footer_email = table.Column<string>(type: "text", nullable: true),
                    footer_address = table.Column<string>(type: "text", nullable: true),
                    facebook = table.Column<string>(type: "text", nullable: true),
                    twitter = table.Column<string>(type: "text", nullable: true),
                    linkedin = table.Column<string>(type: "text", nullable: true),
                    pinterest = table.Column<string>(type: "text", nullable: true),
                    instagram = table.Column<string>(type: "text", nullable: true),
                    copyright_text = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_settings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "subscribers",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email = table.Column<string>(type: "text", nullable: false),
                    token = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<byte>(type: "smallint", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_subscribers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "testimonials",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    designation = table.Column<string>(type: "text", nullable: false),
                    photo = table.Column<string>(type: "text", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_testimonials", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "why_choose_items",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    heading = table.Column<string>(type: "text", nullable: false),
                    icon = table.Column<string>(type: "text", nullable: false),
                    text = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_why_choose_items", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "companies",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    company_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    google_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    password = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    token = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    reset_token = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    logo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    phone = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    address = table.Column<string>(type: "text", nullable: true),
                    company_location_id = table.Column<long>(type: "bigint", nullable: true),
                    company_size_id = table.Column<long>(type: "bigint", nullable: true),
                    company_industry_id = table.Column<long>(type: "bigint", nullable: true),
                    website = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    founded_on = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    oh_mon = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    oh_tue = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    oh_wed = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    oh_thu = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    oh_fri = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    oh_sat = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    oh_sun = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    map_code = table.Column<string>(type: "text", nullable: true),
                    facebook = table.Column<string>(type: "text", nullable: true),
                    twitter = table.Column<string>(type: "text", nullable: true),
                    linkedin = table.Column<string>(type: "text", nullable: true),
                    instagram = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<byte>(type: "smallint", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_companies", x => x.id);
                    table.ForeignKey(
                        name: "fk_companies_company_industries_company_industry_id",
                        column: x => x.company_industry_id,
                        principalTable: "company_industries",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_companies_company_locations_company_location_id",
                        column: x => x.company_location_id,
                        principalTable: "company_locations",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_companies_company_sizes_company_size_id",
                        column: x => x.company_size_id,
                        principalTable: "company_sizes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "job_categories",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    icon = table.Column<string>(type: "text", nullable: false),
                    faculty_id = table.Column<long>(type: "bigint", nullable: true),
                    is_featured = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_job_categories", x => x.id);
                    table.ForeignKey(
                        name: "fk_job_categories_faculties_faculty_id",
                        column: x => x.faculty_id,
                        principalTable: "faculties",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "company_photos",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    company_id = table.Column<long>(type: "bigint", nullable: false),
                    photo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_company_photos", x => x.id);
                    table.ForeignKey(
                        name: "fk_company_photos_companies_company_id",
                        column: x => x.company_id,
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "company_videos",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    company_id = table.Column<long>(type: "bigint", nullable: false),
                    video_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_company_videos", x => x.id);
                    table.ForeignKey(
                        name: "fk_company_videos_companies_company_id",
                        column: x => x.company_id,
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "candidates",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    google_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    password = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    student_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    job_category_id = table.Column<long>(type: "bigint", nullable: true),
                    desired_location_id = table.Column<long>(type: "bigint", nullable: true),
                    desired_experience_id = table.Column<long>(type: "bigint", nullable: true),
                    desired_salary_range_id = table.Column<long>(type: "bigint", nullable: true),
                    lecture_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    token = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    reset_token = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    photo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    biography = table.Column<string>(type: "text", nullable: true),
                    phone = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    country = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    address = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    state = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    city = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    zip_code = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    gender = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    date_of_birth = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    website = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    status = table.Column<byte>(type: "smallint", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_candidates", x => x.id);
                    table.ForeignKey(
                        name: "fk_candidates_job_categories_job_category_id",
                        column: x => x.job_category_id,
                        principalTable: "job_categories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_candidates_job_experiences_desired_experience_id",
                        column: x => x.desired_experience_id,
                        principalTable: "job_experiences",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_candidates_job_locations_desired_location_id",
                        column: x => x.desired_location_id,
                        principalTable: "job_locations",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_candidates_job_salary_ranges_desired_salary_range_id",
                        column: x => x.desired_salary_range_id,
                        principalTable: "job_salary_ranges",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "jobs",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    company_id = table.Column<long>(type: "bigint", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    slug = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "text", nullable: false),
                    responsibility = table.Column<string>(type: "text", nullable: true),
                    skill = table.Column<string>(type: "text", nullable: true),
                    education = table.Column<string>(type: "text", nullable: true),
                    benefit = table.Column<string>(type: "text", nullable: true),
                    deadline = table.Column<DateOnly>(type: "date", nullable: false),
                    vacancy = table.Column<int>(type: "integer", nullable: false),
                    job_category_id = table.Column<long>(type: "bigint", nullable: false),
                    job_location_id = table.Column<long>(type: "bigint", nullable: false),
                    job_type_id = table.Column<long>(type: "bigint", nullable: false),
                    job_experience_id = table.Column<long>(type: "bigint", nullable: false),
                    job_gender_id = table.Column<long>(type: "bigint", nullable: false),
                    job_salary_range_id = table.Column<long>(type: "bigint", nullable: true),
                    map_code = table.Column<string>(type: "text", nullable: true),
                    is_featured = table.Column<bool>(type: "boolean", nullable: false),
                    is_urgent = table.Column<bool>(type: "boolean", nullable: false),
                    view_count = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_jobs", x => x.id);
                    table.ForeignKey(
                        name: "fk_jobs_companies_company_id",
                        column: x => x.company_id,
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_jobs_job_categories_job_category_id",
                        column: x => x.job_category_id,
                        principalTable: "job_categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_jobs_job_experiences_job_experience_id",
                        column: x => x.job_experience_id,
                        principalTable: "job_experiences",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_jobs_job_genders_job_gender_id",
                        column: x => x.job_gender_id,
                        principalTable: "job_genders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_jobs_job_locations_job_location_id",
                        column: x => x.job_location_id,
                        principalTable: "job_locations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_jobs_job_salary_ranges_job_salary_range_id",
                        column: x => x.job_salary_range_id,
                        principalTable: "job_salary_ranges",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_jobs_job_types_job_type_id",
                        column: x => x.job_type_id,
                        principalTable: "job_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lectures",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    faculty_id = table.Column<long>(type: "bigint", nullable: true),
                    role_id = table.Column<long>(type: "bigint", nullable: true),
                    job_category_id = table.Column<long>(type: "bigint", nullable: true),
                    lecture_code = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    phone = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    token = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    reset_token = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lectures", x => x.id);
                    table.ForeignKey(
                        name: "fk_lectures_faculties_faculty_id",
                        column: x => x.faculty_id,
                        principalTable: "faculties",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_lectures_job_categories_job_category_id",
                        column: x => x.job_category_id,
                        principalTable: "job_categories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_lectures_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    heading = table.Column<string>(type: "text", nullable: false),
                    slug = table.Column<string>(type: "text", nullable: false),
                    short_description = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    total_view = table.Column<string>(type: "text", nullable: false),
                    photo = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    meta_discription = table.Column<string>(type: "text", nullable: true),
                    job_category_id = table.Column<long>(type: "bigint", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_posts", x => x.id);
                    table.ForeignKey(
                        name: "fk_posts_job_categories_job_category_id",
                        column: x => x.job_category_id,
                        principalTable: "job_categories",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "candidate_awards",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    candidate_id = table.Column<long>(type: "bigint", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    date = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_candidate_awards", x => x.id);
                    table.ForeignKey(
                        name: "fk_candidate_awards_candidates_candidate_id",
                        column: x => x.candidate_id,
                        principalTable: "candidates",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "candidate_cvs",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    candidate_id = table.Column<long>(type: "bigint", nullable: false),
                    cv_template_id = table.Column<long>(type: "bigint", nullable: false),
                    title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    generated_html = table.Column<string>(type: "text", nullable: true),
                    pdf_path = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    custom_color = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    custom_font = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_candidate_cvs", x => x.id);
                    table.ForeignKey(
                        name: "fk_candidate_cvs_candidates_candidate_id",
                        column: x => x.candidate_id,
                        principalTable: "candidates",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_candidate_cvs_cv_templates_cv_template_id",
                        column: x => x.cv_template_id,
                        principalTable: "cv_templates",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "candidate_educations",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    candidate_id = table.Column<long>(type: "bigint", nullable: false),
                    level = table.Column<string>(type: "text", nullable: false),
                    institute = table.Column<string>(type: "text", nullable: false),
                    degree = table.Column<string>(type: "text", nullable: false),
                    passing_year = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_candidate_educations", x => x.id);
                    table.ForeignKey(
                        name: "fk_candidate_educations_candidates_candidate_id",
                        column: x => x.candidate_id,
                        principalTable: "candidates",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "candidate_experiences",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    candidate_id = table.Column<long>(type: "bigint", nullable: false),
                    company = table.Column<string>(type: "text", nullable: false),
                    designation = table.Column<string>(type: "text", nullable: false),
                    start_date = table.Column<string>(type: "text", nullable: false),
                    end_date = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_candidate_experiences", x => x.id);
                    table.ForeignKey(
                        name: "fk_candidate_experiences_candidates_candidate_id",
                        column: x => x.candidate_id,
                        principalTable: "candidates",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "candidate_resumes",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    candidate_id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    file = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_candidate_resumes", x => x.id);
                    table.ForeignKey(
                        name: "fk_candidate_resumes_candidates_candidate_id",
                        column: x => x.candidate_id,
                        principalTable: "candidates",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "candidate_skills",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    candidate_id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    percentage = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_candidate_skills", x => x.id);
                    table.ForeignKey(
                        name: "fk_candidate_skills_candidates_candidate_id",
                        column: x => x.candidate_id,
                        principalTable: "candidates",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "job_alerts",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    candidate_id = table.Column<long>(type: "bigint", nullable: false),
                    alert_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    job_category_id = table.Column<long>(type: "bigint", nullable: true),
                    job_location_id = table.Column<long>(type: "bigint", nullable: true),
                    job_type_id = table.Column<long>(type: "bigint", nullable: true),
                    job_salary_range_id = table.Column<long>(type: "bigint", nullable: true),
                    keywords = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    last_sent_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_job_alerts", x => x.id);
                    table.ForeignKey(
                        name: "fk_job_alerts_candidates_candidate_id",
                        column: x => x.candidate_id,
                        principalTable: "candidates",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_job_alerts_job_categories_job_category_id",
                        column: x => x.job_category_id,
                        principalTable: "job_categories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_job_alerts_job_locations_job_location_id",
                        column: x => x.job_location_id,
                        principalTable: "job_locations",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_job_alerts_job_salary_ranges_job_salary_range_id",
                        column: x => x.job_salary_range_id,
                        principalTable: "job_salary_ranges",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_job_alerts_job_types_job_type_id",
                        column: x => x.job_type_id,
                        principalTable: "job_types",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "candidate_applications",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    candidate_id = table.Column<long>(type: "bigint", nullable: false),
                    job_id = table.Column<long>(type: "bigint", nullable: false),
                    cover_letter = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_candidate_applications", x => x.id);
                    table.ForeignKey(
                        name: "fk_candidate_applications_candidates_candidate_id",
                        column: x => x.candidate_id,
                        principalTable: "candidates",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_candidate_applications_jobs_job_id",
                        column: x => x.job_id,
                        principalTable: "jobs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "candidate_bookmarks",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    candidate_id = table.Column<long>(type: "bigint", nullable: false),
                    job_id = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_candidate_bookmarks", x => x.id);
                    table.ForeignKey(
                        name: "fk_candidate_bookmarks_candidates_candidate_id",
                        column: x => x.candidate_id,
                        principalTable: "candidates",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_candidate_bookmarks_jobs_job_id",
                        column: x => x.job_id,
                        principalTable: "jobs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "admins",
                columns: new[] { "id", "created_at", "email", "name", "password", "photo", "token", "updated_at" },
                values: new object[] { 1L, new DateTime(2026, 3, 31, 6, 18, 46, 582, DateTimeKind.Utc).AddTicks(9274), "admin@smartcv.com", "Super Admin", "$2a$11$91tVFkV2wtgQGhcqub4CFOg8vQM8o5z7vsxicUV7mMQLwcCFpEitC", "default.png", "", new DateTime(2026, 3, 31, 6, 18, 46, 582, DateTimeKind.Utc).AddTicks(9277) });

            migrationBuilder.InsertData(
                table: "advertisements",
                columns: new[] { "id", "company_listing_ad", "company_listing_ad_status", "company_listing_ad_url", "created_at", "job_listing_ad", "job_listing_ad_status", "job_listing_ad_url", "updated_at" },
                values: new object[] { 1L, "", "0", "", new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(4425), "", "0", "", new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(4426) });

            migrationBuilder.InsertData(
                table: "banners",
                columns: new[] { "id", "banner_blog", "banner_candidate_panel", "banner_company_detail", "banner_company_listing", "banner_company_panel", "banner_contact", "banner_faq", "banner_forget_password", "banner_job_categories", "banner_job_detail", "banner_job_listing", "banner_login", "banner_post", "banner_pricing", "banner_privacy", "banner_signup", "banner_terms", "created_at", "updated_at" },
                values: new object[] { 1L, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(3986), new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(3986) });

            migrationBuilder.InsertData(
                table: "cv_templates",
                columns: new[] { "id", "created_at", "is_active", "name", "sort_order", "template_css", "template_html", "thumbnail_path", "updated_at" },
                values: new object[,]
                {
                    { 1L, new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(5926), true, "Mẫu Chuyên Nghiệp", 1, "", "<!-- TODO: Template 1 HTML -->", null, new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(5926) },
                    { 2L, new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(6569), true, "Mẫu Sáng Tạo", 2, "", "<!-- TODO: Template 2 HTML -->", null, new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(6569) },
                    { 3L, new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(6571), true, "Mẫu Đơn Giản", 3, "", "<!-- TODO: Template 3 HTML -->", null, new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(6572) }
                });

            migrationBuilder.InsertData(
                table: "job_experiences",
                columns: new[] { "id", "created_at", "name", "updated_at" },
                values: new object[,]
                {
                    { 1L, new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(7718), "Không yêu cầu kinh nghiệm", new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(7718) },
                    { 2L, new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(8092), "Dưới 1 năm", new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(8093) },
                    { 3L, new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(8095), "1 - 2 năm", new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(8095) },
                    { 4L, new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(8096), "2 - 5 năm", new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(8096) },
                    { 5L, new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(8097), "Trên 5 năm", new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(8097) }
                });

            migrationBuilder.InsertData(
                table: "job_genders",
                columns: new[] { "id", "created_at", "name", "updated_at" },
                values: new object[,]
                {
                    { 1L, new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(8539), "Không yêu cầu", new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(8539) },
                    { 2L, new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(8778), "Nam", new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(8778) },
                    { 3L, new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(8780), "Nữ", new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(8780) }
                });

            migrationBuilder.InsertData(
                table: "job_salary_ranges",
                columns: new[] { "id", "created_at", "name", "updated_at" },
                values: new object[,]
                {
                    { 1L, new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(9120), "Thỏa thuận", new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(9120) },
                    { 2L, new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(9357), "Dưới 5 triệu", new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(9358) },
                    { 3L, new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(9359), "5 - 10 triệu", new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(9359) },
                    { 4L, new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(9360), "10 - 20 triệu", new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(9361) },
                    { 5L, new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(9395), "20 - 30 triệu", new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(9395) },
                    { 6L, new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(9396), "Trên 30 triệu", new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(9396) }
                });

            migrationBuilder.InsertData(
                table: "job_types",
                columns: new[] { "id", "created_at", "name", "updated_at" },
                values: new object[,]
                {
                    { 1L, new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(7086), "Toàn thời gian", new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(7086) },
                    { 2L, new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(7353), "Bán thời gian", new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(7353) },
                    { 3L, new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(7354), "Thực tập", new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(7355) },
                    { 4L, new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(7356), "Freelance", new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(7356) },
                    { 5L, new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(7356), "Remote", new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(7357) }
                });

            migrationBuilder.InsertData(
                table: "page_blog_items",
                columns: new[] { "id", "created_at", "heading", "meta_description", "title", "updated_at" },
                values: new object[] { 1L, new DateTime(2026, 3, 31, 6, 18, 46, 583, DateTimeKind.Utc).AddTicks(8390), "Blog & Tin tức", null, null, new DateTime(2026, 3, 31, 6, 18, 46, 583, DateTimeKind.Utc).AddTicks(8390) });

            migrationBuilder.InsertData(
                table: "page_contact_items",
                columns: new[] { "id", "created_at", "heading", "map_code", "meta_description", "title", "updated_at" },
                values: new object[] { 1L, new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(973), "Liên hệ", "", null, null, new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(974) });

            migrationBuilder.InsertData(
                table: "page_faq_items",
                columns: new[] { "id", "created_at", "heading", "meta_description", "title", "updated_at" },
                values: new object[] { 1L, new DateTime(2026, 3, 31, 6, 18, 46, 583, DateTimeKind.Utc).AddTicks(8899), "Câu hỏi thường gặp", null, null, new DateTime(2026, 3, 31, 6, 18, 46, 583, DateTimeKind.Utc).AddTicks(8900) });

            migrationBuilder.InsertData(
                table: "page_home_items",
                columns: new[] { "id", "background", "blog_heading", "blog_status", "blog_subheading", "created_at", "featured_job_heading", "featured_job_status", "featured_job_subheading", "heading", "job_category", "job_category_heading", "job_category_status", "job_category_subheading", "job_location", "job_title", "meta_discription", "search", "testimonial_background", "testimonial_heading", "testimonial_status", "text", "title", "updated_at", "why_choose_background", "why_choose_heading", "why_choose_status", "why_choose_subheading" },
                values: new object[] { 1L, "", "", "1", null, new DateTime(2026, 3, 31, 6, 18, 46, 583, DateTimeKind.Utc).AddTicks(7343), "", "1", null, "Tìm Việc Làm Phù Hợp", "Job Category", "", "1", null, "Job Location", "Job Title", "SmartCV - Kết nối sinh viên với nhà tuyển dụng", "Search", "", "", "1", "Kết nối ứng viên & nhà tuyển dụng thông minh", "SmartCV - Nền tảng việc làm thông minh", new DateTime(2026, 3, 31, 6, 18, 46, 583, DateTimeKind.Utc).AddTicks(7343), "", "", "1", null });

            migrationBuilder.InsertData(
                table: "page_job_category_items",
                columns: new[] { "id", "created_at", "heading", "meta_description", "title", "updated_at" },
                values: new object[] { 1L, new DateTime(2026, 3, 31, 6, 18, 46, 583, DateTimeKind.Utc).AddTicks(9921), "Danh mục việc làm", null, null, new DateTime(2026, 3, 31, 6, 18, 46, 583, DateTimeKind.Utc).AddTicks(9921) });

            migrationBuilder.InsertData(
                table: "page_other_items",
                columns: new[] { "id", "company_listing_page_heading", "company_listing_page_meta_description", "company_listing_page_title", "created_at", "forget_password_page_heading", "forget_password_page_meta_description", "forget_password_page_title", "job_page_heading", "job_page_meta_description", "job_page_title", "login_page_heading", "login_page_meta_description", "login_page_title", "signup_page_heading", "signup_page_meta_description", "signup_page_title", "updated_at" },
                values: new object[] { 1L, "Danh sách công ty", null, null, new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(2881), "Quên mật khẩu", null, null, "Danh sách việc làm", null, null, "Đăng nhập", null, null, "Đăng ký", null, null, new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(2881) });

            migrationBuilder.InsertData(
                table: "page_pricing_items",
                columns: new[] { "id", "created_at", "heading", "meta_description", "title", "updated_at" },
                values: new object[] { 1L, new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(466), "Bảng giá", null, null, new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(467) });

            migrationBuilder.InsertData(
                table: "page_privacy_items",
                columns: new[] { "id", "content", "created_at", "heading", "meta_description", "title", "updated_at" },
                values: new object[] { 1L, "", new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(2205), "Chính sách bảo mật", null, null, new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(2205) });

            migrationBuilder.InsertData(
                table: "page_term_items",
                columns: new[] { "id", "content", "created_at", "heading", "meta_description", "title", "updated_at" },
                values: new object[] { 1L, "", new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(1593), "Điều khoản sử dụng", null, null, new DateTime(2026, 3, 31, 6, 18, 46, 584, DateTimeKind.Utc).AddTicks(1593) });

            migrationBuilder.InsertData(
                table: "page_tip_items",
                columns: new[] { "id", "created_at", "heading", "meta_description", "title", "updated_at" },
                values: new object[] { 1L, new DateTime(2026, 3, 31, 6, 18, 46, 583, DateTimeKind.Utc).AddTicks(9428), "Mẹo tìm việc", null, null, new DateTime(2026, 3, 31, 6, 18, 46, 583, DateTimeKind.Utc).AddTicks(9428) });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "created_at", "name", "updated_at" },
                values: new object[,]
                {
                    { 1L, new DateTime(2026, 3, 31, 6, 18, 46, 583, DateTimeKind.Utc).AddTicks(6394), "Trưởng khoa", new DateTime(2026, 3, 31, 6, 18, 46, 583, DateTimeKind.Utc).AddTicks(6394) },
                    { 2L, new DateTime(2026, 3, 31, 6, 18, 46, 583, DateTimeKind.Utc).AddTicks(6738), "Phó trưởng khoa", new DateTime(2026, 3, 31, 6, 18, 46, 583, DateTimeKind.Utc).AddTicks(6739) },
                    { 3L, new DateTime(2026, 3, 31, 6, 18, 46, 583, DateTimeKind.Utc).AddTicks(6740), "Trưởng bộ môn", new DateTime(2026, 3, 31, 6, 18, 46, 583, DateTimeKind.Utc).AddTicks(6740) },
                    { 4L, new DateTime(2026, 3, 31, 6, 18, 46, 583, DateTimeKind.Utc).AddTicks(6741), "Giảng viên", new DateTime(2026, 3, 31, 6, 18, 46, 583, DateTimeKind.Utc).AddTicks(6741) }
                });

            migrationBuilder.InsertData(
                table: "settings",
                columns: new[] { "id", "copyright_text", "created_at", "facebook", "favicon", "footer_address", "footer_email", "footer_phone", "instagram", "linkedin", "logo", "pinterest", "top_bar_email", "top_bar_phone", "total_allowed_featured_job", "total_allowed_job", "total_allowed_photo", "total_allowed_video", "twitter", "updated_at" },
                values: new object[] { 1L, "© 2026 SmartCV", new DateTime(2026, 3, 31, 6, 18, 46, 583, DateTimeKind.Utc).AddTicks(4635), null, "favicon.png", null, null, null, null, null, "logo.png", null, null, null, 2, 5, 5, 3, null, new DateTime(2026, 3, 31, 6, 18, 46, 583, DateTimeKind.Utc).AddTicks(4636) });

            migrationBuilder.CreateIndex(
                name: "IX_admins_email",
                table: "admins",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_candidate_applications_candidate_id",
                table: "candidate_applications",
                column: "candidate_id");

            migrationBuilder.CreateIndex(
                name: "ix_candidate_applications_job_id",
                table: "candidate_applications",
                column: "job_id");

            migrationBuilder.CreateIndex(
                name: "ix_candidate_awards_candidate_id",
                table: "candidate_awards",
                column: "candidate_id");

            migrationBuilder.CreateIndex(
                name: "ix_candidate_bookmarks_candidate_id",
                table: "candidate_bookmarks",
                column: "candidate_id");

            migrationBuilder.CreateIndex(
                name: "ix_candidate_bookmarks_job_id",
                table: "candidate_bookmarks",
                column: "job_id");

            migrationBuilder.CreateIndex(
                name: "ix_candidate_cvs_candidate_id",
                table: "candidate_cvs",
                column: "candidate_id");

            migrationBuilder.CreateIndex(
                name: "ix_candidate_cvs_cv_template_id",
                table: "candidate_cvs",
                column: "cv_template_id");

            migrationBuilder.CreateIndex(
                name: "ix_candidate_educations_candidate_id",
                table: "candidate_educations",
                column: "candidate_id");

            migrationBuilder.CreateIndex(
                name: "ix_candidate_experiences_candidate_id",
                table: "candidate_experiences",
                column: "candidate_id");

            migrationBuilder.CreateIndex(
                name: "ix_candidate_resumes_candidate_id",
                table: "candidate_resumes",
                column: "candidate_id");

            migrationBuilder.CreateIndex(
                name: "ix_candidate_skills_candidate_id",
                table: "candidate_skills",
                column: "candidate_id");

            migrationBuilder.CreateIndex(
                name: "ix_candidates_desired_experience_id",
                table: "candidates",
                column: "desired_experience_id");

            migrationBuilder.CreateIndex(
                name: "ix_candidates_desired_location_id",
                table: "candidates",
                column: "desired_location_id");

            migrationBuilder.CreateIndex(
                name: "ix_candidates_desired_salary_range_id",
                table: "candidates",
                column: "desired_salary_range_id");

            migrationBuilder.CreateIndex(
                name: "IX_candidates_email",
                table: "candidates",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_candidates_google_id",
                table: "candidates",
                column: "google_id",
                unique: true,
                filter: "google_id IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_candidates_job_category_id",
                table: "candidates",
                column: "job_category_id");

            migrationBuilder.CreateIndex(
                name: "ix_companies_company_industry_id",
                table: "companies",
                column: "company_industry_id");

            migrationBuilder.CreateIndex(
                name: "ix_companies_company_location_id",
                table: "companies",
                column: "company_location_id");

            migrationBuilder.CreateIndex(
                name: "ix_companies_company_size_id",
                table: "companies",
                column: "company_size_id");

            migrationBuilder.CreateIndex(
                name: "IX_companies_email",
                table: "companies",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_companies_google_id",
                table: "companies",
                column: "google_id",
                unique: true,
                filter: "google_id IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_company_photos_company_id",
                table: "company_photos",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_company_videos_company_id",
                table: "company_videos",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_job_alerts_candidate_id",
                table: "job_alerts",
                column: "candidate_id");

            migrationBuilder.CreateIndex(
                name: "ix_job_alerts_job_category_id",
                table: "job_alerts",
                column: "job_category_id");

            migrationBuilder.CreateIndex(
                name: "ix_job_alerts_job_location_id",
                table: "job_alerts",
                column: "job_location_id");

            migrationBuilder.CreateIndex(
                name: "ix_job_alerts_job_salary_range_id",
                table: "job_alerts",
                column: "job_salary_range_id");

            migrationBuilder.CreateIndex(
                name: "ix_job_alerts_job_type_id",
                table: "job_alerts",
                column: "job_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_job_categories_faculty_id",
                table: "job_categories",
                column: "faculty_id");

            migrationBuilder.CreateIndex(
                name: "ix_jobs_company_id",
                table: "jobs",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_jobs_job_category_id",
                table: "jobs",
                column: "job_category_id");

            migrationBuilder.CreateIndex(
                name: "ix_jobs_job_experience_id",
                table: "jobs",
                column: "job_experience_id");

            migrationBuilder.CreateIndex(
                name: "ix_jobs_job_gender_id",
                table: "jobs",
                column: "job_gender_id");

            migrationBuilder.CreateIndex(
                name: "ix_jobs_job_location_id",
                table: "jobs",
                column: "job_location_id");

            migrationBuilder.CreateIndex(
                name: "ix_jobs_job_salary_range_id",
                table: "jobs",
                column: "job_salary_range_id");

            migrationBuilder.CreateIndex(
                name: "ix_jobs_job_type_id",
                table: "jobs",
                column: "job_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_lectures_email",
                table: "lectures",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_lectures_faculty_id",
                table: "lectures",
                column: "faculty_id");

            migrationBuilder.CreateIndex(
                name: "ix_lectures_job_category_id",
                table: "lectures",
                column: "job_category_id");

            migrationBuilder.CreateIndex(
                name: "ix_lectures_role_id",
                table: "lectures",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_posts_job_category_id",
                table: "posts",
                column: "job_category_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "advertisements");

            migrationBuilder.DropTable(
                name: "banners");

            migrationBuilder.DropTable(
                name: "candidate_applications");

            migrationBuilder.DropTable(
                name: "candidate_awards");

            migrationBuilder.DropTable(
                name: "candidate_bookmarks");

            migrationBuilder.DropTable(
                name: "candidate_cvs");

            migrationBuilder.DropTable(
                name: "candidate_educations");

            migrationBuilder.DropTable(
                name: "candidate_experiences");

            migrationBuilder.DropTable(
                name: "candidate_resumes");

            migrationBuilder.DropTable(
                name: "candidate_skills");

            migrationBuilder.DropTable(
                name: "company_photos");

            migrationBuilder.DropTable(
                name: "company_videos");

            migrationBuilder.DropTable(
                name: "faqs");

            migrationBuilder.DropTable(
                name: "job_alerts");

            migrationBuilder.DropTable(
                name: "lectures");

            migrationBuilder.DropTable(
                name: "page_blog_items");

            migrationBuilder.DropTable(
                name: "page_contact_items");

            migrationBuilder.DropTable(
                name: "page_faq_items");

            migrationBuilder.DropTable(
                name: "page_home_items");

            migrationBuilder.DropTable(
                name: "page_job_category_items");

            migrationBuilder.DropTable(
                name: "page_other_items");

            migrationBuilder.DropTable(
                name: "page_pricing_items");

            migrationBuilder.DropTable(
                name: "page_privacy_items");

            migrationBuilder.DropTable(
                name: "page_term_items");

            migrationBuilder.DropTable(
                name: "page_tip_items");

            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "settings");

            migrationBuilder.DropTable(
                name: "subscribers");

            migrationBuilder.DropTable(
                name: "testimonials");

            migrationBuilder.DropTable(
                name: "why_choose_items");

            migrationBuilder.DropTable(
                name: "jobs");

            migrationBuilder.DropTable(
                name: "cv_templates");

            migrationBuilder.DropTable(
                name: "candidates");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "companies");

            migrationBuilder.DropTable(
                name: "job_genders");

            migrationBuilder.DropTable(
                name: "job_types");

            migrationBuilder.DropTable(
                name: "job_categories");

            migrationBuilder.DropTable(
                name: "job_experiences");

            migrationBuilder.DropTable(
                name: "job_locations");

            migrationBuilder.DropTable(
                name: "job_salary_ranges");

            migrationBuilder.DropTable(
                name: "company_industries");

            migrationBuilder.DropTable(
                name: "company_locations");

            migrationBuilder.DropTable(
                name: "company_sizes");

            migrationBuilder.DropTable(
                name: "faculties");
        }
    }
}
