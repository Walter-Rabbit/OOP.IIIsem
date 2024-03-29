﻿using System;
using Banks.Entities;
using Banks.Entities.Bills;
using Banks.Tools;

namespace Banks.Models.Builders
{
    public class DepositBillBuilder : BaseBillBuilder
    {
        public DepositBillBuilder(Bank bank, Client client, decimal money)
            : base(bank, client, money)
        {
            Bank = bank;
            Client = client;
            Money = money;
        }

        internal override void AddBankInfo(
            decimal percent,
            decimal limit,
            decimal commission,
            decimal unreliableLimit,
            DateTime openDate,
            DateTime endDate,
            bool reliable)
        {
            if (percent < 0)
            {
                throw new BanksException($"Percent must be non-negative. Your percent: {percent}");
            }

            if (openDate > endDate)
            {
                throw new BanksException($"End date must be later than open date." +
                                         $"\nOpen date: {openDate}" +
                                         $"\nOpen date: {endDate}");
            }

            Percent = percent;
            Limit = 0;
            Commission = 0;
            OpenDate = openDate;
            EndDate = endDate;
            UnreliableLimit = unreliableLimit;
            Reliable = reliable;
        }

        internal override BaseBill CreateBill()
        {
            return new DepositBill(
                Bank,
                Client,
                Money,
                Percent,
                EndDate,
                UnreliableLimit,
                OpenDate,
                Reliable);
        }
    }
}