using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MarketingWebApi.Models;

namespace MarketingWebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Countries> Countries { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<Moduls> Moduls { get; set; }
        public DbSet<Rols> Rols { get; set; }
        public DbSet<RolsItems> RolsItems { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserAccess> UserAccess { get; set; }
        public DbSet<UserItems> UserItems { get; set; }
        public DbSet<UserModuls> UserModuls { get; set; }
        public DbSet<Offices> Offices { get; set; }
        public DbSet<CompanyBases> CompanyBases { get; set; }
        public DbSet<CategoryPages> CategoryPages { get; set; }
        public DbSet<PageInformations> PageInformations { get; set; }
        public DbSet<PageParagraphs> PageParagraphs { get; set; }
        public DbSet<PagePhrases> PagePhrases { get; set; }
        public DbSet<LawyerCategories> LawyerCategories { get; set; }
        public DbSet<ArticleAuthors> ArticleAuthors { get; set; }
        public DbSet<ArticleCategories> ArticleCategories { get; set; }
        public DbSet<ArticleNewsletters> ArticleNewsletters { get; set; }
        public DbSet<Articles> Articles { get; set; }
        public DbSet<Languages> Languages { get; set; }
        public DbSet<LawyerAcademicInfos> LawyerAcademicInfos { get; set; }
        public DbSet<LawyerClientFeedbacks> LawyerClientFeedbacks { get; set; }
        public DbSet<LawyerLanguages> LawyerLanguages { get; set; }
        public DbSet<LawyerMemberships> LawyerMemberships { get; set; }
        public DbSet<LawyerPracticeAreas> LawyerPracticeAreas { get; set; }
        public DbSet<LawyerRecognitions> LawyerRecognitions { get; set; }
        public DbSet<Lawyers> Lawyers { get; set; }
        public DbSet<Memberships> Memberships { get; set; }
        public DbSet<Months> Months { get; set; }
        public DbSet<Newsletters> Newsletters { get; set; }
        public DbSet<Pages> Pages { get; set; }
        public DbSet<PracticeAreas> PracticeAreas { get; set; }
        public DbSet<Recognitions> Recognitions { get; set; }
        public DbSet<GeneralSocialMedia> GeneralSocialMedia { get; set; }
        public DbSet<Diversities> Diversities { get; set; }
        public DbSet<Sustainabilities> Sustainabilities { get; set; }
        public DbSet<GeneralValues> GeneralValues { get; set; }
        public DbSet<Icons>  Icons { get; set; }
        public DbSet<HomeInformation> HomeInformation { get; set; }
        public DbSet<HomeInformationCounters> HomeInformationCounters { get; set; }
        public DbSet<Organizations> Organizations { get; set; }
        public DbSet<LawyerRecognitionImages> LawyerRecognitionImages { get; set; }
        public DbSet<Awards> Awards { get; set; }
        public DbSet<AwardYears> AwardYears { get; set; }
        public DbSet<Rankings> Rankings { get; set; }
        public DbSet<PageLists> PageLists { get; set; }
        public DbSet<CategoryAwards> CategoryAwards { get; set; }
        public DbSet<ArticleBibliographics> ArticleBibliographics { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
    }
}
