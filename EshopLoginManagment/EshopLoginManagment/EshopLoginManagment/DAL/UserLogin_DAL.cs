using DataAccessLayer.Model;
using EshopLoginManagment.BusinessModels;
using EshopLoginManagment.DAL.IDAL;
using EshopLoginManagment.GenericRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Prototypes;
using SharedMethodsLib;
using SharedMethodsLib.Results.GeneralTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EshopLoginManagment.DAL
{
    public class UserLogin_DAL : IUserLogin_DAL
    {
        private GenericRepo<LoginTbl> _GenericRepoLogins;
        private AshkandeliryContext db;
        public UserLogin_DAL(AshkandeliryContext DbContext)
        {
            _GenericRepoLogins = new GenericRepo<LoginTbl>(DbContext);
            db = new AshkandeliryContext();
        }
        public BoolResult CheckUsername_Password(int Userid, string Password)
        {
            try
            {
                bool Result = false;
                Result = _GenericRepoLogins.GetByID(Userid).Password != Password ? false : true;
                return new BoolResult { Obj = Result, ResultCode = 0, ResultMessage = "عملیات با موفقیت انجام شد" };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DynamicResult<JwtSecurityToken> GetJWTtoken(string Username)
        {
            TokenManager tokenManager = new TokenManager();
            JwtSecurityToken ResultList = tokenManager.GenerateToken(Username);
            return new DynamicResult<JwtSecurityToken> { Code = 0, Message = "عملیات با موفقیت انجام شد", ObjList = (JwtSecurityToken)ResultList };
        }

        public DynamicResult<UserDataOutput> GetUserByUsername_DAL(string Username)
        {
            List<LoginTbl> _userData = new List<LoginTbl>();
            UserDataOutput _UserDataOutput = new UserDataOutput();
            List<UserData> _userDataList = new List<UserData>();
            _userData = _GenericRepoLogins.GetMany(x => x.Username == Username).ToList();
            if (_userData.Count > 0)
            {
                _userDataList = db.UserData.FromSqlRaw($"Exec GetUserBysername {Username}").ToList();
                _UserDataOutput = Mappers.SharedMapper.convert<UserDataOutput, UserData>(_userDataList.FirstOrDefault());
            }
            else
                throw new Exception("کاربری با نام کاربری وارد شده یافت نشد");
            return new DynamicResult<UserDataOutput> { Code = 0, Message = "عملیات با موفقیت انجام شد", ObjList = _UserDataOutput };
        }

        public DynamicResult<UserDataOutput> LoginUser_DAL(int UserID)
        {
            try
            {
                List<UserData> _userData = new List<UserData>();
                UserDataOutput _UserDataOutput = new UserDataOutput();
                List<LoginTbl> CheckComppanyUsers = _GenericRepoLogins.GetMany(x => x.UserId == UserID).ToList();
                if (CheckComppanyUsers.Count > 0)
                {
                    var UsernameParam = new SqlParameter("@UserID ", UserID);
                    _userData = new AshkandeliryContext().UserData.FromSqlRaw("exec GetUserByID @UserID", UsernameParam).ToList();
                    _UserDataOutput = Mappers.SharedMapper.convert<UserDataOutput, UserData>(_userData.FirstOrDefault());
                }
                else
                    throw new Exception("کاربری با ورودی وارد شده یافت نشد");
                return new DynamicResult<UserDataOutput> { Code = 0, Message = "عملیات با موفقیت انجام شد", ObjList = _UserDataOutput };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
