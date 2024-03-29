﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Banks.Models;
using Banks.Models.Builders;
using Banks.Tools;

namespace Banks.Entities
{
    public class Bank
    {
        private readonly List<Client> _clients;
        private List<DepositMoneyGap> _depositMoneyGaps;

        public Bank(BankBuilder bankBuilder)
        {
            if (bankBuilder is null)
            {
                throw new BanksException("Bank's info is null");
            }

            Name = bankBuilder.Name;
            DebitPercent = bankBuilder.DebitPercent;
            _depositMoneyGaps = bankBuilder.DepositMoneyGaps;
            CreditCommission = bankBuilder.CreditCommission;
            Limit = bankBuilder.Limit;
            _clients = new List<Client>();
            Id = Guid.NewGuid();
            BillDurationYears = bankBuilder.BillDurationYears;
            UnreliableLimit = bankBuilder.UnreliableLimit;
        }

        public Bank()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public decimal DebitPercent { get; private set; }

        public decimal CreditCommission { get; private set; }
        public decimal Limit { get; private set; }
        public int BillDurationYears { get; private set; }
        public decimal UnreliableLimit { get; private set; }

        [NotMapped]
        public IReadOnlyList<DepositMoneyGap> DepositMoneyGaps => _depositMoneyGaps;

        [NotMapped]
        public IReadOnlyList<Client> Clients => _clients;

        public decimal GetDepositPercent(decimal money)
        {
            DepositMoneyGap depositMoneyGap = DepositMoneyGaps.First(moneyGap => moneyGap.InMoneyGap(money));

            if (depositMoneyGap is null)
            {
                throw new BanksException("There is no suitable money gap for your money");
            }

            return depositMoneyGap.Percent;
        }

        public override string ToString()
        {
            return Name;
        }

        internal void ChangeInfo(BankBuilder bankBuilder)
        {
            if (bankBuilder is null)
            {
                throw new BanksException("Bank's info is null");
            }

            Name = bankBuilder.Name;
            DebitPercent = bankBuilder.DebitPercent;

            _depositMoneyGaps.Clear();
            _depositMoneyGaps.AddRange(bankBuilder.DepositMoneyGaps);

            _depositMoneyGaps = bankBuilder.DepositMoneyGaps;
            CreditCommission = bankBuilder.CreditCommission;
            Limit = bankBuilder.Limit;
            BillDurationYears = bankBuilder.BillDurationYears;
        }

        internal void AddClient(Client client)
        {
            if (client is null)
            {
                throw new BanksException("Client is null");
            }

            if (!Clients.Contains(client))
                _clients.Add(client);
        }
    }
}