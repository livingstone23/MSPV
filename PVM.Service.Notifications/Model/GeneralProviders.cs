using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Service.Notifications.Model
{
    [Table("General-Providers", Schema = "dbo")]
    public class GeneralProviders
    {
        [Key]
        public Guid Oid { get; set; }
        public DateTime LastChange { get; set; }
        public Guid LastUser { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string CertIssuer { get; set; }
        public string CertSubject { get; set; }
        public string CertPassword { get; set; }
        public string Server_SFTP { get; set; }
        public string User_SFTP { get; set; }
        public string Password_SFTP { get; set; }
        public int Port_SFTP { get; set; }
        public string File_Response { get; set; }
        public string Response_SFTP { get; set; }
        public int OptimisticLockField { get; set; }
        public int GCRecord { get; set; }
        public string ProtocolVersion { get; set; }
        public Guid Project { get; set; }
        public double DefaultSLATime { get; set; }
        public string PGestBaseObjectType { get; set; }
        public string EmailReclaimed { get; set; }
        public string FilesPathSegment { get; set; }
    }
}
