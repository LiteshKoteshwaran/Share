﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _12_04_2019.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TaskEntities : DbContext
    {
        public TaskEntities()
            : base("name=TaskEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblAddress> tblAddresses { get; set; }
        public virtual DbSet<tblEmployeeDetail> tblEmployeeDetails { get; set; }
        public virtual DbSet<tblMasCity> tblMasCities { get; set; }
        public virtual DbSet<tblMasDistrict> tblMasDistricts { get; set; }
        public virtual DbSet<tblMasState> tblMasStates { get; set; }
    }
}