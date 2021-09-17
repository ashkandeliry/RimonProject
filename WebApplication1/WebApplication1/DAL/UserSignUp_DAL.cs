using Common.CustomValidations;
using DataAccessLayer.Model;
using EshopLoginManagment.DAL.IDAL;
using Prototypes;
using SharedMethodsLib.Results.GeneralTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopLoginManagment.DAL
{
    public class UserSignUp_DAL : IUserSignUp_DAL
    {
        private GenericRepository.GenericRepo<UsersTbl> _GenericRepoUsers;
        private GenericRepository.GenericRepo<LoginTbl> _GenericRepoLoginsTBL;
        public UserSignUp_DAL(AshkandeliryContext DbContext)
        {
            _GenericRepoUsers = new GenericRepository.GenericRepo<UsersTbl>(DbContext);
            _GenericRepoLoginsTBL = new GenericRepository.GenericRepo<LoginTbl>(DbContext);
        }
        public BoolResult CheckUserBySSNcode(string SSNcode)
        {
            try
            {
                string SsnCodeValidation = NationalCodeValidator.ValidateNationCode(SSNcode, true);
                object _userData = new object();
                List<UsersTbl> CheckComppanyUsers = _GenericRepoUsers.GetMany(x => x.Ssncode == SSNcode).ToList();
                if (CheckComppanyUsers.Count > 0)
                    return new BoolResult { Obj = false };
                else
                    return new BoolResult { Obj = true };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public BoolResult CheckUserByUsername(string Username)
        {
            try
            {
                string SsnCodeValidation = NationalCodeValidator.ValidateNationCode(Username, true);
                object _userData = new object();
                List<LoginTbl> CheckComppanyUsers = _GenericRepoLoginsTBL.GetMany(x => x.Username == Username).ToList();
                if (CheckComppanyUsers.Count > 0)
                    return new BoolResult { Obj = false };
                else
                    return new BoolResult { Obj = true };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public VoidResult UserManagment(UserSignUpVM _userSignUpVM)
        {
            try
            {
                UsersTbl _tblUser = new UsersTbl();
                LoginTbl _tblLogin = new LoginTbl();
                object Result = new object();
                _tblUser = Mappers.SharedMapper.convert<UsersTbl, UserSignUpVM>(_userSignUpVM);
                _tblUser = _GenericRepoUsers.Insert(_tblUser);
                _userSignUpVM.UserId = _tblUser.Id;
                _tblLogin = Mappers.SharedMapper.convert<LoginTbl, UserSignUpVM>(_userSignUpVM);
                _tblLogin = _GenericRepoLoginsTBL.Insert(_tblLogin);
                return VoidResult.GetSuccessResult("عملیات با موفقیت انجام شد");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
