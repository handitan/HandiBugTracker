using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandiBugTrackerDataManager.Internal.DataAccess
{
    abstract class DataAccessConstant
    {
        public const string HandiBugTrackerConn = "HandiBugTrackerData";
        public const string SP_ProductHardware_GetAll = "dbo.spProductHardware_GetAll";
        public const string SP_ProductOS_GetAll = "dbo.spProductOS_GetAll";
        public const string SP_Product_GetAll = "dbo.spProduct_GetAll";
        public const string SP_ProductVersion_GetByProduct = "dbo.spProductVersion_GetByProduct";
        public const string SP_BugType_GetAll = "dbo.spBugType_GetAll";
        public const string SP_BugStatusSubState_GetAll = "dbo.spBugStatusSubState_GetAll";
        public const string SP_BugStatus_GetAll = "dbo.spBugStatus_GetAll";
        public const string SP_BugSeverity_GetAll = "dbo.spBugSeverity_GetAll";
        public const string SP_BugPriority_GetAll = "dbo.spBugPriority_GetAll";
        public const string SP_BugComment_GetByBug = "dbo.spBugComment_GetByBug";
        public const string SP_User_GetAll = "dbo.spUser_GetAll";
        public const string SP_Component_GetByProduct = "dbo.spComponent_GetByProduct";
        public const string SP_ComponentBug_GetFilterBy =  "dbo.spComponentBug_GetFilterBy";
    }
}
