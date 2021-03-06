﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandiBugTrackerDataManager.Internal.DataAccess;
using HandiBugTrackerDataManager.Models;

namespace HandiBugTrackerDataManager.DataAccess
{
    public class BugStatusSubStateData : IBugStatusSubStateData
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public BugStatusSubStateData() { }
        public BugStatusSubStateData(ISqlDataAccess pSQLDataAccess)
        {
            this._sqlDataAccess = pSQLDataAccess;
        }

        public async Task<IEnumerable<BugStatusSubStateModel>> GetBugStatusSubStates()
        {
            var result = await _sqlDataAccess.LoadDataAsync<BugStatusSubStateModel, dynamic>(DataAccessConstant.SP_BugStatusSubState_GetAll, new { }, DataAccessConstant.HandiBugTrackerConn);
            return result;
        }
    }
}
