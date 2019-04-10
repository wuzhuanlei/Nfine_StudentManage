using System;

namespace NFine.Domain.Entity.StudentManage
{
    public class StudentEntity : IEntity<StudentEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        /// <summary>
        /// 学生Id
        /// </summary>
        public long StudentId { get; set; }
        /// <summary>
        /// 学生姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 学生编号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        public string Nationality { get; set; }
        /// <summary>
        /// 政治面貌
        /// </summary>
        public string Political { get; set; }
        /// <summary>
        /// 籍贯
        /// </summary>
        public string Birthplace { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        public string IDCardNumber { get; set; }
        /// <summary>
        /// 校园卡号
        /// </summary>
        public string CampusCode { get; set; }
        public string Telephone { get; set; }
        /// <summary>
        /// 宿舍编号
        /// </summary>
        public string DormitoryCode { get; set; }
        /// <summary>
        /// 入学年级
        /// </summary>
        public string EntryGrade { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public bool Sex { get; set; }
        /// <summary>
        /// 户籍类型
        /// </summary>
        public bool CensusType { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        public bool IDCardType { get; set; }
        /// <summary>
        /// 辅导员
        /// </summary>
        public string Counselor { get; set; }
        /// <summary>
        /// 培养层次
        /// </summary>
        public string TrainingLevel { get; set; }
        /// <summary>
        /// 辅导员电话
        /// </summary>
        public string CounselorPhone { get; set; }
        /// <summary>
        /// 专业
        /// </summary>
        public string Profession { get; set; }
        /// <summary>
        /// 院系
        /// </summary>
        public string Department { get; set; }
        /// <summary>
        /// 婚姻状况
        /// </summary>
        public string MaritalStatus { get; set; }
        /// <summary>
        /// 家庭电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 家庭地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 兴趣爱好
        /// </summary>
        public string Hobby { get; set; }
        /// <summary>
        /// 作息规律
        /// </summary>
        public string LawRest { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? Birthday { get; set; }
        public string F_Id { get; set; }
        public string F_CreatorUserId { get; set; }
        public DateTime? F_CreatorTime { get; set; }
        public DateTime? F_LastModifyTime { get; set; }
        public string F_LastModifyUserId { get; set; }
        public bool? F_DeleteMark { get; set; }
        public DateTime? F_DeleteTime { get; set; }
        public string F_DeleteUserId { get; set; }
    }
}
