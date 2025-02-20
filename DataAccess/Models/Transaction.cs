﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int UserId { get; set; }

    public int UserMembershipId { get; set; }

    public decimal Amount { get; set; }

    public string PaymentMethod { get; set; }

    public string TransactionCode { get; set; }

    public string Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual User User { get; set; }

    public virtual UserMembership UserMembership { get; set; }
}