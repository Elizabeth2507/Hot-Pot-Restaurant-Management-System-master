﻿

//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Hot_Pot_Restaurant_Management_System.Models.Entities
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class ReportEntities : DbContext
{
    public ReportEntities()
        : base("name=ReportEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public DbSet<MonthlyReport> MonthlyReport { get; set; }

    public DbSet<MReportDetails> MReportDetails { get; set; }

    public DbSet<StartOfTerm> StartOfTerm { get; set; }

    public DbSet<VCreditOrder> VCreditOrder { get; set; }

    public DbSet<VMaterialsRequisition> VMaterialsRequisition { get; set; }

    public DbSet<VMaterialsReturnOrder> VMaterialsReturnOrder { get; set; }

    public DbSet<VPurchaseOrder> VPurchaseOrder { get; set; }

    public DbSet<VStockingList> VStockingList { get; set; }

}

}
