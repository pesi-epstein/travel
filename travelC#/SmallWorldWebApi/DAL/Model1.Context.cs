﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class YMprojectEntities1 : DbContext
    {
        public YMprojectEntities1()
            : base("name=YMprojectEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<ageRange> ageRanges { get; set; }
        public virtual DbSet<Host> Hosts { get; set; }
        public virtual DbSet<HoursRange> HoursRanges { get; set; }
        public virtual DbSet<ServiceTypeList> ServiceTypeLists { get; set; }
        public virtual DbSet<ServiceTypesToSuggestion> ServiceTypesToSuggestions { get; set; }
        public virtual DbSet<Suggestion> Suggestions { get; set; }
        public virtual DbSet<Traveler> Travelers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<bookedDate> bookedDates { get; set; }
        public virtual DbSet<SuggestionTraveler> SuggestionTravelers { get; set; }
    }
}
