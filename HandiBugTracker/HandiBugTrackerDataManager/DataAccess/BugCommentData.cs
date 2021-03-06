﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandiBugTrackerDataManager.Internal.DataAccess;
using HandiBugTrackerDataManager.Models;

namespace HandiBugTrackerDataManager.DataAccess
{
    public class BugCommentData : IBugCommentData
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public BugCommentData() { }
        public BugCommentData(ISqlDataAccess pSQLDataAccess)
        {
            this._sqlDataAccess = pSQLDataAccess;
        }

        public async Task<IEnumerable<BugCommentModel>> GetBugCommentByBugId(int pBugId)
        {
            var result = await _sqlDataAccess.LoadDataAsync<BugCommentModel, dynamic>(DataAccessConstant.SP_BugComment_GetByBug, new { BugId = pBugId }, DataAccessConstant.HandiBugTrackerConn);
            return result;
        }

        public async Task CreateBugCommentBy(int pBugId,string pDescription, string pReporterId)
        {
            var itemToCreate = new
            {
                BugId = pBugId,
                Description = pDescription,
                ReporterId = pReporterId
            };

            await _sqlDataAccess.SaveDataAsync<dynamic>(DataAccessConstant.SP_BugComment_Create,itemToCreate, DataAccessConstant.HandiBugTrackerConn);
        }

        public async Task EditBugCommentBy(int pBugId, string pDescription, string pReporterId)
        {
            var itemToEdit = new
            {
                BugId = pBugId,
                Description = pDescription,
                ReporterId = pReporterId
            };

            await _sqlDataAccess.SaveDataAsync<dynamic>(DataAccessConstant.SP_BugComment_Edit, itemToEdit, DataAccessConstant.HandiBugTrackerConn);
        }

        public async Task DeleteBugCommentBy(int pBugId)
        {
            var itemToDelete = new
            {
                BugId = pBugId
            };

            await _sqlDataAccess.SaveDataAsync<dynamic>(DataAccessConstant.SP_BugComment_Delete, itemToDelete, DataAccessConstant.HandiBugTrackerConn);
        }
    }
}
