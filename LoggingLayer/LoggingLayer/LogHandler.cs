using EshopLoginManagment.GenaralCLS;
using LoggingLayer.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace EshopLoginManagment.GenaralCLS
{
    public class LogHandler
    {
        public static void LogError(Exception ex, MethodBase serviceMethodInfo, params Object[] serviceParameterValues)
        {
            try
            {
                var innerMethodBase = (MethodBase)ex.Data[0];
                var innerParameters = (string)ex.Data[1];
                var stackTrace = (StackTrace)ex.Data[2];
                int? lineNumber = null;
                if (stackTrace != null)
                {
                    lineNumber = stackTrace.GetFrame(0).GetFileLineNumber();
                }

                var serviceParameterNames = serviceMethodInfo.GetParameters();

                string serviceParametersJS = SerializeParameters(serviceParameterNames, serviceParameterValues, serviceMethodInfo);
                if (ex.GetType() == typeof(ITException))
                {
                    HandledErrorLog errorLog = new HandledErrorLog()
                    {
                        CreateDateTime = DateTime.Now,
                        ServiceName = "",
                        ServiceMethodName = serviceMethodInfo.DeclaringType.FullName,
                        ServiceParameters = serviceParametersJS,
                    };
                    AshkandeliryContext _db = new AshkandeliryContext();
                    _db.HandledErrorLogs.Add(errorLog);
                    _db.SaveChanges();
                }
                else
                {
                    SystemErrorLog errorLog = new SystemErrorLog()
                    {
                        CreateDateTime = DateTime.Now,
                        ExceptionStr = ex.ToString(),
                        ServiceName = " ",
                        ServiceMethodName = " ",
                        ServiceParameters = serviceParametersJS,
                    };

                    AshkandeliryContext _db = new AshkandeliryContext();
                    _db.SystemErrorLogs.Add(errorLog);
                    _db.SaveChanges();
                }
            }
            catch (Exception exx)
            {
                try
                {
                    SystemErrorLog log = new SystemErrorLog()
                    {
                        CreateDateTime = DateTime.Now,
                        ExceptionStr = "********************** خطا در لاگ ارور***********" + ex.ToString(),
                        ServiceName = " ",
                        ServiceMethodName = " ",
                        ServiceParameters = JsonConvert.SerializeObject(serviceParameterValues),
                    };
                    AshkandeliryContext _db = new AshkandeliryContext();
                    _db.SystemErrorLogs.Add(log);
                    _db.SaveChanges();
                }
                catch (Exception ex1)
                {

                }
            }
        }

        public static void LogData(MethodBase methodInfo, Object answer, TimeSpan? executeTime, params Object[] parameterValues)
        {
            try
            {
                OperationLog log = new OperationLog()
                {
                    Answer = answer == null ? null : JsonConvert.SerializeObject(answer),
                    CreateDateTime = DateTime.Now,
                    ExecuteTime = executeTime == null ? null : executeTime.ToString(),
                    MethodName = methodInfo.DeclaringType.FullName,
                    ServiceName = "",
                    Parameters = SerializeParameters(methodInfo.GetParameters(), parameterValues, methodInfo),
                };

                AshkandeliryContext _db = new AshkandeliryContext();
                _db.OperationLogs.Add(log);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                try
                {
                    try
                    {
                        SystemErrorLog log = new SystemErrorLog()
                        {
                            CreateDateTime = DateTime.Now,
                            ExceptionStr = "********************** خطا در لاگ دیتا***********" + e.ToString(),
                            ServiceName = " ",
                            ServiceMethodName = " ",
                            ServiceParameters = JsonConvert.SerializeObject(parameterValues),
                        };

                        AshkandeliryContext _db = new AshkandeliryContext();
                        _db.SystemErrorLogs.Add(log);
                        _db.SaveChanges();
                    }
                    catch (Exception)
                    {

                    }
                }
                catch (Exception)
                {

                }
            }
            //});
        }


        private static string SerializeParameters(ParameterInfo[] parameterNames, Object[] parameterValues, MethodBase methodInfo)
        {
            try
            {
                string parametersJS = string.Empty;
                if (parameterNames.Length == parameterValues.Length)
                {
                    Dictionary<string, Object> dictionary = new Dictionary<string, object>();
                    for (int i = 0; i < parameterValues.Length; i++)
                    {
                        if (parameterValues[i] != null && parameterValues[i].GetType() == typeof(LogingInt))
                            dictionary.Add(parameterNames[i].Name, "BigData (Count: " + parameterValues[i].ToString() + " )");
                        else if (parameterValues[i] != null && parameterValues[i].GetType() == typeof(LogingString))
                            dictionary.Add(parameterNames[i].Name, "***");
                        else
                            dictionary.Add(parameterNames[i].Name, parameterValues[i]);
                    }
                    parametersJS = JsonConvert.SerializeObject(dictionary);
                    //JsonConvert.SerializeObject(dictionary, Formatting.Indented, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                }
                else
                {
                    try
                    {
                        parametersJS = JsonConvert.SerializeObject(parameterValues);
                        //SystemErrorLogBusinessModel log = new SystemErrorLogBusinessModel()
                        //{
                        //    CreateDateTime = DateTime.Now,
                        //    ExceptionStr = "******* ایراد در پارامترهای لاگ ****** " + methodInfo.DeclaringType.FullName + " - " + methodInfo.Name,
                        //};
                        //LogFactoryContainer.Factory.SystemErrorLogDao.Insert(log);
                    }
                    catch { }
                }
                return parametersJS;
            }
            catch (Exception ex)
            {
                try
                {
                    //var devLog = DevLogBusinessModel.Create(DateTime.Now, DevLogTitle.ErrorLogException, (byte)DevLogStatus.New, "خطا در لاگ ارور" + methodInfo.DeclaringType.FullName + " - " + methodInfo.Name + ex.ToString());
                    //LogFactoryContainer.Factory.DevLogDao.Insert(devLog);
                }
                catch { }
                return "خطا";
            }
        }

        public class LogingInt
        {
            public int Value { get; set; }

            public override string ToString()
            {
                return Value.ToString();
            }
        }

        public class LogingString
        {

        }
    }
}
