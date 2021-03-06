﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coder.Core.Models.Commons;
using Coder.Core.Models.Functions;
using Coder.Core.Models.OnlineJudges;
using Coder.Core.Models.Solutions;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Coder.Resources
{
    /// <summary>
    /// 做类型转换的工具类
    /// </summary>
    public static class TypeConvertTool
    {
        public static IDictionary<string, Object> getModelDictionary()
        {
            IDictionary<string, Object> models = new Dictionary<string, Object>();
            models.Add("CommentModel", new CommentModel());
            models.Add("CommonModel", new CommonModel());
            models.Add("CompanyModel", new CompanyModel());
            models.Add("FeedbackModel", new FeedbackModel());
            models.Add("InsideMessageModel", new InsideMessageModel());
            models.Add("LevelModel", new CommentModel());
            models.Add("PowerModel", new PowerModel());
            models.Add("PowerViewModel", new PowerViewModel());
            models.Add("RuleModel", new RuleModel());
            models.Add("UserModel", new UserModel());
            models.Add("WealthModel", new WealthModel());
            models.Add("CodeModel", new CodeModel());
            models.Add("FunctionModel", new FunctionModel());
            models.Add("FunctionPlateModel", new FunctionPlateModel());
            models.Add("BaseProblemModel", new BaseProblemModel());
            models.Add("ContestPermissionModel", new ContestPermissionModel());
            models.Add("ListModel", new ListModel());
            models.Add("ModelProblemModel", new CommentModel());
            models.Add("ResultCodeModel", new ResultCodeModel());
            models.Add("ResultModel", new ResultModel());
            models.Add("SingleContestModel", new SingleContestModel());
            models.Add("SingleResultModel", new SingleResultModel());
            models.Add("SourceModel", new CommentModel());
            models.Add("TeamContestModel", new TeamContestModel());
            models.Add("TeamModel", new TeamModel());
            models.Add("TeamResultModel", new TeamResultModel());
            models.Add("SolutionModel", new SolutionModel());
            models.Add("SolutionProblemModel", new SolutionProblemModel());
            models.Add("TypeModel", new TypeModel());
            return models;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="strProperties">类属性值字符串</param>
        /// 在strProperties中无参数的属性值用字符串"null"填充<br/>
        /// eg:  "aaa####bbb####null####ccc####dd"
        /// <param name="className">类名</param>
        /// <returns></returns>
        public static Object StringToModel(string strProperties , string className)
        {
            Object model;
            IDictionary<string, Object> models = getModelDictionary();
            
            if (models == null)
                return null;

            if (!models.TryGetValue(className, out model))
                return null;
            else 
            {
                int i = 0;      //属性累加器
                try
                {
                    string[] propTemp = Regex.Split(strProperties, CommonStr.constantSplitStr, RegexOptions.IgnoreCase);  //这边应该配置分割常量
                    PropertyInfo[] propertys = model.GetType().GetProperties();

                    
                    foreach (PropertyInfo property in propertys)
                    {
                        if (!propTemp[i].Equals("null"))
                        {
                            property.SetValue(model, propTemp[i]);
                        }
                        else 
                        {
                            property.SetValue(model, null);
                        }
                        i++ ;
                    }
                    if (propTemp.Length != i)   
                    {
                        return null;
                    }
                }
                catch (Exception e)
                {
                    return null;
                }
            }

            return model;
        }

    }
}
