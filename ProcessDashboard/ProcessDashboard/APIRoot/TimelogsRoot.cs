﻿using System;
using System.Collections.Generic;
using System.Text;
using ProcessDashboard.DTO;

/*
 * Classes for Parsing JSON to OO Model Objects.
 * Variable names are case-sensitive. Donot change or else parsing will fail
 * 
 */
namespace ProcessDashboard.APIRoot
{
    public class TimeLogsRoot
    {
        public List<TimeLogEntry> TimeLogEntries { get; set; }
        public string Stat { get; set; }
        public Err Err { get; set; }
        public override string ToString()
        {
            if (Stat.Equals("ok"))
                return "TimeLog Entries :" + TimeLogEntries.Count;
            else
                return "Err : " + Err;
        }
    }
}
