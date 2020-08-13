﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandiBugTrackerDataManager.Internal.DataAccess;
using HandiBugTrackerDataManager.Models;

namespace HandiBugTrackerDataManager.DataAccess
{
    public class BugCommentData
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public BugCommentData(){}
        public BugCommentData(ISqlDataAccess pSQLDataAccess)
        {
            this._sqlDataAccess = pSQLDataAccess;
        }

        public async Task<IEnumerable<BugCommentModel>> GetBugCommentByBugId(int pBugId)
        {
            var result = await _sqlDataAccess.LoadDataAsync<BugCommentModel, dynamic>(DataAccessConstant.SP_BugComment_GetByBug, new { BugId = pBugId }, DataAccessConstant.HandiBugTrackerConn);
            return result;
        }
    }
}
