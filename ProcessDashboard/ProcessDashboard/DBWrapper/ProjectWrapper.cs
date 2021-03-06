﻿#region
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ProcessDashboard.Model;
using SQLite;
#endregion
namespace ProcessDashboard.DBWrapper
{
    public class ProjectWrapper
    {
        private SQLiteConnection _db;

        public ProjectWrapper(SQLiteConnection db)
        {
            _db = db;
        }

        public bool CreateTable()
        {
            try
            {
                _db.CreateTable<ProjectModel>();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }

        public bool InsertRecord(ProjectModel projectModel)
        {
            try
            {
                _db.Insert(projectModel);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }

        public bool InsertOrUpdateRecord(ProjectModel projectModel)
        {
            try
            {
                _db.InsertOrReplace(projectModel);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }

        public bool InsertMultipleRecords(List<ProjectModel> entries)
        {
            // database calls inside the transaction
            foreach (var pm in entries)
            {
                _db.InsertOrReplace(pm);
            }

            return true;
        }
        public List<ProjectModel> GetAllRecords()
        {
            try
            {
                var table = _db.Table<ProjectModel>().ToList();
                // Can we directly return table ??
                return table;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        public ProjectModel GetRecord(string projectId)
        {
            try
            {
                var item = _db.Get<ProjectModel>(projectId);
                return item;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        public bool UpdateRecord(string projectId, Hashtable ht)
        {
            try
            {
                var item = _db.Get<ProjectModel>(projectId);

                if (ht.ContainsKey("Name"))
                {
                    item.Name = ht["Name"].ToString();
                }
                if (ht.ContainsKey("CreationDate"))
                {
                    item.CreationDate = DateTime.Parse(ht["CreationDate"].ToString());
                }
                if (ht.ContainsKey("IsActive"))
                {
                    item.IsActive = bool.Parse(ht["IsActive"].ToString());
                }
                _db.Update(item);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }

        public bool DeleteRecord(string projectId)
        {
            try
            {
                _db.Delete<ProjectModel>(projectId);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }
    }
}