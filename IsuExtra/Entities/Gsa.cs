﻿using System;
using System.Collections.Generic;
using IsuExtra.Details;

namespace IsuExtra.Entities
{
    public class Gsa
    {
        private static int _idCounter;
        private readonly List<GsaGroup> _groups;

        public Gsa(GsaDetails gsaDetails)
        {
            GsaDetails = gsaDetails ?? throw new ArgumentException("Null argument");
            Id = _idCounter++;
            _groups = new List<GsaGroup>();
        }

        public GsaDetails GsaDetails { get; }
        public int Id { get; }
        public Department Department { get; internal set; }
        public IReadOnlyList<GsaGroup> GsaGroups => _groups;

        internal void AddGsaGroup(GsaGroup gsaGroup)
        {
            if (gsaGroup is null)
            {
                throw new ArgumentException("Null argument");
            }

            gsaGroup.Gsa = this;
            _groups.Add(gsaGroup);
        }
    }
}