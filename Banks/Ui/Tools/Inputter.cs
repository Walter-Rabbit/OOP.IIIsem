﻿using System;
using System.Collections.Generic;
using System.Linq;
using Banks.Entities;

namespace Banks.Ui.Tools
{
    public class Inputter
    {
        private readonly Asker _asker;

        public Inputter()
        {
            _asker = new Asker();
        }

        public string InputName()
        {
            return _asker.AskString("Enter your name:\n");
        }

        public string InputSurname()
        {
            return _asker.AskString("Enter your surname:\n");
        }

        public Bank InputBankId(IEnumerable<Bank> banks)
        {
            return _asker.AskChoices(
                "Enter bank:",
                banks);
        }

        public Guid InputBillId(IEnumerable<Guid> bills)
        {
            return _asker.AskChoices(
                "Enter id of bill:",
                bills);
        }

        public Guid InputTransactionId(IEnumerable<Guid> transactions)
        {
            return _asker.AskChoices(
                "Enter id of transaction:",
                transactions);
        }

        public Guid InputBillToId(IEnumerable<Guid> bills)
        {
            return _asker.AskChoices(
                "Enter id of bill, which you want to send money:",
                bills);
        }

        public Guid InputBillFromId(IEnumerable<Guid> bills)
        {
            return _asker.AskChoices(
                "Enter id of bill, where you want to debited money from:",
                bills);
        }

        public Guid InputNotificationId(IEnumerable<Guid> notifications)
        {
            return _asker.AskChoices("Enter id of notification", notifications);
        }

        public int InputMoney()
        {
            return _asker.AskInt("Enter how mush money transfer to bill:\n");
        }

        public int InputMonthAmount()
        {
            return _asker.AskInt("Enter amount of month to rewind:\n");
        }
    }
}