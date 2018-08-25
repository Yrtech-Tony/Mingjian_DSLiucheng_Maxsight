using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using XHX.DTO;
using System.Data;
//using XHX.WebService;

namespace XHX.Common
{
   public static class BindComBox
    {
       static localhost.Service webService = new localhost.Service();
       static localhost.Service localService = new localhost.Service();
       //static LocalService localService = new LocalService();
       public static bool IsNetWork { get; set; }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="combox"></param>
       public static void BindProject(ComboBoxEdit combox)
       {
           //CommonHandler.DBConnect();
           List<ProjectDto> projectList = new List<ProjectDto>();
           //string sql = string.Format("SELECT ProjectCode,ProjectName FROM Projects");
           DataSet ds = null;
           if (IsNetWork)
           {
               ds = webService.GetAllProject();
           }
           else
           {
               localService.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";
               ds = localService.GetAllProject();
           }
           if (ds.Tables[0].Rows.Count > 0)
           {
               for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
               {
                   ProjectDto project = new ProjectDto();
                   project.ProjectName = Convert.ToString(ds.Tables[0].Rows[i]["ProjectName"]);
                   project.ProjectCode = Convert.ToString(ds.Tables[0].Rows[i]["ProjectCode"]);
                   projectList.Add(project);
               }
           }
           CommonHandler.SetComboBoxEditItems(combox, projectList, "ProjectName", "ProjectCode");

       }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="combox"></param>
       public static void BindProjectWithAll(ComboBoxEdit combox)
       {
           //CommonHandler.DBConnect();
           List<ProjectDto> projectList = new List<ProjectDto>();
           //string sql = string.Format("SELECT ProjectCode,ProjectName FROM Projects");
           DataSet ds = null;
           if (IsNetWork)
           {
               ds = webService.GetAllProject();
           }
           else
           {
               localService.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";
               ds = localService.GetAllProject();
           }
           if (ds.Tables[0].Rows.Count > 0)
           {
               for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
               {
                   ProjectDto project = new ProjectDto();
                   project.ProjectName = Convert.ToString(ds.Tables[0].Rows[i]["ProjectName"]);
                   project.ProjectCode = Convert.ToString(ds.Tables[0].Rows[i]["ProjectCode"]);
                   projectList.Add(project);
               }
           }
           projectList.Insert(0, new ProjectDto() { ProjectName = "全部", ProjectCode = "" });
           CommonHandler.SetComboBoxEditItems(combox, projectList, "ProjectName", "ProjectCode");

       }
       //绑定大区信息
       /// <summary>
       /// 
       /// </summary>
       /// <param name="combox"></param>
       public static void BindArea(ComboBoxEdit combox)
       {

           List<AreaDto> arealist = BindComBox.GetAllArea();
           arealist.Insert(0, new AreaDto() { AreaCode = "", AreaName = "全部" });
           CommonHandler.SetComboBoxEditItems(combox, arealist, "AreaName", "AreaCode");

           
       }
       ///
       //获取所有的大区信息
       /// <summary>
       /// 
       /// </summary>
       /// <returns></returns>
       public static List<AreaDto> GetAllArea()
       {
           //CommonHandler.DBConnect();
           List<AreaDto> areaList = new List<AreaDto>();
           //string sql = string.Format("SELECT AreaCode,AreaName FROM Area");
           DataSet ds = null;
           if (IsNetWork)
           {
               ds = webService.GetAllArea();
           }
           else
           {
               localService.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";
               ds = localService.GetAllArea();
           }
           if (ds.Tables[0].Rows.Count > 0)
           {
               for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
               {
                   AreaDto area = new AreaDto();
                   area.AreaCode = Convert.ToString(ds.Tables[0].Rows[i]["AreaCode"]);
                   area.AreaName = Convert.ToString(ds.Tables[0].Rows[i]["AreaName"]);
                   areaList.Add(area);
               }
           }
           return areaList;
       }
        //绑定失分说明
       public static void BindLoss(ComboBoxEdit combox1, ComboBoxEdit combox2, ComboBoxEdit combox3, string projectCode, string subjectCode)
       {
        
           List<LossResultDto> losslist = new List<LossResultDto>();
           LossResultDto l = new LossResultDto();
           l.LossCode = "";
           l.LossName = "选择";
           losslist.Add(l);
           List<LossResultDto> losslist1 = new List<LossResultDto>();
           LossResultDto l1 = new LossResultDto();
           l1.LossCode = "";
           l1.LossName = "选择";
           losslist1.Add(l1);
           List<LossResultDto> losslist2 = new List<LossResultDto>();
           LossResultDto l2 = new LossResultDto();
           l2.LossCode = "";
           l2.LossName = "选择";
           losslist2.Add(l2);          
           //DataSet ds = webService.SearchLoss(projectCode, subjectCode);
           DataSet ds = null;
           if (IsNetWork)
           {
               ds = webService.SearchLoss(projectCode, subjectCode);
           }
           else
           {
               localService.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";
               ds = localService.SearchLoss(projectCode, subjectCode);
           }
           if (ds.Tables[0].Rows.Count > 0)
           {
               for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
               {
                   LossResultDto loss = new LossResultDto();
                   loss.LossCode = Convert.ToString(ds.Tables[0].Rows[i]["LossCode"]);
                   loss.LossName = Convert.ToString(ds.Tables[0].Rows[i]["LossName"]);
                   loss.LossType = Convert.ToString(ds.Tables[0].Rows[i]["LossType"]);

                   if (loss.LossType == "01")
                   {
                       losslist.Add(loss);
                   }
                   else if (loss.LossType == "02")
                   {
                       losslist1.Add(loss);
                   }
                   else
                   {
                       losslist2.Add(loss);
                   
                   }
               }
           }
           CommonHandler.SetComboBoxEditItems(combox1, losslist, "LossName", "LossName");
           CommonHandler.SetComboBoxEditItems(combox2, losslist1, "LossName", "LossName");
           CommonHandler.SetComboBoxEditItems(combox3, losslist2, "LossName", "LossName");
         
       }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="projectCode"></param>
       /// <param name="combox"></param>
       public static void BindChapter(string projectCode,ComboBoxEdit combox)
       {
           List<ChapterDto> chapterlist = new List<ChapterDto>();
           ChapterDto c = new ChapterDto();
           c.CharterCode = "";
           c.CharterName = "全部";
           chapterlist.Add(c);
           //DataSet ds = webService.SearchChapter(projectCode,"");
           DataSet ds = null;
           if (IsNetWork)
           {
               ds = webService.SearchChapter(projectCode, "");
           }
           else
           {
               localService.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";
               ds = localService.SearchChapter(projectCode, "");
           }
           if (ds.Tables[0].Rows.Count > 0)
           {
               for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
               {
                   ChapterDto chapter = new ChapterDto();
                   chapter.CharterCode = Convert.ToString(ds.Tables[0].Rows[i]["CharterCode"]);
                   chapter.CharterName = Convert.ToString(ds.Tables[0].Rows[i]["CharterName"]);
                   chapterlist.Add(chapter);
               }
           }

          // if (chapterlist)
           CommonHandler.SetComboBoxEditItems(combox, chapterlist, "CharterName", "CharterCode");
       }
/// <summary>
/// 
/// </summary>
/// <param name="projectCode"></param>
/// <param name="chapterCode"></param>
/// <param name="combox"></param>
       public static void BindLink(string projectCode, string chapterCode, ComboBoxEdit combox)
       {
           List<LinkDto> linkList = new List<LinkDto>();
           LinkDto l = new LinkDto();
           l.LinkCode = "";
           l.LinkName = "全部";
           linkList.Add(l);
           //DataSet ds = webService.SearchLink(projectCode, chapterCode);
           DataSet ds = null;
           if (IsNetWork)
           {
               ds = webService.SearchLink(projectCode, chapterCode);
           }
           else
           {
               localService.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";
               ds = localService.SearchLink(projectCode, chapterCode);
           }
           if (ds.Tables[0].Rows.Count > 0)
           {
               for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
               {
                   LinkDto link = new LinkDto();
                   link.LinkCode = Convert.ToString(ds.Tables[0].Rows[i]["LinkCode"]);
                   link.LinkName = Convert.ToString(ds.Tables[0].Rows[i]["LinkName"]);

                   linkList.Add(link);
               }
              
               
           }
           CommonHandler.SetComboBoxEditItems(combox, linkList, "LinkName", "LinkCode");
       }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="projectCode"></param>
       public static void BindScoreSet(string projectCode)
       {
           List<ScoreSetDto> scorelist = new List<ScoreSetDto>();
           ScoreSetDto score = new ScoreSetDto();

           //score.Score = "";
           //l.LinkName = "请选择";
           //linkList.Add(l);
           //DataSet ds = webService.SearchLink(projectCode, chapterCode);
           //if (ds.Tables[0].Rows.Count > 0)
           //{
           //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
           //    {
           //        LinkDto link = new LinkDto();
           //        link.LinkCode = Convert.ToString(ds.Tables[0].Rows[i]["LinkCode"]);
           //        link.LinkName = Convert.ToString(ds.Tables[0].Rows[i]["LinkName"]);

           //        linkList.Add(link);
           //    }


           //}
           //CommonHandler.SetComboBoxEditItems(combox, linkList, "LinkName", "LinkCode");
       }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="combox"></param>
       public static void BindAreaType(ComboBoxEdit combox)
       {
           List<AreaTypeDto> areaTypeList = new List<AreaTypeDto>();
           AreaTypeDto areaTypeDto = new AreaTypeDto();
           areaTypeDto.AreaTypeCode = "";
           areaTypeDto.AreaTypeName = "全部";
           areaTypeList.Add(areaTypeDto);
           DataSet ds = null;
           if (IsNetWork)
           {
               ds = webService.GetAllAreaType();
           }
           else
           {
               localService.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";
               ds = localService.GetAllAreaType();
           }
           if (ds.Tables[0].Rows.Count > 0)
           {
               for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
               {
                   AreaTypeDto areaType = new AreaTypeDto();
                   areaType.AreaTypeCode = Convert.ToString(ds.Tables[0].Rows[i]["AreaTypeCode"]);
                   areaType.AreaTypeName = Convert.ToString(ds.Tables[0].Rows[i]["AreaTypeName"]);
                   areaTypeList.Add(areaType);
               }
           }
           CommonHandler.SetComboBoxEditItems(combox, areaTypeList, "AreaTypeName", "AreaTypeCode");
       }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="combox"></param>
       public static void BindSubjectExamType(ComboBoxEdit combox)
       {
           List<SubjectExamType> subjectExamTypeList = new List<SubjectExamType>();
           subjectExamTypeList.Add(new SubjectExamType("","选择"));
           subjectExamTypeList.Add(new SubjectExamType("A","A卷"));
           subjectExamTypeList.Add(new SubjectExamType("B","B卷"));
           CommonHandler.SetComboBoxEditItems(combox, subjectExamTypeList, "SubjectExamTypeName", "SubjectExamTypeCode");
       }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="combox"></param>
       public static void BindSubjectType(ComboBoxEdit combox)
       {
           List<SubjectTypeDto> subjectTypeList = new List<SubjectTypeDto>();
           SubjectTypeDto subjectType = new SubjectTypeDto("","全部");
           subjectTypeList.Add(subjectType);
           subjectTypeList.Add(new SubjectTypeDto("SA", "照片类"));
           subjectTypeList.Add(new SubjectTypeDto("SB", "资料类"));
           subjectTypeList.Add(new SubjectTypeDto("SC", "交叉类"));
           CommonHandler.SetComboBoxEditItems(combox, subjectTypeList, "SubjectTypeName", "SubjectTypeCode");
       }
    }
    /// <summary>
    /// 
    /// </summary>
   public class SubjectExamType
   {
       public string SubjectExamTypeCode { get; set; }
       public string SubjectExamTypeName { get; set; }
       public SubjectExamType(string _subjectExamTypeCode, string _subjectExamTypeName)
       {
           this.SubjectExamTypeCode = _subjectExamTypeCode;
           this.SubjectExamTypeName = _subjectExamTypeName;
       }
   }
}
